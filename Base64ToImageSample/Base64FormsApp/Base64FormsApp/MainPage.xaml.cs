using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Base64FormsApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();


        }



        protected override void OnAppearing()
        {
            base.OnAppearing();
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("Base64FormsApp.Base64image.txt");
            string base64data = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                base64data = reader.ReadToEnd();
            }
            ConvertedImage.Source = Base64StringToImageSource(base64data);
        }

        public ImageSource Base64StringToImageSource(string source)
        {
            var byteArray = Convert.FromBase64String(source);
            Stream stream = new MemoryStream(byteArray);
            return ImageSource.FromStream(()=>stream);
        }
    }
}
