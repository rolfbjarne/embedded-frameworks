using System;

using WatchKit;
using Foundation;

namespace frameworkstestappWatchKitExtension
{
	public partial class NotificationController : WKUserNotificationInterfaceController
	{
		protected NotificationController (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public NotificationController ()
		{
			// Initialize variables here.
			// Configure interface objects here.
		}

		public override void WillActivate ()
		{
			// This method is called when the watch view controller is about to be visible to the user.
			Console.WriteLine ("{0} will activate", this);
		}

		public override void DidDeactivate ()
		{
			// This method is called when the watch view controller is no longer visible to the user.
			Console.WriteLine ("{0} did deactivate", this);
		}
	}
}

