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
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSTextField box { get; set; }

		[Outlet]
		AppKit.NSButton checkbox_outleter { get; set; }

		[Outlet]
		AppKit.NSComboBox combo_box { get; set; }

		[Action ("cancel_button:")]
		partial void cancel_button (Foundation.NSObject sender);

		[Action ("check_box_inAction:")]
		partial void check_box_inAction (Foundation.NSObject sender);

		[Action ("connect_to_server:")]
		partial void connect_to_server (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (box != null) {
				box.Dispose ();
				box = null;
			}

			if (checkbox_outleter != null) {
				checkbox_outleter.Dispose ();
				checkbox_outleter = null;
			}

			if (combo_box != null) {
				combo_box.Dispose ();
				combo_box = null;
			}
		}
	}
}
