// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MediAlertClientMac
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSButton connect_button { get; set; }

		[Outlet]
		AppKit.NSTextField connect_label { get; set; }

		[Outlet]
		AppKit.NSTextField message_box { get; set; }

		[Outlet]
		AppKit.NSButton send_button { get; set; }

		[Outlet]
		AppKit.NSTextField txt_box { get; set; }

		[Action ("connect_action:")]
		partial void connect_action (Foundation.NSObject sender);

		[Action ("send_action:")]
		partial void send_action (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (connect_button != null) {
				connect_button.Dispose ();
				connect_button = null;
			}

			if (message_box != null) {
				message_box.Dispose ();
				message_box = null;
			}

			if (send_button != null) {
				send_button.Dispose ();
				send_button = null;
			}

			if (txt_box != null) {
				txt_box.Dispose ();
				txt_box = null;
			}

			if (connect_label != null) {
				connect_label.Dispose ();
				connect_label = null;
			}
		}
	}
}
