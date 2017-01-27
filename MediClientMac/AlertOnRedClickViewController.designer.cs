// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MediClientMac
{
	[Register ("AlertOnRedClickViewController")]
	partial class AlertOnRedClickViewController
	{
		[Outlet]
		AppKit.NSButton button1 { get; set; }

		[Outlet]
		AppKit.NSButton button2 { get; set; }

		[Outlet]
		AppKit.NSTextField label1 { get; set; }

		[Outlet]
		AppKit.NSTextField label2 { get; set; }

		[Outlet]
		AppKit.NSTextField label3 { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (label1 != null) {
				label1.Dispose ();
				label1 = null;
			}

			if (label2 != null) {
				label2.Dispose ();
				label2 = null;
			}

			if (label3 != null) {
				label3.Dispose ();
				label3 = null;
			}

			if (button1 != null) {
				button1.Dispose ();
				button1 = null;
			}

			if (button2 != null) {
				button2.Dispose ();
				button2 = null;
			}
		}
	}
}
