using System;
using System.Drawing;

using Foundation;
using UIKit;

namespace documentpickerextension
{
	public partial class DocumentPickerViewController : UIDocumentPickerExtensionViewController
	{
		public DocumentPickerViewController (IntPtr handle) : base (handle)
		{
		}

		public override void PrepareForPresentation (UIDocumentPickerMode mode)
		{
			// TODO: present a view controller appropriate for picker mode here
			base.PrepareForPresentation (mode);
		}

		partial void OpenDocument (NSObject sender)
		{
			var url = DocumentStorageUrl.Append ("Untitled.txt", false);

			// TODO: if you do not have a corresponding file provider, you must ensure that the URL returned here is backed by a file
			DismissGrantingAccess (url);
		}
	}
}
