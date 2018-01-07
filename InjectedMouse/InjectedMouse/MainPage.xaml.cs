using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Input.Preview.Injection;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace InjectedMouse
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private int _numberOfClicks = 0;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void MoveMouse()
        {
            var info = new InjectedInputMouseInfo();
            info.MouseOptions = InjectedInputMouseOptions.Move;
            info.DeltaY = 100;

            InputInjector inputInjector = InputInjector.TryCreate();
            inputInjector.InjectMouseInput(new[] { info });
        }

        private void ScrollMouse()
        {
            MoveMouse(); //first move mouse above the listview
            var info = new InjectedInputMouseInfo();
            info.MouseOptions = InjectedInputMouseOptions.Wheel;
            unchecked
            {
                info.MouseData = (uint)-500; //scroll down
            }

            InputInjector inputInjector = InputInjector.TryCreate();
            inputInjector.InjectMouseInput(new[] { info });
        }

        private async void TypeText()
        {
            TypingTarget.Focus(FocusState.Programmatic);
            await Task.Delay(100); //we must yield the UI thread so that focus can be acquired

            InputInjector inputInjector = InputInjector.TryCreate();
            foreach (var letter in "hello")
            {
                var info = new InjectedInputKeyboardInfo();
                info.VirtualKey = (ushort)((VirtualKey)Enum.Parse(typeof(VirtualKey), letter.ToString(), true));
                inputInjector.InjectKeyboardInput(new[] { info });
                await Task.Delay(100);
            }
        }

        private void StackPanel_PreviewKeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.C)
            {
                var down = new InjectedInputMouseInfo();
                down.MouseOptions = InjectedInputMouseOptions.LeftDown;

                var up = new InjectedInputMouseInfo();
                up.MouseOptions = InjectedInputMouseOptions.LeftUp;

                InputInjector inputInjector = InputInjector.TryCreate();
                inputInjector.InjectMouseInput(new[] { down, up });
            }
        }
    }
}
