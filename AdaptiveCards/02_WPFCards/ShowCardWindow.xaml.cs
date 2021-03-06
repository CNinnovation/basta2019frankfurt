﻿using AdaptiveCards;
using AdaptiveCards.Rendering.Wpf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFCards
{
    /// <summary>
    /// Interaction logic for ShowCardWindow.xaml
    /// </summary>
    public partial class ShowCardWindow : Window
    {
        public ShowCardWindow(string title, AdaptiveShowCardAction showCardAction)
        {
            InitializeComponent();
            var renderer = new AdaptiveCardRenderer();
            var renderedCard = renderer.RenderCard(showCardAction.Card);
            this.rootGrid.Children.Clear();
            this.rootGrid.Children.Add(renderedCard.FrameworkElement);
        }

    }
}
