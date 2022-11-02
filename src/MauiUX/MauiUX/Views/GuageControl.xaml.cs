using MauiUX.Effects;
using SkiaSharp;
using Svg.Skia;
using SkiaSharp.Views.Maui;

namespace MauiUX.Views;

public partial class GuageControl : ContentView
{
	public GuageControl()
	{
		InitializeComponent();
        Percent = 50;
    }

    public double Percent
    {
        get => percent;
        set
        {
            percent = value;
            TempGaugeCanvas.InvalidateSurface();
        }
    }


    SKPath clipPath = SKPath.ParseSvgPathData("M.021 28.481a25.933 25.933 0 0 0 8.824-2.112 27.72 27.72 0 0 0 7.391-5.581l19.08-17.045S39.879.5 44.516.5s9.352 3.243 9.352 3.243l20.74 18.628a30.266 30.266 0 0 0 4.525 3.545c3.318 2.263 11.011 2.564 11.011 2.564z");

    SKPaint redBrush = new SKPaint()
    {
        Style = SKPaintStyle.Stroke,
        Color = SKColors.Red,
        StrokeWidth = 3
    };



    // background brush
    SKPaint backgroundBrush = new SKPaint()
    {
        Style = SKPaintStyle.Fill,
        Color = SKColors.Red
    };
    private double percent;

    const float bottomPadding = 100f;

    private void TempGaugeCanvas_PaintSurface(object sender, SkiaSharp.Views.Maui.SKPaintSurfaceEventArgs e)
    {
        SKImageInfo info = e.Info;
        SKSurface surface = e.Surface;
        SKCanvas canvas = surface.Canvas;

        canvas.Clear();

        // get density
        float density = info.Size.Width / (float)this.Width;

        var scaledClipPath = new SKPath(clipPath);
        scaledClipPath.Transform(SKMatrix.MakeScale(density, density));
        scaledClipPath.GetTightBounds(out var tightBounds);

        // position it
        var xPos = info.Width * ((float)percent / 100);

        // provide a clamp 
        xPos = Math.Min(Math.Max(xPos, 100), info.Width - 100);

        var translateX = (xPos - tightBounds.MidX);
        var translateY = info.Height - (tightBounds.Height + bottomPadding);

        using (new SKAutoCanvasRestore(canvas))
        {
            // apply translations to position the clip path
            canvas.Translate(translateX, translateY);
            canvas.ClipPath(scaledClipPath, SKClipOperation.Difference, true);
            canvas.Translate(-translateX, -translateY);

            // get the theme colors

            // get the brush based on the theme
            SKColor gradientStart = ((Color)Application.Current.Resources["GaugeGradientStartColor"]).ToSKColor();
            SKColor gradientEnd = ((Color)Application.Current.Resources["GaugeGradientEndColor"]).ToSKColor();

            // gradient backround
            backgroundBrush.Shader = SKShader.CreateLinearGradient(
                                          new SKPoint(0, 0),
                                          new SKPoint(info.Width, info.Height),
                                          new SKColor[] { gradientStart, gradientEnd },
                                          new float[] { 0, 1 },
                                          SKShaderTileMode.Clamp);
            SKRect backgroundBounds = new SKRect(0, 0, info.Width, info.Height - bottomPadding);
            canvas.DrawRoundRect(backgroundBounds, 20, 20, backgroundBrush);

            // draw tick marks
            info = DrawTicks(info, canvas);
            DrawSvgAtPoint(canvas, new SKPoint(100, (float)info.Height - (bottomPadding + 100)), (float)100, "MauiUX.Images.Snowflake.svg");
            DrawSvgAtPoint(canvas, new SKPoint(info.Width - 100, (float)info.Height - (bottomPadding + 100)), (float)100, "MauiUX.Images.Heat.svg");

        }
        // draw the thumb
        using (Stream stream = GetType().Assembly.GetManifestResourceStream("MauiUX.Images.Thumb.png"))
        {
            SKBitmap bitmap = SKBitmap.Decode(stream);
            var imageHeight = bitmap.Height * .75;
            var imageWidth = bitmap.Width * .75;

            SKRect thumbRect = new SKRect(0, 0, (float)imageWidth, (float)imageHeight);
            thumbRect.Location = new SKPoint(xPos - ((float)imageWidth / 2), (float)info.Height - (bottomPadding + (float)(imageHeight / 2)));

            //SKPoint location = new SKPoint(xPos - (bitmap.Width / 2), info.Height - bitmap.Height);
            canvas.DrawBitmap(bitmap, thumbRect);
        }

    }

    private static SKImageInfo DrawTicks(SKImageInfo info, SKCanvas canvas)
    {
        var numTicks = 15;
        var distance = info.Width / numTicks;
        var tickHeight = 50;
        for (int i = 1; i < numTicks; i++)
        {
            var start = new SKPoint(i * distance, info.Height - bottomPadding);
            var end = new SKPoint(i * distance, info.Height - (tickHeight + bottomPadding));

            SKPaint tickBrush = new SKPaint()
            {
                Style = SKPaintStyle.Stroke,
                StrokeWidth = 2,
            };
            tickBrush.Shader = SKShader.CreateLinearGradient(
                                      start,
                                      end,
                                      new SKColor[] { new SKColor(255, 255, 255, 200), new SKColor(255, 255, 255, 0) },
                                      new float[] { 0, 1 },
                                      SKShaderTileMode.Clamp);
            canvas.DrawLine(start, end, tickBrush);

        }

        return info;
    }

    public static async Task<SKSvg> LoadSvgFromFile(string fileName)
    {
        // read the file
        using var stream = await FileSystem.OpenAppPackageFileAsync(fileName);
        using var reader = new StreamReader(stream);
        var svgData = reader.ReadToEnd();

        //load into SVG
        SKSvg svg = new SKSvg();
        svg.FromSvg(svgData);
        return svg;
    }

    public static void DrawScaledSVG(SKSvg svg, SkiaSharp.SKCanvas canvas, SKRectI drawBounds)
    {
        if (svg == null) return;
        // Get bounding rectangle for SVG image
        var boundingBox = svg.Picture.CullRect;

        // Translate and scale drawing canvas to fit SVG image
        canvas.Translate(drawBounds.MidX, drawBounds.MidY);
        canvas.Scale(0.9f *
            Math.Min(drawBounds.Width / boundingBox.Width,
                drawBounds.Height / boundingBox.Height));
        canvas.Translate(-boundingBox.MidX, -boundingBox.MidY);

        // Now finally draw the SVG image
        canvas.DrawPicture(svg.Picture);

        // Optional -> Reset the matrix before performing more draw operations
        canvas.ResetMatrix();
    }

    private void DrawSvgAtPoint(SKCanvas canvas, SKPoint location, float size, string svgName)
    {
        // load up the SVG
        using (Stream stream = GetType().Assembly.GetManifestResourceStream(svgName))
        {
            var svg = new SKSvg();
            svg.Load(stream);

            SKRectI rect = new SKRectI((int)(location.X - size / 2), (int)(location.Y - size / 2), (int)(location.X + size / 2), (int)(location.Y + size / 2));

            DrawScaledSVG(svg, canvas, rect);
        }
    }

    private void TempGaugeCanvas_Touch(object sender, SKTouchEventArgs e)
    {
        switch (e.ActionType)
        {
            case SKTouchAction.Pressed:
                Percent = (e.Location.X / TempGaugeCanvas.CanvasSize.Width) * 100;
                break;
            case SKTouchAction.Moved:
                Percent = (e.Location.X / TempGaugeCanvas.CanvasSize.Width) * 100;
                break;
        }
        e.Handled = true;
        
    }
}