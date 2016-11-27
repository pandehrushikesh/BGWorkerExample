namespace StartSample
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.StartBGWorker = new System.Windows.Forms.Button();
			this.StartAsyncAwait = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// StartBGWorker
			// 
			this.StartBGWorker.Location = new System.Drawing.Point(12, 42);
			this.StartBGWorker.Name = "StartBGWorker";
			this.StartBGWorker.Size = new System.Drawing.Size(211, 23);
			this.StartBGWorker.TabIndex = 3;
			this.StartBGWorker.Text = "Start Background Worker";
			this.StartBGWorker.UseVisualStyleBackColor = true;
			this.StartBGWorker.Click += new System.EventHandler(this.StartBGWorker_Click);
			// 
			// StartAsyncAwait
			// 
			this.StartAsyncAwait.Location = new System.Drawing.Point(12, 12);
			this.StartAsyncAwait.Name = "StartAsyncAwait";
			this.StartAsyncAwait.Size = new System.Drawing.Size(211, 23);
			this.StartAsyncAwait.TabIndex = 2;
			this.StartAsyncAwait.Text = "Start Async Await";
			this.StartAsyncAwait.UseVisualStyleBackColor = true;
			this.StartAsyncAwait.Click += new System.EventHandler(this.StartAsyncAwait_Click);
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(12, 71);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(211, 23);
			this.btnClose.TabIndex = 4;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(243, 104);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.StartBGWorker);
			this.Controls.Add(this.StartAsyncAwait);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.ResumeLayout(false);

		}

		#endregion

		internal System.Windows.Forms.Button StartBGWorker;
		internal System.Windows.Forms.Button StartAsyncAwait;
		internal System.Windows.Forms.Button btnClose;
	}
}

