using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MyBGWorker
{
	public partial class Form1 : Form
	{
		private BackgroundWorker myWorker;
		private const int Max = 10;
		public Form1()
		{
			InitializeComponent();
			myWorker = new BackgroundWorker();
			myWorker.DoWork += new DoWorkEventHandler(myWorker_DoWork);
			myWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(myWorker_RunWorkerCompleted);
			myWorker.ProgressChanged += new ProgressChangedEventHandler(myWorker_ProgressChanged);
			myWorker.WorkerReportsProgress = true;
			myWorker.WorkerSupportsCancellation = true;
			pbProgress.Maximum = Max;
			pbProgress.Step = 1;
		}

        #region BackgroundWorker
        private void btnStart_Click(object sender, EventArgs e)
		{
			if (!myWorker.IsBusy)//Check if the worker is already in progress
			{
				btnStart.Enabled = false;//Disable the Start button
				lblStatus.Text = "";
				myWorker.RunWorkerAsync();//Call the background worker
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			myWorker.CancelAsync();
		}

		protected void myWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker sendingWorker = (BackgroundWorker)sender;
			for (int i = 0; i < Max; i++)
			//check if there is a cancellation request pending 
			{
				if (!sendingWorker.CancellationPending)//At each iteration of the loop, 
				
				{
					Thread.Sleep(1000);
					sendingWorker.ReportProgress(i);
				}
				else
				{
					e.Cancel = true;//If a cancellation request is pending, assign this flag a value of true
					break;//
				}
			}
		}

		protected void myWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (!e.Cancelled && e.Error == null)//Check if the worker has been canceled or if an error occurred
			{
				string result = (string)e.Result;//Get the result from the background thread
				MessageBox.Show("Done!!!");
				lblStatus.Text = "Done";
			}
			else if (e.Cancelled)
			{
				lblStatus.Text = "User Canceled";
			}
			else
			{
				lblStatus.Text = "An error has occurred";
			}
			btnStart.Enabled = true;//Re enable the start button
			pbProgress.Value = 0;
		}

		protected void myWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			pbProgress.PerformStep();// = e.ProgressPercentage;
			lblStatus.Text = e.ProgressPercentage.ToString();

		}
        #endregion
      
    }
}
