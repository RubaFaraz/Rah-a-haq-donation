using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace vsprojectrh
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int sum = 0;
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100); 
                sum += 1; 


                int progressPercentage = (int)((i + 1) / 100.0 * 100);
                backgroundWorker1.ReportProgress(progressPercentage);

                
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    backgroundWorker1.ReportProgress(0);
                    return;
                }
            }

            
            e.Result = sum;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
            progressBar1.Value = e.ProgressPercentage;
            label1.Text = e.ProgressPercentage.ToString() + "%";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                label1.Text = "Operation cancelled";
            }
            else if (e.Error != null)
            {
                label1.Text = e.Error.Message;
            }
            else
            {
                
                LogIn lg = new LogIn();
                this.Hide(); 

                if (lg.ShowDialog() == DialogResult.OK)
                {
                    
                    this.Close();  
                }
                else
                {
                    this.Show();  
                }
            }
        }

        
    }

}
