using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.UserActivities;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Shell;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TimelineSample
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

        private async void OnCreateActivity(object sender, RoutedEventArgs e)
        {
            string cardText = @"{
                ""type"": ""AdaptiveCard"",
                ""version"": ""1.0"",
                ""$schema"": ""http://adaptivecards.io/schemas/adaptive-card.json"",
                ""body"": [{
                    ""type"": ""TextBlock"",
                    ""horizontalAlignment"": ""Center"",
                    ""size"": ""Large"",
                    ""text"": ""Hello BASTA!""
                },
                {
                    ""type"": ""TextBlock"",
                    ""horizontalAlignment"": ""Left"",
                    ""size"": ""Small"",
                    ""text"": ""This is a sample for BASTA! 2019in Frankfurt"",
                    ""maxLines"": 3,
                    ""wrap"": true
                }]
            }";

            try
            {
                UserActivityChannel channel = UserActivityChannel.GetDefault();
                UserActivity activity = await channel.GetOrCreateUserActivityAsync("MainPage5");
                activity.VisualElements.DisplayText = "BASTA! Sample";
                activity.ActivationUri = new Uri("basta://MainPage/1");
                var card = AdaptiveCardBuilder.CreateAdaptiveCardFromJson(cardText);
                activity.VisualElements.Content = card;
                await activity.SaveAsync();
                _session?.Dispose();
                _session = activity.CreateSession();
            }
            catch (Exception ex)
            {
                new MessageDialog(ex.Message);
            }
        }

        private UserActivitySession _session;
    }
}
