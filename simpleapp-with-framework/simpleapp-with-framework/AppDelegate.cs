using CoreGraphics;
using Foundation;
using UIKit;

namespace SimpleFrameworkTest
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
			vc.View.BackgroundColor = UIColor.FromRGB (229, 255, 204); // light green
				
			var view = new UILabel (new CGRect (0, 0, window.Bounds.Width, window.Bounds.Height));
			view.Text = MyFramework.CallFunction ();
			view.TextAlignment = UITextAlignment.Center;
			vc.View.Add (view);

			var view2 = new UILabel (new CGRect (0, 50, window.Bounds.Width, window.Bounds.Height));
			view2.Text = SimpleFrameworkBinding.MyObjectiveCClass.CallMethod ();
			view2.TextAlignment = UITextAlignment.Center;
			vc.View.Add (view2);

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


