using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Maui.Core;
using Microsoft.Maui.Platform;
#if IOS
using UIKit;
#endif

namespace SampleMaui
{
    public class BasicContentPage : ContentPage
    {
        public BasicContentPage()
        {
            Padding = new Thickness(0);
            BackgroundColor = Colors.White;

            Microsoft.Maui.Controls.NavigationPage.SetHasNavigationBar(this, false);
            this.Behaviors.Add(new StatusBarBehavior()
            {
                StatusBarColor = Colors.Green,
                StatusBarStyle = StatusBarStyle.LightContent
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

#if IOS
            // Workaround for iPhone 14: https://developer.apple.com/forums/thread/715417

            if (UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
            {
                var window = UIKit.UIApplication.SharedApplication.Windows.FirstOrDefault();
                var topPadding = window?.SafeAreaInsets.Top ?? 0;

                var statusBar = new UIView(new CoreGraphics.CGRect(0, 0, UIScreen.MainScreen.Bounds.Size.Width, topPadding))
                {
                    BackgroundColor = Colors.Green.ToPlatform()
                };

                var view = UIApplication.SharedApplication.Windows.FirstOrDefault(x => x.IsKeyWindow);
                view?.AddSubview(statusBar);
            }

#endif
        }
    }
}

