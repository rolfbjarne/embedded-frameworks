using System;
using System.Runtime.InteropServices;

public static class MyFramework {
	public static string CallFunction ()
	{
		return Marshal.PtrToStringAuto (functionInFramework ());
	}

	[DllImport ("@rpath/MyFramework.framework/MyFramework")]
	static extern IntPtr functionInFramework ();
}

