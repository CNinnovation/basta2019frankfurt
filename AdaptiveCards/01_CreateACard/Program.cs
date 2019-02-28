using AdaptiveCards;
using System;

namespace CreateACard
{
    class Program
    {
        static void Main(string[] args)
        {
            Card1Sample();
        }

        private static void Card1Sample()
        {
            var card = new AdaptiveCard(new AdaptiveSchemaVersion(1, 1));
            card.Body.Add(new AdaptiveTextBlock()
            {
                Text = "Hello, Card!",
                Size = AdaptiveTextSize.Large
            });

            card.Body.Add(new AdaptiveImage()
            {
                Url = new Uri("http://adaptivecards.io/content/cats/1.png"),
                Size = AdaptiveImageSize.Large
            });

            string json = card.ToJson();
            Console.WriteLine(json);
        }
    }
}
