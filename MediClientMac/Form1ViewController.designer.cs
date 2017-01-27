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
	[Register ("Form1ViewController")]
	partial class Form1ViewController
	{
		[Outlet]
		AppKit.NSButton button_image_outlet { get; set; }

		[Action ("button_image_action:")]
		partial void button_image_action (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (button_image_outlet != null) {
				button_image_outlet.Dispose ();
				button_image_outlet = null;
			}
		}
	}
}
