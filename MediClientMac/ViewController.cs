using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using AppKit;
using Foundation;

namespace MediClientMac
{
	public partial class ViewController : NSViewController
	{
		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public ViewController()
		{
		}

		public static string ServerIpAddress = "";
		public static string IpAddressVal = "";

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Do any additional setup after loading the view.

		
		}
		public override void ViewDidAppear()
		{
			base.ViewDidAppear();
			ValueAdder();
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
		public void ValueAdder()
		{
			
			try
			{
				combo_box.UsesDataSource = false;
			
				foreach (NetworkInterface netInterface in NetworkInterface.GetAllNetworkInterfaces())
				{
					Console.WriteLine("Name: " + netInterface.Name);
					Console.WriteLine("Description: " + netInterface.Description);
					Console.WriteLine("Addresses: ");
					IPInterfaceProperties ipProps = netInterface.GetIPProperties();
					foreach (UnicastIPAddressInformation addr in ipProps.UnicastAddresses)
					{
						combo_box.Add(new NSString(addr.Address.ToString()));
						Console.WriteLine(" " + addr.Address.ToString());
					}
					Console.WriteLine("");
				}
				//IPHostEntry IPHost = Dns.GetHostEntry(Dns.GetHostName());

				//foreach (IPAddress item in IPHost.AddressList)
				//{
				//	combo_box.Add(new NSString(item.ToString()));
				//}

				Clients clt = GetLatestClient();
				if (!String.IsNullOrEmpty(clt.ServerIP) && !String.IsNullOrEmpty(clt.ipadd))
				{
					ServerIpAddress = clt.ServerIP;
					IpAddressVal = clt.ipadd;
				//	//ClientForm serverMaster = new ClientForm();
				//	//serverMaster.Show();
				//	//BeginInvoke(new MethodInvoker(Hide));
				}
			}
			catch (Exception ex)
			{
				NSAlert alert = new NSAlert();
				alert.MessageText = ex.GetType().ToString();
				alert.InformativeText = ex.Message;
				alert.RunModal();
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

				try
				{
					ServerIpAddress = box.StringValue;
					IpAddressVal = combo_box.SelectedValue.ToString();
					//this.Hide();
					//ClientForm serverMaster = new ClientForm();
					//serverMaster.Show();
					//DismissViewController(this);

					PerformSegue("ShowClientSegue", this);
				}
				catch (Exception ex)
				{
					ModalRunner(ex.GetType().ToString(), ex.Message);
				}


			}
			else
			{

				ModalRunner("Not Valid IP","Please enter server ip/select client ip."+ "Enter Server/Client IP");
			
			}

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
		private NSViewController _presentor;
		public NSViewController Presentor
		{
			get { return _presentor; }
			set { _presentor = value; }
		}
		partial void cancel_button(NSObject sender)
		{
			NSApplication.SharedApplication.Terminate(this);
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
