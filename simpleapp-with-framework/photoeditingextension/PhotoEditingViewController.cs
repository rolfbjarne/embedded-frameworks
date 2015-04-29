using System;

using CoreGraphics;
using Foundation;
using PhotosUI;
using Photos;
using UIKit;

namespace photoeditingextension
{
	public partial class PhotoEditingViewController : UIViewController, IPHContentEditingController
	{
		PHContentEditingInput input;

		public PhotoEditingViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			var view = new UILabel (new CGRect (0, 50, View.Bounds.Width, View.Bounds.Height));
			view.Text = MyFramework.CallFunction ();
			view.TextAlignment = UITextAlignment.Center;
			View.Add (view);

			var view2 = new UILabel (new CGRect (0, 100, View.Bounds.Width, View.Bounds.Height));
			view2.Text = SimpleFrameworkBinding.MyObjectiveCClass.CallMethod ();
			view2.TextAlignment = UITextAlignment.Center;
			View.Add (view2);

			view.BackgroundColor = UIColor.FromRGB (229, 255, 204); // light green

			base.ViewDidLoad ();
		}

		public bool ShouldShowCancelConfirmation {
			get { return true; }
		}

		public bool CanHandleAdjustmentData (PHAdjustmentData adjustmentData)
		{
			return false;
		}

		public void StartContentEditing (PHContentEditingInput contentEditingInput, UIImage placeholderImage)
		{
			input = contentEditingInput;
		}

		public void FinishContentEditing (Action<PHContentEditingOutput> completionHandler)
		{
			// Update UI to reflect that editing has finished and output is being rendered.

			// Render and provide output on a background queue.
			NSObject.InvokeInBackground (() => {
				// Create editing output from the editing input.
				var output = new PHContentEditingOutput (input);

				// Call completion handler to commit edit to Photos.
				completionHandler (output);

				// Clean up temporary files, etc.
			});
		}

		public void CancelContentEditing ()
		{
		}
	}
}

