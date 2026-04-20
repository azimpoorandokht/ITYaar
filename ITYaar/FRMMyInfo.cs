using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITYaar
{
	public partial class FRMMyInfo : Form
	{
		public FRMMyInfo()
		{
			InitializeComponent();
		}

		private void FRMMyInfo_Load(object sender, EventArgs e)
		{
			string x =  "این نرم افزار در دایره سیستم های استان هرمزگان طراحی و تهیه شده است";
			//x = x + "\n" + "در صورت تمایل برای حمایت مالی در گسترش این نرم افزار میتواند از شماره کارت زیر اقدام نمائید";
			//x = x + "\n" + "6280231110214763";
			//x = x + "\n" + "یا شماره حساب";
			//x = x + "\n" + "310000105075";
			label1.Text = x;
		}
	}
}
