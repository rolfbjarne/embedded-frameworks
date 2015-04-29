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
			View.BackgroundColor = UIColor.FromRGB (204, 255, 255); // light blue

			var view = new UILabel (new CGRect (0, 50, View.Bounds.Width, View.Bounds.Height));
			view.Text = MyFramework.CallFunction ();
			view.TextAlignment = UITextAlignment.Center;
			View.Add (view);

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

