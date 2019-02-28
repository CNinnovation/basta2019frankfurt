using AdaptiveCards.Rendering;
using AdaptiveCards.Rendering.Uwp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;
using Windows.Storage.Pickers;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPCards
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private AdaptiveCards.Rendering.Uwp.AdaptiveHostConfig _hostConfig;

        public MainPage()
        {
            this.InitializeComponent();
            _hostConfig = new AdaptiveCards.Rendering.Uwp.AdaptiveHostConfig()
            {
                Actions =
                {
                    ShowCard =
                    {
                        ActionMode = ActionMode.Inline
                    }
                }
            };
        }

        private async void OnShowCard(object sender, RoutedEventArgs e)
        {
            async Task ShowSubmitActionAsync(RenderedAdaptiveCard card, AdaptiveSubmitAction action)
            {
                var inputs = card.UserInputs.AsJson();
                string text = $"{inputs} {action.ToJson()}";
                await new MessageDialog(text).ShowAsync();
            }

            void OpenUrlAction(RenderedAdaptiveCard card, AdaptiveOpenUrlAction action)
            {
                webView.Navigate(action.Url);
            }

            AdaptiveCardRenderer renderer = new AdaptiveCardRenderer();
            renderer.HostConfig = _hostConfig;

            var result = AdaptiveCard.FromJsonString(await LoadJsonAsync());
            var renderedCard = renderer.RenderAdaptiveCard(result.AdaptiveCard);
            renderedCard.Action += async (RenderedAdaptiveCard card, AdaptiveActionEventArgs args) =>
            {
                switch (args.Action)
                {
                    case AdaptiveSubmitAction submitAction:
                        await ShowSubmitActionAsync(card, submitAction);
                        break;
                    case AdaptiveShowCardAction showCardAction:
                        // nothing to do if the activity is shown inline
                        break;
                    case AdaptiveOpenUrlAction openUrlAction:
                        OpenUrlAction(card, openUrlAction);
                        break;
                    default:
                        break;
                }
            };
            grid1.Children.Clear();
            grid1.Children.Add(renderedCard.FrameworkElement);
        }

        private async Task<string> LoadJsonAsync()
        {
            var picker = new FileOpenPicker();
            picker.FileTypeFilter.Add(".json");

            var operation = await picker.PickSingleFileAsync();
            Stream stream = await operation.OpenStreamForReadAsync();
            StreamReader reader = new StreamReader(stream);
            string json = await reader.ReadToEndAsync();
            return json;
        }
    }
}
