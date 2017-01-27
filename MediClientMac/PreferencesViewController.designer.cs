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
	[Register ("PreferencesViewController")]
	partial class PreferencesViewController
	{
		[Outlet]
		AppKit.NSButton alert_button_action { get; set; }

		[Outlet]
		AppKit.NSButton alert_button_outlet { get; set; }

		[Outlet]
		AppKit.NSButton both_button_outlet { get; set; }

		[Outlet]
		AppKit.NSButton checkBox1_outlet { get; set; }

		[Outlet]
		AppKit.NSComboBox comboBox1 { get; set; }

		[Outlet]
		AppKit.NSComboBox comboBox2 { get; set; }

		[Outlet]
		AppKit.NSButton ok_button_action { get; set; }

		[Outlet]
		AppKit.NSButton ok_button_outlet { get; set; }

		[Outlet]
		AppKit.NSTextField txtAlert { get; set; }

		[Outlet]
		AppKit.NSTextField txtClientName { get; set; }

		[Outlet]
		AppKit.NSTextField txtCurrentIP { get; set; }

		[Outlet]
		AppKit.NSTextField txtOk { get; set; }

		[Outlet]
		AppKit.NSTextField txtServerIP { get; set; }

		[Action ("both_button_action:")]
		partial void both_button_action (Foundation.NSObject sender);

		[Action ("button1:")]
		partial void button1 (Foundation.NSObject sender);

		[Action ("button2:")]
		partial void button2 (Foundation.NSObject sender);

		[Action ("checkBox1:")]
		partial void checkBox1 (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (checkBox1_outlet != null) {
				checkBox1_outlet.Dispose ();
				checkBox1_outlet = null;
			}

			if (txtOk != null) {
				txtOk.Dispose ();
				txtOk = null;
			}

			if (txtAlert != null) {
				txtAlert.Dispose ();
				txtAlert = null;
			}

			if (ok_button_outlet != null) {
				ok_button_outlet.Dispose ();
				ok_button_outlet = null;
			}

			if (alert_button_outlet != null) {
				alert_button_outlet.Dispose ();
				alert_button_outlet = null;
			}

			if (both_button_outlet != null) {
				both_button_outlet.Dispose ();
				both_button_outlet = null;
			}

			if (alert_button_action != null) {
				alert_button_action.Dispose ();
				alert_button_action = null;
			}

			if (ok_button_action != null) {
				ok_button_action.Dispose ();
				ok_button_action = null;
			}

			if (txtCurrentIP != null) {
				txtCurrentIP.Dispose ();
				txtCurrentIP = null;
			}

			if (txtServerIP != null) {
				txtServerIP.Dispose ();
				txtServerIP = null;
			}

			if (comboBox1 != null) {
				comboBox1.Dispose ();
				comboBox1 = null;
			}

			if (comboBox2 != null) {
				comboBox2.Dispose ();
				comboBox2 = null;
			}

			if (txtClientName != null) {
				txtClientName.Dispose ();
				txtClientName = null;
			}
		}
	}
}
