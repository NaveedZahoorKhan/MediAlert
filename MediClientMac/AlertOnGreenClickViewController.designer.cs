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
	[Register ("AlertOnGreenClickViewController")]
	partial class AlertOnGreenClickViewController
	{
		[Outlet]
		AppKit.NSTextField label1 { get; set; }

		[Outlet]
		AppKit.NSTextField label2 { get; set; }

		[Outlet]
		AppKit.NSTextFieldCell label3 { get; set; }

		[Action ("button1:")]
		partial void button1 (Foundation.NSObject sender);
		
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
		}
	}
}
