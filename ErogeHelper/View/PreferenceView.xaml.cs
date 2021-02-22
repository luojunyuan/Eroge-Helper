﻿using ErogeHelper.View.Pages;
using ModernWpf.Controls;
using ModernWpf.Media.Animation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ErogeHelper.View
{
    /// <summary>
    /// PreferenceView.xaml 的交互逻辑
    /// </summary>
    public partial class PreferenceView : Window
    {
        public PreferenceView()
        {
            InitializeComponent();

            ContentFrame.Navigated += OnNavigated;
            PageNavigate("general", new EntranceNavigationTransitionInfo());
        }

        private readonly List<(string Tag, Type PageType)> pages = new()
        {
            ("general", typeof(GeneralPage)),
            ("mecab", typeof(MecabPage)),
            ("hook", typeof(HookPage)),
            ("trans", typeof(TransPage)),
            ("log", typeof(LogPage)),

            ("about", typeof(AboutPage)),
        };

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItem != null)
            {
                var navItemTag = args.SelectedItemContainer.Tag.ToString()!;
                PageNavigate(navItemTag, args.RecommendedNavigationTransitionInfo);
            }
        }

        private void PageNavigate(string navItemTag, NavigationTransitionInfo info)
        {
            var item = pages.FirstOrDefault(p => p.Tag.Equals(navItemTag));
            Type pageType = item.PageType;

            // if not same page
            if (pageType != null && ContentFrame!.CurrentSourcePageType != pageType)
            {
                // FIXME: Navigate() lead memory leak
                ContentFrame.Navigate(pageType, null, info);
                //ContentFrame.DataContext = item.DataContext;
            }
        }

        private void OnNavigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            NavView.IsBackEnabled = ContentFrame.CanGoBack;
            Type sourcePageType = ContentFrame.SourcePageType;
            if (sourcePageType != null)
            {
                var item = pages.FirstOrDefault(p => p.PageType == sourcePageType);

                NavView.SelectedItem = NavView.FooterMenuItems
                    .OfType<NavigationViewItem>().
                    FirstOrDefault(n => n.Tag.Equals(item.Tag)) ??
                    NavView.MenuItems
                    .OfType<NavigationViewItem>()
                    .FirstOrDefault(n => n.Tag.Equals(item.Tag));

                HeaderBlock.Text =
                    ((NavigationViewItem)NavView.SelectedItem!).Content?.ToString();
            }
        }
    }
}
