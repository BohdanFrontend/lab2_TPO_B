using System.Windows.Forms;
using System.Drawing;

namespace lab2_TPO_B
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            var lblArgumentLabel = new Label();
            nudArgument = new NumericUpDown();
            var lblStepLabel = new Label();
            txtStep = new TextBox();
            var lblIntervalLabel = new Label();
            txtInterval = new TextBox();
            var lblMinXLabel = new Label();
            txtMinX = new TextBox();
            var lblMaxXLabel = new Label();
            txtMaxX = new TextBox();

            btnStart = new Button();
            btnStop = new Button();
            btnClear = new Button();

            dgvResults = new DataGridView();
            lblStatus = new Label();

            ((System.ComponentModel.ISupportInitialize)nudArgument).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            SuspendLayout();

            lblArgumentLabel.AutoSize = true;
            lblArgumentLabel.Location = new Point(12, 15);
            lblArgumentLabel.Name = "lblArgumentLabel";
            lblArgumentLabel.Size = new Size(67, 15);
            lblArgumentLabel.TabIndex = 0;
            lblArgumentLabel.Text = "Аргумент X:";

            nudArgument.DecimalPlaces = 2;
            nudArgument.Increment = new decimal(0.5);
            nudArgument.Location = new Point(85, 12);
            nudArgument.Minimum = new decimal(-100);
            nudArgument.Maximum = new decimal(100);
            nudArgument.Name = "nudArgument";
            nudArgument.Size = new Size(80, 23);
            nudArgument.TabIndex = 1;
            nudArgument.Value = new decimal(0);

            lblStepLabel.AutoSize = true;
            lblStepLabel.Location = new Point(190, 15);
            lblStepLabel.Name = "lblStepLabel";
            lblStepLabel.Size = new Size(37, 15);
            lblStepLabel.TabIndex = 2;
            lblStepLabel.Text = "Крок:";

            txtStep.Location = new Point(233, 12);
            txtStep.Name = "txtStep";
            txtStep.Size = new Size(60, 23);
            txtStep.TabIndex = 3;
            txtStep.Text = "0.5";

            lblIntervalLabel.AutoSize = true;
            lblIntervalLabel.Location = new Point(310, 15);
            lblIntervalLabel.Name = "lblIntervalLabel";
            lblIntervalLabel.Size = new Size(68, 15);
            lblIntervalLabel.TabIndex = 4;
            lblIntervalLabel.Text = "Інтервал мс:";

            txtInterval.Location = new Point(384, 12);
            txtInterval.Name = "txtInterval";
            txtInterval.Size = new Size(60, 23);
            txtInterval.TabIndex = 5;
            txtInterval.Text = "500";

            lblMinXLabel.AutoSize = true;
            lblMinXLabel.Location = new Point(460, 15);
            lblMinXLabel.Name = "lblMinXLabel";
            lblMinXLabel.Size = new Size(43, 15);
            lblMinXLabel.TabIndex = 6;
            lblMinXLabel.Text = "Min X:";

            txtMinX.Location = new Point(509, 12);
            txtMinX.Name = "txtMinX";
            txtMinX.Size = new Size(60, 23);
            txtMinX.TabIndex = 7;
            txtMinX.Text = "-10";

            lblMaxXLabel.AutoSize = true;
            lblMaxXLabel.Location = new Point(585, 15);
            lblMaxXLabel.Name = "lblMaxXLabel";
            lblMaxXLabel.Size = new Size(47, 15);
            lblMaxXLabel.TabIndex = 8;
            lblMaxXLabel.Text = "Max X:";

            txtMaxX.Location = new Point(638, 12);
            txtMaxX.Name = "txtMaxX";
            txtMaxX.Size = new Size(60, 23);
            txtMaxX.TabIndex = 9;
            txtMaxX.Text = "10";

            btnStart.Location = new Point(12, 50);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(150, 30);
            btnStart.TabIndex = 10;
            btnStart.Text = "Почати обчислення";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += BtnStart_Click;

            btnStop.Location = new Point(168, 50);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(100, 30);
            btnStop.TabIndex = 11;
            btnStop.Text = "Зупинити";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += BtnStop_Click;

            btnClear.Location = new Point(274, 50);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(130, 30);
            btnClear.TabIndex = 12;
            btnClear.Text = "Очистити таблицю";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += BtnClear_Click;

            dgvResults.AllowUserToAddRows = false;
            dgvResults.AllowUserToDeleteRows = false;
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResults.Location = new Point(12, 100);
            dgvResults.Name = "dgvResults";
            dgvResults.ReadOnly = true;
            dgvResults.Size = new Size(760, 320);
            dgvResults.TabIndex = 13;

            dgvResults.Columns.Add("X", "X");
            dgvResults.Columns.Add("FX", "F(x)");
            dgvResults.Columns.Add("ThreadId", "ID Потоку");

            lblStatus.AutoSize = true;
            lblStatus.ForeColor = Color.Red;
            lblStatus.Location = new Point(12, 430);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 15);
            lblStatus.TabIndex = 14;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(lblArgumentLabel);
            Controls.Add(nudArgument);
            Controls.Add(lblStepLabel);
            Controls.Add(txtStep);
            Controls.Add(lblIntervalLabel);
            Controls.Add(txtInterval);
            Controls.Add(lblMinXLabel);
            Controls.Add(txtMinX);
            Controls.Add(lblMaxXLabel);
            Controls.Add(txtMaxX);
            Controls.Add(btnStart);
            Controls.Add(btnStop);
            Controls.Add(btnClear);
            Controls.Add(dgvResults);
            Controls.Add(lblStatus);
            Name = "Form1";
            Text = "Лабораторна робота: Створення та використання потоків (Варіант №8)";
            ((System.ComponentModel.ISupportInitialize)nudArgument).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown nudArgument;
        private TextBox txtStep;
        private TextBox txtInterval;
        private TextBox txtMinX;
        private TextBox txtMaxX;
        private Button btnStart;
        private Button btnStop;
        private Button btnClear;
        private DataGridView dgvResults;
        private Label lblStatus;
    }
}
