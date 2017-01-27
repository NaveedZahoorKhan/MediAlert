using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using AppKit;
using Foundation;

namespace MediClientMac
{
	public partial class ViewController : NSViewController
	{
		public ViewController(IntPtr handle) : base(handle)
		{
		}
		public static string ServerIpAddress = "192.168.56.1";
		public static string IpAddressVal = "192.168.56.1";

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			AwakeFromNib();
			// Do any additional setup after loading the view.

		
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
		public override void AwakeFromNib()
		{
			base.AwakeFromNib();
			try
			{
				
				IPHostEntry IPHost = Dns.GetHostByName(Dns.GetHostName());
				combo_box.UsesDataSource = true;
				combo_box.Add(new NSString("127.0.0.1"));
				foreach (IPAddress item in IPHost.AddressList)
				{
					combo_box.Add(new NSString(item.ToString()));
				}

				Clients clt = GetLatestClient();
				if (!String.IsNullOrEmpty(clt.ServerIP) && !String.IsNullOrEmpty(clt.ipadd))
				{
					ServerIpAddress = clt.ServerIP;
					IpAddressVal = clt.ipadd;
					//ClientForm serverMaster = new ClientForm();
					//serverMaster.Show();
					//BeginInvoke(new MethodInvoker(Hide));
				}
			}
			catch (Exception ex)
			{
				Debug.Write(ex.Message);
			}
		}
		string filename = "MediText.mdl";

		public void WriteJsonFile(Clients clt)
		{
			if (File.Exists(filename))
			{
				string fileData = FileHelper.ReadFileData(filename);
				string jsondata;
				if (String.IsNullOrEmpty(fileData))
				{
					jsondata = JsonHelper<Clients>.JsonSerializer(clt);
				}
				else
				{
					FileHelper.FlushFile(filename);
					jsondata = JsonHelper<Clients>.JsonSerializer(clt);
				}
				FileHelper.WriteFileData(filename, jsondata);
			}
			else
			{
				using (var stream = File.Create(filename)) { }
				string fileData = FileHelper.ReadFileData(filename);
				string jsondata;
				if (String.IsNullOrEmpty(fileData))
				{
					jsondata = JsonHelper<Clients>.JsonSerializer(clt);
				}
				else
				{
					FileHelper.FlushFile(filename);
					jsondata = JsonHelper<Clients>.JsonSerializer(clt);
				}
				FileHelper.WriteFileData(filename, jsondata);

			}
		}
		partial void connect_to_server(NSObject sender)
		{
			
			if (!String.IsNullOrEmpty(box.StringValue) && combo_box.SelectedIndex > -1)
			{

				if (checkbox_outleter.State == NSCellStateValue.On)
				{
					Clients clt = new Clients();
					clt.ServerIP = box.StringValue;
					clt.ipadd = combo_box.SelectedValue.ToString();
					WriteJsonFile(clt);
				}

				ServerIpAddress = box.StringValue;
				IpAddressVal = combo_box.SelectedValue.ToString();
				//this.Hide();
				//ClientForm serverMaster = new ClientForm();
				//serverMaster.Show();
			}
			else
			{
				NSAlert alert = new NSAlert();
				alert.MessageText=("Please enter server ip/select client ip."+ "Enter Server/Client IP");
				alert.RunModal();
			}

		}
		private NSViewController _presentor;
		public NSViewController Presentor
		{
			get { return _presentor; }
			set { _presentor = value; }
		}
		partial void cancel_button(NSObject sender)
		{
			Presentor.DismissViewController(this);
		}

		public Clients GetLatestClient()
		{
			Clients clt = new Clients();
			string fileData = FileHelper.ReadFileData(filename);
			if (!String.IsNullOrEmpty(fileData))
			{
				clt = JsonHelper<Clients>.JsonDeserialize(fileData);
				if (String.IsNullOrEmpty(clt.AlertMessage))
				{
					clt.AlertMessage = "Under Duress";
				}
				if (String.IsNullOrEmpty(clt.OkMessage))
				{
					clt.OkMessage = "No longer under Duress";
				}
			}
			else
			{
				clt = null;
			}
			return clt;
		}

	}
}
