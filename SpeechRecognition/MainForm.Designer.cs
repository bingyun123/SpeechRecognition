
namespace SpeechRecognition
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.rtb_log = new System.Windows.Forms.RichTextBox();
            this.timer_recorder = new System.Windows.Forms.Timer(this.components);
            this.tb_interval = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_Language = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_RecordType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.BackColor = System.Drawing.Color.Transparent;
            this.btn_start.Location = new System.Drawing.Point(14, 55);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "开始";
            this.btn_start.UseVisualStyleBackColor = false;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(112, 55);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(75, 23);
            this.btn_stop.TabIndex = 1;
            this.btn_stop.Text = "结束";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // rtb_log
            // 
            this.rtb_log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_log.Location = new System.Drawing.Point(4, 99);
            this.rtb_log.Name = "rtb_log";
            this.rtb_log.Size = new System.Drawing.Size(517, 527);
            this.rtb_log.TabIndex = 2;
            this.rtb_log.Text = "";
            // 
            // timer_recorder
            // 
            this.timer_recorder.Interval = 1000;
            this.timer_recorder.Tick += new System.EventHandler(this.timer_recorder_Tick);
            // 
            // tb_interval
            // 
            this.tb_interval.Location = new System.Drawing.Point(72, 12);
            this.tb_interval.Name = "tb_interval";
            this.tb_interval.Size = new System.Drawing.Size(37, 23);
            this.tb_interval.TabIndex = 3;
            this.tb_interval.Text = "10";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "s";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Interval:";
            // 
            // cb_Language
            // 
            this.cb_Language.FormattingEnabled = true;
            this.cb_Language.Location = new System.Drawing.Point(184, 12);
            this.cb_Language.Name = "cb_Language";
            this.cb_Language.Size = new System.Drawing.Size(73, 23);
            this.cb_Language.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(145, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "语言：";
            // 
            // cb_RecordType
            // 
            this.cb_RecordType.FormattingEnabled = true;
            this.cb_RecordType.Location = new System.Drawing.Point(308, 12);
            this.cb_RecordType.Name = "cb_RecordType";
            this.cb_RecordType.Size = new System.Drawing.Size(93, 23);
            this.cb_RecordType.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(271, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "来源：";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btn_stop);
            this.panel1.Controls.Add(this.btn_start);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(517, 89);
            this.panel1.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 626);
            this.Controls.Add(this.cb_RecordType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_Language);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_interval);
            this.Controls.Add(this.rtb_log);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "MainForm - Made By Bingyun";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.RichTextBox rtb_log;
        private System.Windows.Forms.Timer timer_recorder;
        private System.Windows.Forms.TextBox tb_interval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_Language;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_RecordType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
    }
}

