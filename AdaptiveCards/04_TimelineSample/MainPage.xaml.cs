using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.UserActivities;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
                    ""type"": ""Image"",
                    ""horizontalAlignment"": ""Center"",
                    ""size"": ""Large"",
                    ""url"": ""http://adaptivecards.io/content/cats/1.png""
                }]
            }";

            //string cardText = @"
            //{ 
            //    ""$schema"": ""http://adaptivecards.io/schemas/adaptive-card.json"", 
            //    ""type"": ""AdaptiveCard"", 
            //    ""backgroundImage"": ""https://46c4ts1tskv22sdav81j9c69-wpengine.netdna-ssl.com/wp-content/uploads/2017/11/eb5d872c743f8f54b957ff3f5ef3066b.jpg"", 
            //    ""body"": [
            //    { 
            //        ""type"": ""Container"",
            //        ""items"": [
            //         { 
            //            ""type"": ""TextBlock"",
            //            ""text"": ""Basta"",
            //            ""weight"": ""bolder"",
            //            ""size"": ""large"",
            //            ""wrap"": true,
            //            ""maxLines"": 3 
            //        }, 
            //        { 
            //            ""type"": ""TextBlock"", 
            //            ""text"": ""Showing a sample for BASTA!"", 
            //            ""size"": ""default"", 
            //            ""wrap"": true, 
            //            ""maxLines"": 3 
            //        }] 
            //    }]
            //}";

            try
            {
                UserActivityChannel channel = UserActivityChannel.GetDefault();
                UserActivity activity = await channel.GetOrCreateUserActivityAsync("MainPage");
                activity.VisualElements.DisplayText = "BASTA! Sample";
                activity.ActivationUri = new Uri("basta://MainPage");
                activity.VisualElements.Content = AdaptiveCardBuilder.CreateAdaptiveCardFromJson(cardText);
                await activity.SaveAsync();
                _session?.Dispose();
                _session = activity.CreateSession();
            }
            catch (Exception ex)
            {

            }
        }

        private UserActivitySession _session;
    }
}
