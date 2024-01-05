/*
 * Created by SharpDevelop.
 * User: Semih
 * Date: 29.11.2018
 * Time: 18:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MayinTarlasi
{
	/// <summary>
	/// Description of From2.
	/// </summary>
	public partial class From2 : Form
	{
		public From2()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Timer1Tick(object sender, EventArgs e)
		{
			progressBar1.Increment(5);
			if (progressBar1.Value==100)
			{
				timer1.Stop();
				Form1 mayintarlasi=new Form1();
				this.Close();
				mayintarlasi.Show();
			}
		}
	}
}
