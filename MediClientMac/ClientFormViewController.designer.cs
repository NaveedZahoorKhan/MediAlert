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
	[Register ("ClientFormViewController")]
	partial class ClientFormViewController
	{
		[Outlet]
		AppKit.NSButton pictureBox1 { get; set; }

		[Action ("pictureBox1_actions:")]
		partial void pictureBox1_actions (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (pictureBox1 != null) {
				pictureBox1.Dispose ();
				pictureBox1 = null;
			}
		}

	}
}
