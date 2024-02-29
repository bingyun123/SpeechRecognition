using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Whisper.net; 

namespace SpeechRecognition
{
    public partial class MainForm : Form
    {
        private int currentCount = 0;
        private int recordType;
        private string language;
        private string rootChunkPath = "chunk";
        public MainForm()
        {
            InitializeComponent(); 
            Dictionary<int, string> recordTypeDict = new Dictionary<int, string>();
            recordTypeDict.Add( 0, "扬声器");
            recordTypeDict.Add( 1 , "麦克风"); 
            cb_RecordType.DataSource = recordTypeDict.ToList();
            cb_RecordType.ValueMember = "Key";
            cb_RecordType.DisplayMember = "Value";
            cb_RecordType.SelectedIndex = 0;


            Dictionary<string, string> languageDict = new Dictionary<string, string>();
            languageDict.Add("auto", "Auto");
            languageDict.Add("en", "English"); 
            languageDict.Add("zh", "中文"); 
            languageDict.Add("de", "German"); 
            languageDict.Add("ja", "Japanese"); 
            languageDict.Add("ko", "Korean"); 
            languageDict.Add("ro", "Romanian"); 
            cb_Language.DataSource = languageDict.ToList();
            cb_Language.ValueMember = "Key";
            cb_Language.DisplayMember = "Value";
            cb_Language.SelectedIndex = 1;


        }

        private void Form1_Load(object sender, EventArgs e)
        { 
            this.btn_start.Enabled = true;
            this.btn_stop.Enabled = false;
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(tb_interval.Text, out int interval)) {
                MessageBox.Show("Interval必须是数字");
                return;
            }
            log("开始任务");
            DeleteTrunk();
            Application.DoEvents();
            this.btn_start.Enabled = false;
            this.btn_stop.Enabled = true;
            this.tb_interval.Enabled = false;
            this.cb_Language.Enabled = false;
            this.cb_RecordType.Enabled = false;
            this.recordType = int.Parse(this.cb_RecordType.SelectedValue.ToString());
            this.language = this.cb_Language.SelectedValue.ToString();
            Application.DoEvents(); 
            this.currentCount = 0;
            this.timer_recorder.Interval = interval * 1000;
            this.timer_recorder_Tick(null,null);
            this.timer_recorder.Start();


        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            
            this.btn_start.Enabled = true;
            this.btn_stop.Enabled = false;
            this.tb_interval.Enabled = true;
            this.cb_Language.Enabled = true;
            this.cb_RecordType.Enabled = true;
            this.timer_recorder.Stop();
            this.currentCount = 0; 
            log("任务结束"); 
             
        }

        private void DeleteTrunk()
        {
            try
            {
                if (Directory.Exists(rootChunkPath))
                {
                    Directory.Delete(rootChunkPath,true);
                }
            }catch(Exception ex)
            {

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DeleteTrunk();
        }

        public  void log(string msg)
        {
            if (rtb_log.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    WriterLog(msg);
                }));
                 
            }
            else
            {
                WriterLog(msg);
            }


        }

        private void WriterLog(string msg)
        {
            int maxLine = 500;//最大显示行数
            int keepLine = 10;  //保留行数
            if (rtb_log.Lines.Length > maxLine)
            {
                String[] lines = new string[keepLine];
                Array.Copy(rtb_log.Lines, rtb_log.Lines.Length - keepLine, lines, 0, keepLine);
                rtb_log.Lines = lines; 
            }
            rtb_log.AppendText(msg + "\r\n");
            rtb_log.ScrollToCaret();
        }

        private void timer_recorder_Tick(object sender, EventArgs e)
        {
            try
            {
                this.currentCount++;
                string filePath = string.Format(@"{0}\{1}.wav", this.rootChunkPath, this.currentCount);
                new ChunkRecorder((ChunkRecorder.RecordType)this.recordType, this.language, filePath, timer_recorder.Interval, (result => log(result)));
            }catch(Exception ex)
            {
                log(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WaveInEvent waveIn = new WaveInEvent();
            waveIn.WaveFormat = new WaveFormat(16000, 16, 1);
            var writer = new WaveFileWriter("", waveIn.WaveFormat);
            //开始录音，写数据
            waveIn.DataAvailable += (s, a) =>
            {
                writer.Write(a.Buffer, 0, a.BytesRecorded);
            };

            //结束录音
            waveIn.RecordingStopped += (s, a) =>
            {
                writer.Dispose();
                writer = null;
                waveIn.Dispose();

            };
            waveIn.StartRecording();
        }
    }
}
