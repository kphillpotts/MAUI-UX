using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = Microsoft.Maui.Graphics.Color;

namespace MauiUX.Data
{
    public class Data
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string AvatarImage { get; internal set; }
        public Color AccentColor { get; internal set; }
        
    }
    
    public class DataService
    {
        public static List<Data> GetData() => new()
        {

            new Data
            {
                Title = "Item 1",
                Description = "Details for Item 1",
                Image = "landscape1_image.jpg",
                AvatarImage = "person11_image.jpg",
                AccentColor = Color.FromArgb("#80a8ef"),
            },
            new Data
            {
                Title = "Item 2",
                Description = "Details for Item 2",
                Image = "landscape2_image.jpg",
                AvatarImage = "person35_image.jpg",
                AccentColor = Color.FromArgb("#eea768"),
            },
            new Data
            {
                Title = "Item 3",
                Description = "Details for Item 3",
                Image = "landscape3_image.jpg",
                AvatarImage = "person40_image.jpg",
                AccentColor = Color.FromArgb("#e95f7d"),
            },
            new Data
            {
                Title = "Item 4",
                Description = "Details for Item 4",
                Image = "landscape4_image.jpg",
                AvatarImage = "person55_image.jpg",
                AccentColor = Color.FromArgb("#a67dee"),
            },
            new Data
            {
                Title = "Item 5",
                Description = "Details for Item 5",
                Image = "landscape5_image.jpg",
                AvatarImage = "person72_image.jpg",
                AccentColor = Color.FromArgb("#6ee1c0"),
            },        };
    }

}
