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

namespace MyAsyncAwait
{
    public partial class Form1 : Form
    {
        private const int Max = 10;
		private CancellationTokenSource cts;
        public Form1()
        {
            InitializeComponent();
			pbProgress.Maximum = Max;
			pbProgress.Step = 1;
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            var progressIndicator = new Progress<int>(ReportProgress);
			cts = new CancellationTokenSource();
			try
			{
				int result = await LongRunning(progressIndicator, cts.Token);

				if (cts.IsCancellationRequested)
				{
					lblStatus.Text = string.Format("Operation cancelled by user.");
					pbProgress.Value = 0;
				}
				else
				{
					lblStatus.Text = string.Format("Operation completed. Result: {0}", result);
				}
				btnStart.Enabled = true;
			}
			catch (OperationCanceledException ex)
			{
				MessageBox.Show(ex.Message);
			}
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
			cts.Cancel();
        }

		async Task<int> LongRunning(IProgress<int> progress, CancellationToken ct)
        {
            int tempCount = 0;
            int result;

			btnStart.Enabled = false;
				result = await Task.Run<int>(() =>
				{
					for (int i = 0; i < Max; i++)
					{
						if (ct.IsCancellationRequested)
						{
							break;
						}
						Thread.Sleep(1000);
						if (progress != null)
						{
							progress.Report(tempCount);
						}
						tempCount++;
					}
					return tempCount;
				}, ct);
				return result;
        }

        void ReportProgress(int value)
        {
            pbProgress.PerformStep();
            lblStatus.Text = value.ToString();
        }

    }
}
