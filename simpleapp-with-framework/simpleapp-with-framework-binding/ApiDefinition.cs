using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace SimpleFrameworkBinding
{
	[BaseType (typeof (NSObject))]
	public interface MyObjectiveCClass {
		[Static]
		[Export ("callMethod")]
		string CallMethod ();
	}
}

