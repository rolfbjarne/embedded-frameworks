using System;
using System.IO;

using Foundation;
using UIKit;

namespace fileproviderextension
{
	[Register ("FileProvider")]
	public class FileProvider : NSFileProviderExtension
	{
		public FileProvider ()
		{
			NSError error;

			FileCoordinator = new NSFileCoordinator ();
			FileCoordinator.PurposeIdentifier = ProviderIdentifier;

			FileCoordinator.CoordinateWrite (DocumentStorageUrl, 0, out error, (newUrl) => {
				NSError err;

				// ensure that the DocumentStorageUrl actually exists
				NSFileManager.DefaultManager.CreateDirectory (newUrl, true, null, out err);
			});
		}

		public NSFileCoordinator FileCoordinator {
			get;
			private set;
		}

		public override void ProvidePlaceholderAtUrl (NSUrl url, Action<NSError> completionHandler)
		{
			var fileName = Path.GetFileName (url.Path);
			var placeholder = NSFileProviderExtension.GetPlaceholderUrl (DocumentStorageUrl.Append (fileName, false));
			NSNumber size = new NSNumber (0);
			NSError error;

			// TODO: get file size for file at <url> from model

			FileCoordinator.CoordinateWrite (placeholder, 0, out error, (newUrl) => {
				var metadata = new NSMutableDictionary ();
				NSError err = null;

				metadata.Add (NSUrl.FileSizeKey, size);

				NSFileProviderExtension.WritePlaceholder (placeholder, metadata, ref err);
			});

			if (completionHandler != null)
				completionHandler (null);
		}

		public override void StartProvidingItemAtUrl (NSUrl url, Action<NSError> completionHandler)
		{
			NSError error, fileError = null;
			NSData fileData;

			// TODO: get the file data for file at <url> from model
			fileData = new NSData ();

			FileCoordinator.CoordinateWrite (url, 0, out error, (newUrl) => fileData.Save (newUrl, 0, out fileError));

			if (error != null)
				completionHandler (error);
			else
				completionHandler (fileError);
		}

		public override void ItemChangedAtUrl (NSUrl url)
		{
			// Called at some point after the file has changed; the provider may then trigger an upload

			// TODO: mark file at <url> as needing an update in the model; kick off update process
			Console.WriteLine ("Item changed at URL {0}", url);
		}

		public override void StopProvidingItemAtUrl (NSUrl url)
		{
			// Called after the last claim to the file has been released. At this point, it is safe for the file provider to remove the content file.
			// Care should be taken that the corresponding placeholder file stays behind after the content file has been deleted.
			NSError err;

			FileCoordinator.CoordinateWrite (url, NSFileCoordinatorWritingOptions.ForDeleting, out err, (newUrl) => {
				NSError error;

				NSFileManager.DefaultManager.Remove (newUrl, out error);
			});

			ProvidePlaceholderAtUrl (url, null);
		}
	}
}
