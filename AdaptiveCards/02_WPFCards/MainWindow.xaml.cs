using AdaptiveCards;
using AdaptiveCards.Rendering;
using AdaptiveCards.Rendering.Wpf;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPFCards
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AdaptiveHostConfig _hostConfig;

        public MainWindow()
        {
            InitializeComponent();
            webBrowser.SuppressScriptErrors(true);
            _hostConfig = new AdaptiveHostConfig
            {
                Actions =
                {
                    ShowCard =
                    {
                        ActionMode = ShowCardActionMode.Inline
                    }
                }
            };
        }

        private async void OnShowCard(object sender, RoutedEventArgs e)
        {
            void ShowSubmitAction(RenderedAdaptiveCard card, AdaptiveSubmitAction action)
            {
                var inputs = card.UserInputs.AsJson();
                inputs.Merge(action.Data);
                MessageBox.Show(JsonConvert.SerializeObject(inputs, Formatting.Indented));
            }

            void ShowCardAction(RenderedAdaptiveCard card, AdaptiveShowCardAction action)
            {
                if (_hostConfig.Actions.ShowCard.ActionMode == ShowCardActionMode.Popup)
                {
                    var dialog = new ShowCardWindow("Show Card", action);
                    dialog.Owner = this;
                    dialog.ShowDialog();
                }
            }

            void OpenUrlAction(RenderedAdaptiveCard card, AdaptiveOpenUrlAction action)
            {
                webBrowser.Navigate(action.Url.ToString());
            }

            AdaptiveCardRenderer renderer = new AdaptiveCardRenderer(_hostConfig);
            var version = renderer.SupportedSchemaVersion;
            var result = AdaptiveCard.FromJson(await LoadJsonAsync());
            var renderedCard = renderer.RenderCard(result.Card);
            renderedCard.OnAction += (RenderedAdaptiveCard card, AdaptiveActionEventArgs args) =>
            {
                switch (args.Action)
                {
                    case AdaptiveSubmitAction submitAction:
                        ShowSubmitAction(card, submitAction);
                        break;
                    case AdaptiveShowCardAction showCardAction:
                        ShowCardAction(card, showCardAction);
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
            var picker = new OpenFileDialog
            {
                DefaultExt = ".json",
                Filter = "JSON Files (.json)|*.json"
            };
        
            if (picker.ShowDialog() == true)
            {
                return await File.ReadAllTextAsync(picker.FileName);
            }
            return string.Empty;
        }
    }

    #region WebBrowser
    public static class WebBrowserExtensions
    {
        public static void SuppressScriptErrors(this WebBrowser webBrowser, bool hide)
        {
            FieldInfo fiComWebBrowser = typeof(WebBrowser).GetField("_axIWebBrowser2", BindingFlags.Instance | BindingFlags.NonPublic);
            if (fiComWebBrowser == null)
                return;
            object objComWebBrowser = fiComWebBrowser.GetValue(webBrowser);
            if (objComWebBrowser == null)
                return;

            objComWebBrowser.GetType().InvokeMember("Silent", BindingFlags.SetProperty, null, objComWebBrowser, new object[] { hide });
        }
    }
    #endregion
}
