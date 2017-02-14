// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using AppKit;

namespace MediClientMac
{
	public partial class AlertOnRedClickViewController : NSViewController
	{
		public AlertOnRedClickViewController (IntPtr handle) : base (handle)
		{
		}
		public override void ViewDidAppear()
		{
			base.ViewDidAppear();
		
		}
		public void ModalRunner(string message, string infoText)
		{
			InvokeOnMainThread(() =>
					{

						NSAlert alert = new NSAlert();
						alert.MessageText = message;
						alert.InformativeText = "Reason: " + infoText;
						alert.AlertStyle = NSAlertStyle.Informational;

						alert.RunModal();
					});
		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			try
			{
				Clients clt = new PreferencesViewController().GetLatestClient();
				if (clt != null)
				{
			//		label1.StringValue += clt.ClientName == null ? "Demo" : clt.ClientName;

			//		label2.StringValue = clt.AlertMessage == null ? "Demo" : clt.AlertMessage;
			//		label3.StringValue = DateTime.Now.ToShortTimeString().ToString() + " - " + DateTime.Now.ToShortDateString();
				}
			}
			catch (Exception ex)
			{
				ModalRunner(ex.GetType().ToString(), ex.Message);
			}

		}

		partial void close_button(NSObject sender)
		{
			
			DismissViewController(this);
		}
	

	}
}
