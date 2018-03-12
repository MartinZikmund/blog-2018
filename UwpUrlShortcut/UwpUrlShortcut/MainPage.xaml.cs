using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UwpUrlShortcut
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await CreateShortcutAsync();
        }

        private async Task CreateShortcutAsync()
        {

FileSavePicker savePicker = new FileSavePicker
{
    SuggestedStartLocation = PickerLocationId.Desktop
};
savePicker.FileTypeChoices.Add("Shortcut", new [] { ".urltmp" });
var saveFile = await savePicker.PickSaveFileAsync();

if (saveFile != null)
{
    await FileIO.WriteLinesAsync(saveFile, new string[] { "[InternetShortcut]", "URL=http://www.seznam.cz/" });
                await saveFile.RenameAsync("neco.url");
}
        }
    }
}
