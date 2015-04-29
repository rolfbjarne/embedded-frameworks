using CoreGraphics;
using Foundation;
using UIKit;

namespace HugeApp
{
	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;
		UIViewController vc;

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);

			vc = new UIViewController ();
			vc.View.BackgroundColor = UIColor.FromRGB (255, 204, 204); // light purple

			window.RootViewController = vc;
			window.MakeKeyAndVisible ();
			return true;
		}

		static void Main (string[] args)
		{
			UIApplication.Main (args, null, "AppDelegate");
		}
	}
}


