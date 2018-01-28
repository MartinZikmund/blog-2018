using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Base64ToImageSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string base64data = await
                FileIO.ReadTextAsync(await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Base64image.txt")));
            ConvertedImage.Source = await Base64StringToBitmapSimplerAsync(base64data);
        }

        public async Task<BitmapImage> Base64StringToBitmapLongerAsync(string source)
        {
            var inMemoryStream = new InMemoryRandomAccessStream();
            var byteArray = Convert.FromBase64String(source);
            var dataWriter = new DataWriter(inMemoryStream);
            dataWriter.WriteBytes(byteArray);
            await dataWriter.StoreAsync();
            inMemoryStream.Seek(0);
            var bitmapImage = new BitmapImage();
            await bitmapImage.SetSourceAsync(inMemoryStream);
            return bitmapImage;
        }

        public async Task<BitmapImage> Base64StringToBitmapSimplerAsync(string source)
        {
            var byteArray = Convert.FromBase64String(source);            
            BitmapImage bitmap = new BitmapImage();
            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                await bitmap.SetSourceAsync(stream.AsRandomAccessStream());
            }
            return bitmap;
        }
    }
}
