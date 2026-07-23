using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
/*
 این برنامه اصلی است 
در خصوص اپدیت اول باید نسخه برنامه بروزرسان را چک کند و آن را بروز کند
 بعد نسخه خودش را چک کند و و اگر نسخش بروز نبود اپدیتور رو صدا کند
 */
/*
 کارهایی که باید بکنی
تنظیمات برای فوت صفحه بزار
برای بروز رسانی خودش بتون برنامه بروز رسان رو بگیره یا آچدیت کنه
حذف چت های روز های قبل
راهاندازی تالار های متعدد
کلید که عوض شد باید خودش بره برای پروسه بازخوانی
 
 */
namespace ITYaar
{
    public partial class FRMMain : Form
    {
        public FRMMain()
        {
            InitializeComponent();
        } 
		#region "Def"
		public System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
		public string myIpAddress;
		public Boolean programmingMode = false;
		public string myVersion = "1.11.14050501";
		public string myComputerName = Environment.MachineName;
		public string myDirectory = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public string myName = System.IO.Path.GetFileName(Assembly.GetExecutingAssembly().Location);//OK
		public string myLogfile; 
		public string myConfigFile;
        public Dictionary<string, string> myConfigurationDictionary, ServerConfigDictiory;
		public string myMachinName = System.Environment.MachineName;
		private CodeDecode chrobj = new CodeDecode();
		public string chatFolder ;
		public string updatorAddress;
		public DateTime lastCheck = DateTime.MinValue;
		public HashSet<string> seenFiles = new HashSet<string>();
		public string MyUpdator = "AzUpdator.exe";
		//public string myPhisicalPath = Assembly.GetExecutingAssembly().Location;//OK
		//public string local_Update_Path;
		//public string Remote_Update_Path;
		#endregion
		private void FRMMain_Load(object sender, EventArgs e)
		{
			try
			{
				//////////////////////////////// تنظیمات اولیه ست شود
				this.Text = " برنامه آی تی یار نسخه = " + myVersion;
                myLogfile = myName + ".log";
				myConfigFile = myName + ".config.txt";
				TXTUserName.Text = myComputerName;
				//MessageBox.Show(myConfigFile);
				myIpAddress = GetLocalIP();
				/////////////////////////////// درصورت وجود لاگ فایل پاک شود و بعد دوباره ایجاد شود
				if (File.Exists(myLogfile))
				{
				    File.Delete(myLogfile);
					Thread.Sleep(50);
				    File.Create(myLogfile);
				}
                /////////////////////////////// فایل تنظیمات روچک میکنیم ببینیم هست یا نه
                if (!File.Exists(myConfigFile)) //اگه فایل کنارم نیست 
				{
					//این قسمت بعدا توسعه پیدا کنه
					AddLogToUI("فایل کانفیگ نیست که");
					//MessageBox.Show("فایل کانفیگ نیست که");
					killMeNow();
				}
				else //فایل تنظیمات کنارمه 
				{
					myConfigurationDictionary = retriveConfigFromFile(myConfigFile); //تنظیمات لود بشه
					chatFolder = myConfigurationDictionary["RoomsAddress"]; ; // مسیر پوشه چت
					//updatorAddress = myConfigurationDictionary["UpdatorAddress"]; ; // مسیر آپدیتور
					
					///////////////////////////////////////////////// چاپ متغیر ها

					AddLogToUI( "My Directory = " + myDirectory.ToString());
                    AddLogToUI( "My Name = " + myName.ToString());
                    AddLogToUI( "My Log file = " + myLogfile.ToString());
                    AddLogToUI( "My Ip Adress= " + myIpAddress);
                    AddLogToUI("My Config file = " + myConfigFile);
                    AddLogToUI("My Version = " + myVersion);
                }

				///////////////////   اول باید نسخه آپدیتور چک بشه اگر نیاز بود بروز رسانی کنه
				if (CheckForNewVersion())
				{
                    AddLogToUI("New version is available.");
					this.Text += "  نسخه جدید آماده دانلود و نصب است";
					//BTNUpdate.Visible = true;
                    //Update();
				}
                //////////////////     نسخه خود چک شود و اگر قدیمی بود آپدیتور را اجرا و خود را ببنندد
                //////////////////    اول استراتژی بچین
                /////////////////  بریم برای اجرای خوانش پیام ها
            }
            catch (Exception ee)
			{
				AddLogToUI( "Error: " + ee.Message);
				//AddLogToUI(ee.Message);
				throw;
			}
		}
        public Boolean CheckForNewVersion()
		{
			//ServerConfigDictiory = retriveConfigFromFile(myConfigurationDictionary["NewVersionAddress"] + "\\info.txt");
			ServerConfigDictiory = retriveConfigFromFile("\\\\172.24.0.9\\Public\\227\\ITYaarNewVersion" + "\\info.txt");
			
			string remoteNewVersion = ServerConfigDictiory["NewVersion"];
			//string remoteNewVersion = "\\\\172.24.0.9\\Public\\227\\ITYaarNewVersion";
			AddLogToUI("Remote New Version = " + remoteNewVersion);
			return remoteNewVersion != myVersion;
        }
        void CleanOldMessages(int rooz)
		{
			try
			{
				if (!Directory.Exists(chatFolder))
					return;

				var files = Directory.GetFiles(chatFolder, "*.txt");

				foreach (var file in files)
				{
					DateTime fileTime = File.GetLastWriteTime(file);

					if (fileTime < DateTime.Now.AddDays(rooz))
					{
						AddLogToUI(file.ToString() + "=> Deleted");
						File.Delete(file);
					}
				}
			}
			catch (Exception ex)
			{
				AddLogToUI( "CleanOldMessages Error: " + ex.Message);
			}
		}
		private void BTNSend_Click(object sender, EventArgs e)
		{
			//AddlogToFile( "Sending Message .");

			SendMessage();
			LoadMessages();
		}
		private void sendButton_Click(object sender, EventArgs e)
		{
			SendMessage();
		}
		void SendMessage()
		{
			////////////////// اول چک کن این متغیر توی تنظیمات هست یا نه
			//RoomsAddress
			/////////////////// اسمش اینجا ساخته بشه با تاریخ و ساعت و و کاربر و ای پی 
			string username = TXTUserName.Text.Trim();
			if (TXTUserName.Text == "")
			{
				username = "V" + myVersion + "--" + myIpAddress;
			}
			else
			{
				username = "V" + myVersion + "--" + myIpAddress + " -- " + TXTUserName.Text.Trim();
			}
			//string username = TXTUserName.Text.Trim() + new Random().Next(100, 999);


			// بعد رمز بشه بر توی یه فایل توی سرور بشینه

			// اینجا یه فایل باید ایجاد کنیم توی سرور
			string message = "خالی";
			if (string.IsNullOrWhiteSpace(ReadyBox.Text))
			{
				//return;
				message = username + " -- " + DateTime.Now.ToString("HH:mm:ss") + ": \n" + "اینتر الکی زد";
			}
			else
			{
				message = username + " -- " + DateTime.Now.ToString("HH:mm:ss") + ": \n" + ReadyBox.Text;

			}
			///// رمز گذاری
			message = chrobj.xxMixedWithKey(chrobj.xxAzTabeHaft(message, 10), TXTKey.Text.Trim());

			//// اینجا باید پیام خودم به باکس اضافه شود 
			string fname = DateTime.Now.ToString("yyyyMMdd_HHmmss_fff") + "_" + username + ".txt";

			try
			{
				//    AddlogToFile( "Sending...");
				//MessageBox.Show(chatFolder);
				File.WriteAllText(Path.Combine(chatFolder, fname), message);
				AddLogToUI("Sent...");
			}
			catch (Exception ex)
			{
				AddLogToUI("Error: Write error." + ex.Message);
				//MessageBox.Show("خطا در نوشتن پیام:\n" + ex.Message);
			}

			ReadyBox.Clear();
		}
		private void Refresh_Click(object sender, EventArgs e)
		{
			LoadMessages();
		}
		private void ReadyBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				SendMessage();
				e.SuppressKeyPress = true;
				LoadMessages();
			}
		}
		private void btnKillSession_Click(object sender, EventArgs e)
		{
			AddLogToUI( "Start killing " + myMachinName);
			string tempalikhan = btnKillSession.Text;
			btnKillSession.Enabled = false;
			btnKillSession.Text = "اندکی صبر";
			//System.Threading.Thread.Sleep(10000);

			killSession(myMachinName);

			//System.Threading.Thread.Sleep(500);
			btnKillSession.Enabled = true;
			btnKillSession.Text = tempalikhan;
		}
		private void AddLogToUI(string massage)
		{
            var fullMes = DateTime.Now + " : " + massage + Environment.NewLine;
            LB.Items.Add(fullMes);
			int lastIndex = LB.Items.Count - 1;
			if (lastIndex >= 0)
			{
				LB.SelectedIndex = lastIndex;
				LB.TopIndex = lastIndex; // باعث می‌شود آخرین آیتم دیده شود
			}
		}
		private void TimerLoadingMSG_Tick(object sender, EventArgs e)
		{
			//AddlogToFile( "TimerLoadingMSG Ticked.");
			LoadMessages();
		}
		private string killSession(string cn)
		{
			try
			{
				string xUser = "system";
				string xPassword = "manager";
				string xbrnch = "shoab";
				string txtSid = "";
				string txtSerial = "";
				String xConStr = "Provider= MSDAORA ;Data Source=" + xbrnch + ";User ID=" + xUser + ";Password=" +
								xPassword;
				string xQuery = "select vs.* from v$session vs " +
								"where program = 'MskM00000.exe'  " + //MskM00000.exe   prjBmf_Main.exe
								"and status<>'KILLED' " +
								"and username is not null " +
								"and terminal ='" + cn + "'";
				using (OleDbConnection xConn = new OleDbConnection(xConStr))
				{
					xConn.Open();
					AddLogToUI("ConnectionState = Open");
					using (OleDbCommand xCommand = new OleDbCommand(xQuery, xConn))
					{
						//TODO: May be you have parameters - assign them here...
						using (var xReader = xCommand.ExecuteReader())
						{
							AddLogToUI("Executereader is running.");
							while (xReader.Read())
							{
								txtSid = xReader.GetValue(1).ToString();
								txtSerial = xReader.GetValue(2).ToString();
								AddLogToUI("sid=" + txtSid + "   serial=" + txtSerial);

								string alterQuery = "ALTER SYSTEM KILL SESSION '" + txtSid + "," + txtSerial + "'";
								using (OleDbCommand yCommand = new OleDbCommand(alterQuery, xConn))
								{
									try
									{
										AddLogToUI("Alter kill session:" + yCommand.ExecuteNonQuery() + " records affected.");
									}
									catch (Exception ee)
									{
										AddLogToUI("Alter : " + ee.Message);
										//return "unsuccessfull";
										//throw;
									}
								}

							}
							AddLogToUI("Reader finished.");
						}

					}

				}
				return "successful";
			}
			catch (Exception e)
			{
				var st = new StackTrace();
				var me = st.GetFrame(0).GetMethod().Name;
				AddLogToUI(me + " : " + e.Message);
				return "Unsuccessfull";
				throw;
			}
		}
		private void StartTimerLoadingMSG()
		{
			TimerLoadingMSG.Enabled = true;
			//TimerLoadingMSG.Tick += (object s, EventArgs e1) => LoadMessages();
			TimerLoadingMSG.Start();
            AddLogToUI( "TimerLoadingMSG Started.");

		}
		private void TXTUserName_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				BTNLogin.Focus();
			}
		}
		private void BTNLogin_Click(object sender, EventArgs e)
		{

			seenFiles.Clear();
			RTBChatBox.Clear();
			AddLogToUI("New Key Has been set...");
			ReadyBox.Enabled = true;
			//BTNRefresh.Enabled = true;
			BTNSend.Enabled = true;
			LoadMessages();
			StartTimerLoadingMSG();
		}
		///////////////////////////////////////////////////////////////////////// Function
		private void killMeNow()
		{
			if (!programmingMode)
			{
				if (System.Windows.Forms.Application.MessageLoop)
				{
					// WinForms app
					System.Windows.Forms.Application.Exit();
				}
				else
				{
					// Console app
					System.Environment.Exit(1);
				}
			}
			else //programmingMode=true
			{
				AddLogToUI("KillMeNow:programmingMode=" + programmingMode.ToString());

			}
		}
		string GetLocalIP()
		{
			string ip = "";

			var host = Dns.GetHostEntry(Dns.GetHostName());

			foreach (var item in host.AddressList)
			{
				if (item.AddressFamily == AddressFamily.InterNetwork)
				{
					ip = item.ToString();
					break;
				}
			}

			return ip;
		}
		private Dictionary<string, string> retriveConfigFromFile(string thisFile) //if (File.Exists(myConfigFile))
        {
			try
			{
				//MessageBox.Show(thisFile);
				string[] lines = File.ReadAllLines(thisFile); 
                return lines.Select(l => l.Split('=')).ToDictionary(a => a[0], a => a[1]);
			}
			catch (Exception ee)
			{
				var st = new StackTrace();
				var me = st.GetFrame(0).GetMethod().Name;
				AddLogToUI( "ERROR: " + me + " : " + ee.Message);
				//return 
				throw;
			}
		}
        void LoadMessages()
		{
			/////////// بهتره اول فایل ها رو از آخرین فایلی که توی کش هست به بعد بیارم توی کش
			try
			{
				if (!Directory.Exists(chatFolder))
					return;

				var files = Directory
					.EnumerateFiles(chatFolder, "*.txt")
					.OrderBy(f => f);

				foreach (var file in files)
				{
					if (seenFiles.Contains(file))
						continue;

					string msg = File.ReadAllText(file);
					msg = chrobj.yyMixedWithKey(chrobj.yyAzTabeHaft(msg, 10), TXTKey.Text.Trim());

					AddMessageToUI(msg);

					seenFiles.Add(file);
				}
			}
			catch (Exception ex)
			{
				AddLogToUI( "Error: " + ex.Message);
			}
			
		}
		
		private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}
		private void راهنماToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}
		private void دربارهبرنامهToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FRMMyInfo f = new FRMMyInfo();
			f.ShowDialog();
		}
		private void BTNCleanOldMessages_Click(object sender, EventArgs e)
		{
			CleanOldMessages(-1);
			seenFiles.Clear();
			RTBChatBox.Clear();
			AddLogToUI( "Old MSG has been delete.");
			ReadyBox.Enabled = true;
			//BTNRefresh.Enabled = true;
			BTNSend.Enabled = true;
			LoadMessages();
			StartTimerLoadingMSG();
		}
        private void BTNUpdate_Click(object sender, EventArgs e)
        {
			// اول چک کن اپدیتور کنارت هست یا نه اگه نبود از سرور بگیرش
			
        }

        private void نسخجدیدToolStripMenuItem_Click(object sender, EventArgs e)
        {
			string Remote_Update_Path = myConfigurationDictionary["UpdatorAddress"];
			string sourceFile = Path.Combine(Remote_Update_Path, @"new.zip");
			string destinationFile = Path.Combine(myDirectory, "new.zip");
			//  اول چک کن اگر آپدیتور نیست یا بروز نیست بگیرش
			if (!File.Exists(MyUpdator)) // بگیرش اگه فایل اپدیتور کنارم نیست 
			{
				File.Copy(sourceFile, destinationFile, true);
				AddLogToUI("new.zip Copied ...");
				string zipPath = "new.zip";
				string extractPath = myDirectory; //"app";
				if (File.Exists(zipPath))
				{
					ZipFile.ExtractToDirectory(zipPath, extractPath);
					AddLogToUI("new.zip Extracted ...");
					File.Delete(zipPath);
					AddLogToUI("new.zip Deleted ...");
				}
				// داشتم اینجا رو مینوشتم
			}

				Process.Start(MyUpdator);
            killMeNow();
        }

		private void TXTKey_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				TXTUserName.Focus();

			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			CleanOldMessages(0);
			seenFiles.Clear();
			RTBChatBox.Clear();
			AddLogToUI("Old MSG has been delete.");
			ReadyBox.Enabled = true;
			//BTNRefresh.Enabled = true;
			BTNSend.Enabled = true;
			LoadMessages();
			StartTimerLoadingMSG();
		}

		private void btnKillSession_Click_1(object sender, EventArgs e)
		{

		}

		void AddMessageToUI(string msg)
		{
			if (InvokeRequired)
			{
				Invoke(new Action<string>(AddMessageToUI), msg);
				return;
			}

			RTBChatBox.AppendText(msg + Environment.NewLine);
			Thread.Sleep(5);
			RTBChatBox.SelectionStart = RTBChatBox.Text.Length;
			RTBChatBox.ScrollToCaret();
		}
	}

}
//string delTemp = DelFile(targetDirectory, myLogfile);
//AddLogToUI("Deleting " + myLogfile + " was " + delTemp + ".");
//MessageBox.Show(File.GetAttributes(myLogfile).ToString());
//SetDefaultValues();

//Boolean IsINFExist = isINFExistMethod();
//Boolean HasA2S = HasA2SMethod();
//Boolean isRightaddr = isRightaddrMethod();
//Boolean isOnNetwork = isOnNetworkMethod();
//Boolean isInDesktop = isInDesktopMethod();
//Boolean isOnSpace = isOnSpaceMethod();
//Boolean isVarpass = false;

/*
 if (!DoesFileExist(myDirectory, "VarPass.txt"))
 {
     AddLogToUI("Check for VarPass.txt  = False");
     if (!programmingMode)
     {
         MessageBox.Show("آدرس اجرا نادرست است");
         killMeNow();
     }


 }
 else
 {
     AddLogToUI("Check for VarPass.txt = True  ");
     DelFile(myDirectory, "VarPass.txt");
     isVarpass = true;
 }
*/

//if tmp exist rename it
/*
if (DoesFileExist(targetDirectory, "TahvilyaarAutoUpdate.exetmp"))
{
    delTemp = Path.Combine(targetDirectory, "TahvilyaarAutoUpdate.exe");
    AddLogToUI("Deleting file " + delTemp + " was " + DelFile(targetDirectory, "TahvilyaarAutoUpdate.exe"));
    string oldfile = Path.Combine(targetDirectory, "TahvilyaarAutoUpdate.exetmp");
    string newfile = Path.Combine(targetDirectory, "TahvilyaarAutoUpdate.exe");
    AddLogToUI("Moving file " + oldfile + " to " + newfile + " was " + moveFile(oldfile, newfile));
}
*/

//remote server
/*
remoteServer = findRemoteServer();
AddLogToUI("Remote server = " + remoteServer);
*/

/*       private Boolean isProgrammingMode()
{
    try
    {
        var myPhisicalPath = Assembly.GetExecutingAssembly().Location;
        var myDir = System.IO.Path.GetDirectoryName(myPhisicalPath);
        if (myPhisicalPath.Contains(@"repos"))
            return true;
        else
            return false;
    }
    catch (Exception ee)
    {
        var st = new StackTrace();
        var me = st.GetFrame(0).GetMethod().Name;
        sendERROR(me + " : " + ee.Message);
        return false;
        throw;
    }

}
*/

/*        private string moveFile(string xOld, string xNew)
{
    try
    {
        File.Move(xOld, xNew);
        return "successful";
    }
    catch (Exception ee)
    {
        var st = new StackTrace();
        var me = st.GetFrame(0).GetMethod().Name;
        sendERROR(me + " : " + ee.Message);
        return "unsuccessful";
        throw;
    }

}
*/

/*private Boolean isINFExistMethod()
{
    return DoesFileExist(myDirectory, "TahvilyariInfo.inf");
}*/
/*private Boolean HasA2SMethod()
{
    try
    {

        string[] xlines = File.ReadAllLines("TahvilyariInfo.inf");
        var xdict = xlines.Select(l => l.Split('=')).ToDictionary(a => a[0], a => a[1]);
        string ServerIP = xdict["ServerIP"];
        string sourcePath = "\\\\" + ServerIP + "\\\\" + xdict["LocalServerPath"]; //finding local server path 
        string ServerFile = sourcePath + "\\" + "lastupdate.txt";


        Ping ping = new Ping();
        PingReply pingresult = ping.Send(ServerIP);
        if (pingresult.Status.ToString() == "Success") return File.Exists(ServerFile);
        else return false;


    }
    catch (Exception ee)
    {
        var st = new StackTrace();
        var me = st.GetFrame(0).GetMethod().Name;
        sendERROR(me + " : " + ee.Message);
        return false;
        throw;
    }

}
*/
/*private Boolean isRightaddrMethod()
{
    try
    {
        if (myDirectory == targetDirectory && !programmingMode)
            return true;
        else
        {
            AddLogToUI("mypath                        <>                        targetpath  ");
            AddLogToUI(myPhisicalPath + " <> " + targetDirectory);
        }

        return false;
    }
    catch (Exception ee)
    {
        var st = new StackTrace();
        var me = st.GetFrame(0).GetMethod().Name;
        sendERROR(me + " : " + ee.Message);
        throw;
        return false;
    }
}*/
/*private Boolean isOnNetworkMethod()
{
    try
    {
        // var myPhisicalPath = Assembly.GetExecutingAssembly().Location;
        //var myDir = Path.GetDirectoryName(myPhisicalPath);
        if (myPhisicalPath.Contains(@"\\"))
            return true;
        else
            return false;
    }
    catch (Exception ee)
    {
        var st = new StackTrace();
        var me = st.GetFrame(0).GetMethod().Name;
        sendERROR(me + " : " + ee.Message);
        return false;
        throw;
    }
}*/
/*private Boolean isInDesktopMethod() 
{
    try
    {
        var myPhisicalPath = Assembly.GetExecutingAssembly().Location;
        var myDir = System.IO.Path.GetDirectoryName(myPhisicalPath);
        if (myPhisicalPath.Contains(@"desktop") || myPhisicalPath.Contains(@"Desktop"))
            return true;
        else
            return false;
    }
    catch (Exception ee)
    {
        var st = new StackTrace();
        var me = st.GetFrame(0).GetMethod().Name;
        sendERROR(me + " : " + ee.Message);
        return false;
        throw;
    }

}*/
/*private Boolean isOnSpaceMethod()
{
    try
    {
        //var myPhisicalPath = Assembly.GetExecutingAssembly().Location;
        //var myDir = Path.GetDirectoryName(myPhisicalPath);
        if (myPhisicalPath.Contains(@"p:\") || myPhisicalPath.Contains(@"P:\"))
            return true;
        else
            return false;
    }
    catch (Exception ee)
    {

        var st = new StackTrace();
        var me = st.GetFrame(0).GetMethod().Name;
        sendERROR(me + " : " + ee.Message);
        return false;
        throw;
    }
}*/
//private void AddLog0(string massage)
//{
//    try
//    {
//        string logfile = Path.Combine(targetDirectory , myLogfile);
//        var fullMes = DateTime.Now + " : " + massage + Environment.NewLine;
//        if (!programmingMode)
//        {
//            System.IO.File.AppendAllText(logfile, fullMes);
//        }

//        RTBLog.Items.Add(fullMes);

//        RTBLog.SelectedIndex = RTBLog.Items.Count - 1;
//        RTBLog.SetSelected(RTBLog.Items.Count - 1,false);
//        //progressBar1.Value = val;
//    }
//    catch (Exception e)
//    {
//        MessageBox.Show(" لاگ تحویل یار: مشکل دسترسی به مسیر پیش فرض \n" + e.Message);
//        killMeNow();
//        //throw;
//    }
//}
/*private Boolean closeProcess(string xProcess)
{
    Process[] allp = Process.GetProcesses();
    Boolean b = false;
    foreach (var item in allp)
    {
        if (item.ProcessName == xProcess)
        {
            item.Kill();
            b = true;
        }
    }

    return b;
}
*/


/*private string DelFile(string tarDir, string xFile)
{
    try
    {
        if (DoesFileExist(tarDir, xFile))
        {
            string xxfile = Path.Combine(tarDir, xFile);
            File.Delete(xxfile);
            return "Successfull";
        }
        else
        {
            {
                return "<the file doesn't exist>";
            }
        }
    }
    catch (Exception ee)
    {
        var st = new StackTrace();
        var me = st.GetFrame(0).GetMethod().Name;
        sendERROR(me + " : " + ee.Message);
        return "Unsuccessfull";
        throw;
    }
}
*/
/* private string findRemoteServer() //check access to localserver or remote server
{
    try
    {
        string sourcePath = "";
        if (!programmingMode)
        {
            string[] xlines = File.ReadAllLines("TahvilyariInfo.inf");
            var xdict = xlines.Select(l => l.Split('=')).ToDictionary(a => a[0], a => a[1]);
            sourcePath = "\\\\" + xdict["ServerIP"] + xdict["LocalServerPath"];
        }
        else
        {
            sourcePath = "\\\\10.84.80.2\\user3\\.linuz\\tahvilyaar\\";
        }
        return sourcePath;
    }
    catch (Exception e)
    {
        var st = new StackTrace();
        var me = st.GetFrame(0).GetMethod().Name;
        sendERROR(me + " : " + e.Message);
        return "\\\\10.84.80.2\\user3\\.linuz\\tahvilyaar\\";
        throw;
    }

}
*/
/*private string findMyIPaddr()
{


    return "";
}
*/

//private void sendERROR(string mes)
//{
//    //lblError.Text = mes + "\n";
//    AddLogToUI("Error : " + mes);
//}
/*private Boolean DoesFileExist(string tarDir, string fileName)
       {
           try
           {
               string sourceFile = System.IO.Path.Combine(tarDir, fileName);
               //MessageBox.Show(File.Exists(sourceFile).ToString());
               return File.Exists(sourceFile);
           }
           catch (Exception ee)
           {
               //sendERROR( ee.Message.ToString());
               var st = new StackTrace();
               var me = st.GetFrame(0).GetMethod().Name;
               sendERROR(me + " : " + ee.Message);
               return false;
               throw;

           }
       }
      */


//private Boolean AddlogToFile1( string massage)
//{
//	try
//	{
//		Thread.Sleep(50);

//		var fullMes = DateTime.Now + " : " + massage + Environment.NewLine;
//              //AddLogToUI(massage);
//              if (File.Exists(myLogfile))
//              {
//                  System.IO.File.AppendAllText(myLogfile, fullMes);
//                  //AddLogToUI("در فایل ثبت شد.");

//              }
//              else
//              {
//                  AddLogToUI("تابع دولاگ - فایل لاگ وجود ندارد");
//                  File.Create(myLogfile);
//                  AddLogToUI("تابع دولاگ - فایل لاگ ایجاد شد");
//                  System.IO.File.AppendAllText(myLogfile, fullMes);

//              }
//              return true;
//          }
//	catch (Exception ee)
//	{
//		AddLogToUI(" خطا در دسترسی به فایل لاگ" );
//		AddLogToUI(ee.Message);
//		return false;
//          }
//}