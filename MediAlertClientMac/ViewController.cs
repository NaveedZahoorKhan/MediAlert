using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using AppKit;
using Foundation;

namespace MediAlertClientMac
{
	public partial class ViewController : NSViewController
	{
		public ViewController(IntPtr handle) : base(handle)
		{
		}
		TcpClient tcpclnt = new TcpClient();
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			base.AwakeFromNib();
			message_box.StringValue = "Please Enter a message";
			// Do any additional setup after loading the view.
		}
		partial void send_action(NSObject sender)
		{
			String str = message_box.StringValue;
			Stream stm = tcpclnt.GetStream();

			ASCIIEncoding asen = new ASCIIEncoding();
			byte[] ba = asen.GetBytes(str);
			connect_label.StringValue = "Transmitting.....";

			stm.Write(ba, 0, ba.Length);

			byte[] bb = new byte[100];
			int k = stm.Read(bb, 0, 100);

			for (int i = 0; i < k; i++)
				txt_box.StringValue += Convert.ToChar(bb[i]);

			tcpclnt.Close();
			

		}
		partial void connect_action(NSObject sender)
		{
			
			connect_label.StringValue = "Connecting....";
			tcpclnt.Connect("192.168.1.103", 8001);
			//tcpclnt.Connect("127.0.0.1", 8002);
			connect_label.StringValue = "Connected";
		}

		public override NSObject RepresentedObject
		{
			get
			{
				return base.RepresentedObject;
			}
			set
			{
				base.RepresentedObject = value;
				// Update the view, if already loaded.
			}
		}
	}
}
