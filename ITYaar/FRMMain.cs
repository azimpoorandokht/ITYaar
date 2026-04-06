using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
using System.Reflection;
using System.Threading;
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
		public string myVersion = "14050115.0000";
		public string myFullPhisicalPath = Assembly.GetExecutingAssembly().Location;
		public string myPhisicalPath = Assembly.GetExecutingAssembly().Location;//OK
		public string myDirectory = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		public string myFileName = System.IO.Path.GetFileName(Assembly.GetExecutingAssembly().Location);
		public string myName = System.IO.Path.GetFileName(Assembly.GetExecutingAssembly().Location);//OK
		public string local_Update_Path;
		public string Remote_Update_Path;
		public string Target1;
		public enumRunningMode runningMode = enumRunningMode.NotSet;
		public string myLogfile = "ITYaar.log.txt";
		public Dictionary<string, string> myConfigurationDictionary, remoteConfigDictionary;
		public enum enumRunningMode // بر نامه دو حالت اجرا دارد یکی در لبتاب من و در محیط آزمایشگاهی و دیگری در محیط واقعی
		{
			Develop_Mode = 0,
			Real_Environment_Mode = 1,
			NotSet = 3
		}
		public string myRemoteServer = "10.84.80.2";
		public string myMachinName = System.Environment.MachineName;
		private CodeDecode chrobj = new CodeDecode();
		public string chatFolder = "";
		public DateTime lastCheck = DateTime.MinValue;
		public HashSet<string> seenFiles = new HashSet<string>();

		#endregion
		public enumRunningMode GetRunnigMode()
		{
			// اینو بعدا باید بنویسی که آیتم رو از فایل تنظیمات بخونه فعلا صفر میدیم
			//0 = تست
			// 1 = محیط واقعی
			return enumRunningMode.Develop_Mode;
		}
		/////////////////////////////////////////////////////////////////////Form events
		private void FRMMain_Load(object sender, EventArgs e)
		{
			try
			{
				//////////////////////////////// تنظیمات اولیه ست شود
				this.Text = " برنامه تحویل یار نسخه = " + myVersion;
				myIpAddress = GetLocalIP();

				/////////////////////////////// درصورت وجود لاگ فایل پاک شود
				//if (File.Exists(myLogfile))
				//{
				//    File.Delete(myLogfile);
				//    File.Create(myLogfile);
				//}
				/////////////////////////////// فایل GlobalValuesText روچک میکنیم ببینیم هست یا نه
				if (!File.Exists("GlobalValuesText.txt")) //اگه فایل کنارم نیست ینی تو مود اجرای واقعی هستم دیگه
				{
					//این قسمت بعدا توسعه پیدا کنه
					DoLogEvent(enumRunningMode.Real_Environment_Mode, "Config file does not exist.");
				}
				else //فایل تنظیمات کنارمه 
				{
					myConfigurationDictionary = retriveMyConfiguration(); //تنظیمات لود بشه
																		  //runningMode = GetRunnigMode();//تعیین حالت اجرا
					if (myConfigurationDictionary["runningMode"] == "1")  //real environment mode
					{
						runningMode = enumRunningMode.Real_Environment_Mode;
						//local_Update_Path = myConfigurationDictionary["RealEnv_local_Update_Path"];
						//Remote_Update_Path = myConfigurationDictionary["RealEnv_Remote_Update_Path"];
						Target1 = myConfigurationDictionary["Target1"];
						chatFolder = myConfigurationDictionary["RoomsAddress"]; ; // مسیر پوشه چت
					}
					else  // developer mode
					{
						runningMode = enumRunningMode.Develop_Mode;
						//local_Update_Path = myConfigurationDictionary["Developer_Mode_Update_Path"];
						//Remote_Update_Path = myConfigurationDictionary["Developer_Mode_Update_Path"];
						Target1 = myConfigurationDictionary["Target1"];
						chatFolder = myConfigurationDictionary["RoomsAddress"]; ; // مسیر پوشه چت
					}
					///////////////////////////////////////////////// چاپ متغیر ها
					DoLogEvent(runningMode, "Running Mode = " + runningMode.ToString());
					DoLogEvent(runningMode, "myPhisicalPath = " + myPhisicalPath.ToString());
					DoLogEvent(runningMode, "myDirectory = " + myDirectory.ToString());
					DoLogEvent(runningMode, "myName = " + myName.ToString());
					//DoLogEvent(runningMode, "RealEnv_local_Update_Location = " + local_Update_Path.ToString());
					//DoLogEvent(runningMode, "RealEnv_Remote_Update_Location = " + Remote_Update_Path.ToString());
					DoLogEvent(runningMode, "myLogfile = " + myLogfile.ToString());
					DoLogEvent(runningMode, "My version is " + myVersion);
					//DoLogEvent(runningMode, "Chat folder= " + chatFolder);
					DoLogEvent(runningMode, "My Ip Adress= " + myIpAddress);
				}
				///////////////////   اول باید نسخه آپدیتور چک بشه اگر نیاز بود بروز رسانی کنه
				//////////////////     نسخه خود چک شود و اگر قدیمی بود آپدیتور را اجرا و خود را ببنندد
				//////////////////    اول استراتژی بچین
				/////////////////  بریم برای اجرای خوانش پیام ها



			}
			catch (Exception ee)
			{
				DoLogEvent(runningMode, "Error: " + ee.Message);
				//AddLog(ee.Message);
				throw;
			}
		}
		private void BTNLogin_Click(object sender, EventArgs e)
		{

			LoadMessages();
			StartTimerLoadingMSG();
			ReadyBox.Enabled = true;
			BTNRefresh.Enabled = true;
			BTNSend.Enabled = true;
		}
		private void BTNSend_Click(object sender, EventArgs e)
		{
			//DoLogEvent(runningMode, "Sending Message .");

			SendMessage();
			LoadMessages();
		}
		private void sendButton_Click(object sender, EventArgs e)
		{
			SendMessage();
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
			DoLogEvent(runningMode, "Start killing " + myMachinName);
			string tempalikhan = btnKillSession.Text;
			btnKillSession.Enabled = false;
			btnKillSession.Text = "اندکی صبر";
			//System.Threading.Thread.Sleep(10000);

			killSession(myMachinName);

			//System.Threading.Thread.Sleep(500);
			btnKillSession.Enabled = true;
			btnKillSession.Text = tempalikhan;
		}
		private void AddLog(string x)
		{
			LB.Items.Add(x);
			int lastIndex = LB.Items.Count - 1;
			if (lastIndex >= 0)
			{
				LB.SelectedIndex = lastIndex;
				LB.TopIndex = lastIndex; // باعث می‌شود آخرین آیتم دیده شود
			}
		}
		private void TimerLoadingMSG_Tick(object sender, EventArgs e)
		{
			DoLogEvent(runningMode, "TimerLoadingMSG Ticked.");
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
					AddLog("ConnectionState = Open");
					using (OleDbCommand xCommand = new OleDbCommand(xQuery, xConn))
					{
						//TODO: May be you have parameters - assign them here...
						using (var xReader = xCommand.ExecuteReader())
						{
							AddLog("Executereader is running.");
							while (xReader.Read())
							{
								txtSid = xReader.GetValue(1).ToString();
								txtSerial = xReader.GetValue(2).ToString();
								AddLog("sid=" + txtSid + "   serial=" + txtSerial);

								string alterQuery = "ALTER SYSTEM KILL SESSION '" + txtSid + "," + txtSerial + "'";
								using (OleDbCommand yCommand = new OleDbCommand(alterQuery, xConn))
								{
									try
									{
										AddLog("Alter kill session:" + yCommand.ExecuteNonQuery() + " records affected.");
									}
									catch (Exception ee)
									{
										AddLog("Alter : " + ee.Message);
										//return "unsuccessfull";
										//throw;
									}
								}

							}
							AddLog("Reader finished.");
						}

					}

				}
				return "successful";
			}
			catch (Exception e)
			{
				var st = new StackTrace();
				var me = st.GetFrame(0).GetMethod().Name;
				AddLog(me + " : " + e.Message);
				return "Unsuccessfull";
				throw;
			}
		}
		private void StartTimerLoadingMSG()
		{
			TimerLoadingMSG.Enabled = true;
			//TimerLoadingMSG.Tick += (object s, EventArgs e1) => LoadMessages();
			TimerLoadingMSG.Start();
			DoLogEvent(runningMode, "TimerLoadingMSG Started.");

		}
		private void DoLogEvent(enumRunningMode myRunningMode, string massage)
		{
			try
			{
				Thread.Sleep(100);

				var fullMes = DateTime.Now + " : " + massage + Environment.NewLine;
				if (myRunningMode == enumRunningMode.Develop_Mode) // محیط اجرای برنامه نویس
				{
					// بعدا ممکنه بخوای اینو تغییر بدی
				}
				else ///محید اجرای واقعی
				{
					string logfile = Path.Combine(myDirectory, myLogfile);
					if (!File.Exists(logfile))
					{
						File.Create(logfile);
					}
					System.IO.File.AppendAllText(logfile, fullMes);
				}
				AddLog(fullMes);
			}
			catch (Exception ee)
			{
				MessageBox.Show(" لاگ آپدیت : مشکل دسترسی به مسیر پیش فرض \n" + ee.Message);
				//killMeNow();
			}
		}
		private void TXTUserName_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				LoadMessages();
				StartTimerLoadingMSG();
				ReadyBox.Enabled = true;
				BTNRefresh.Enabled = true;
				BTNSend.Enabled = true;
			}
		}
		private void BTNTimersStop_Click(object sender, EventArgs e)
		{
			seenFiles.Clear();
			RTBChatBox.Clear();
            DoLogEvent(runningMode, "New Key Has been set...");
            ReadyBox.Enabled = true;
            BTNRefresh.Enabled = true;
            BTNSend.Enabled = true;
            LoadMessages();
            StartTimerLoadingMSG();
            //ReadyBox.Enabled = false;
            //BTNRefresh.Enabled = false;
            //BTNSend.Enabled = false;
            //DoLogEvent(runningMode, "Timers Stoped.");

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
				AddLog("KillMeNow:programmingMode=" + programmingMode.ToString());

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
		private Dictionary<string, string> retriveMyConfiguration() //if (File.Exists("GlobalValuesText.txt"))
		{
			try
			{
				string[] lines = File.ReadAllLines("GlobalValuesText.txt");
				return lines.Select(l => l.Split('=')).ToDictionary(a => a[0], a => a[1]);
			}
			catch (Exception ee)
			{
				var st = new StackTrace();
				var me = st.GetFrame(0).GetMethod().Name;
				DoLogEvent(runningMode, "ERROR: " + me + " : " + ee.Message);

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
				DoLogEvent(runningMode, "Error: " + ex.Message);
			}
			
		}
		void SendMessage()
		{
			////////////////// اول چک کن این متغیر توی تنظیمات هست یا نه
			//RoomsAddress
			/////////////////// اسمش اینجا ساخته بشه با تاریخ و ساعت و و کاربر و ای پی 
			string username = TXTUserName.Text.Trim();
			if (TXTUserName.Text == "")
			{
				username = myIpAddress;
			}
			else
			{
				username = myIpAddress +" " + TXTUserName.Text.Trim() ;
			}
			//string username = TXTUserName.Text.Trim() + new Random().Next(100, 999);
			

			// بعد رمز بشه بر توی یه فایل توی سرور بشینه

			// اینجا یه فایل باید ایجاد کنیم توی  216 پابلیک
			string message = "خالی";
			if (string.IsNullOrWhiteSpace(ReadyBox.Text))
			{
				//return;
				message = username + ": \n" + "Empty";
			}
			else
			{
				message = username + ": \n" + ReadyBox.Text;

			}
			///// رمز گذاری
			message = chrobj.xxMixedWithKey(chrobj.xxAzTabeHaft(message, 10), TXTKey.Text.Trim());

			//// اینجا باید پیام خودم به باکس اضافه شود 
			string fname = DateTime.Now.ToString("yyyyMMdd_HHmmss_fff") + "_" + username + ".txt";

			try
			{
				//    DoLogEvent(runningMode, "Sending...");
				File.WriteAllText(Path.Combine(chatFolder, fname), message);
				DoLogEvent(runningMode, "Sent...");
			}
			catch (Exception ex)
			{
				DoLogEvent(runningMode, "Error: Write error." + ex.Message);
				//MessageBox.Show("خطا در نوشتن پیام:\n" + ex.Message);
			}

			ReadyBox.Clear();
		}
		void AddMessageToUI(string msg)
		{
			if (InvokeRequired)
			{
				Invoke(new Action<string>(AddMessageToUI), msg);
				return;
			}

			RTBChatBox.AppendText(msg + Environment.NewLine);
			Thread.Sleep(50);
			RTBChatBox.SelectionStart = RTBChatBox.Text.Length;
			RTBChatBox.ScrollToCaret();
		}
	}

}
//string delTemp = DelFile(targetDirectory, myLogfile);
//AddLog("Deleting " + myLogfile + " was " + delTemp + ".");
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
     AddLog("Check for VarPass.txt  = False");
     if (!programmingMode)
     {
         MessageBox.Show("آدرس اجرا نادرست است");
         killMeNow();
     }


 }
 else
 {
     AddLog("Check for VarPass.txt = True  ");
     DelFile(myDirectory, "VarPass.txt");
     isVarpass = true;
 }
*/

//if tmp exist rename it
/*
if (DoesFileExist(targetDirectory, "TahvilyaarAutoUpdate.exetmp"))
{
    delTemp = Path.Combine(targetDirectory, "TahvilyaarAutoUpdate.exe");
    AddLog("Deleting file " + delTemp + " was " + DelFile(targetDirectory, "TahvilyaarAutoUpdate.exe"));
    string oldfile = Path.Combine(targetDirectory, "TahvilyaarAutoUpdate.exetmp");
    string newfile = Path.Combine(targetDirectory, "TahvilyaarAutoUpdate.exe");
    AddLog("Moving file " + oldfile + " to " + newfile + " was " + moveFile(oldfile, newfile));
}
*/

//remote server
/*
remoteServer = findRemoteServer();
AddLog("Remote server = " + remoteServer);
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
            AddLog("mypath                        <>                        targetpath  ");
            AddLog(myPhisicalPath + " <> " + targetDirectory);
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
//    AddLog("Error : " + mes);
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
    

