using NAudio.Wave;
using SpeechRecognition;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Whisper.net;

namespace SpeechRecognition
{
    public class ChunkRecorder
    {
        public enum RecordType
        {
            loudspeaker = 0, // 扬声器
            microphone = 1 //麦克风
        }

        //录制的类型
        RecordType recordType = RecordType.microphone;
        string language = "";

        //录制麦克风的声音
        WaveInEvent waveIn = null; //new WaveInEvent();
        //录制扬声器的声音
        WasapiLoopbackCapture capture = null; //new WasapiLoopbackCapture();
        //生成音频文件的对象
        WaveFileWriter writer = null;

        string audioFile = "";
        Action<string> log = null;

        System.Timers.Timer thread_Timer = null;

        public ChunkRecorder(RecordType recordType,string language, string audioFile, double interval, Action<string> log)
        {
            this.recordType = recordType;
            this.language = language;
            this.audioFile = audioFile;
            this.log = log; 
            if (audioFile == "")
            {
                log("请设置录制文件的路径！");
                return;
            }

            this.StartRecordAudio();
            this.thread_Timer = new System.Timers.Timer(interval);
            thread_Timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_TimesUp);
            thread_Timer.AutoReset = false; //每到指定时间Elapsed事件是触发一次（false），还是一直触发（true）
            thread_Timer.Start();  
        }
        private void Timer_TimesUp(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                this.StopRecordAudio();
                Tools.delayMs(1000);

                string txt = Recognition.toText(this.audioFile, this.language);
                log(txt);

            }
            catch (Exception ex)
            {
                log(ex.Message);
            }
            finally
            {
                Tools.delayMs(1000);
                if (File.Exists(this.audioFile))
                {
                    File.Delete(this.audioFile);
                }

            }
        } 

        /// <summary>
        /// 开始录制
        /// </summary>
        public void StartRecordAudio()
        {
            try
            { 
                FileInfo fi = new FileInfo(audioFile);
                var di = fi.Directory;
                if (!di.Exists)
                    di.Create();

                if (recordType == RecordType.microphone)
                {
                    waveIn = new WaveInEvent();
                    waveIn.WaveFormat = new WaveFormat(16000, 16, 1);
                    writer = new  WaveFileWriter(audioFile, waveIn.WaveFormat);
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
                else
                {
                    capture = new WasapiLoopbackCapture();
                    capture.WaveFormat = new WaveFormat(16000, 16, 1);
                    writer = new WaveFileWriter(audioFile, capture.WaveFormat);

                    capture.DataAvailable += (s, a) =>
                    {
                        writer.Write(a.Buffer, 0, a.BytesRecorded);
                    };
                    //结束录音
                    capture.RecordingStopped += (s, a) =>
                    {
                        writer.Dispose();
                        writer = null;
                        capture.Dispose();
                    }; 
                    capture.StartRecording();
                }
                //log("开始" + audioFile);

            }
            catch (Exception ex)
            {
                try
                {
                    writer.Dispose();
                    writer = null;
                    waveIn.Dispose();
                }catch { }
                if (this.log != null)
                {
                    log(ex.Message);
                }
            }
        }


        //结束录制
        public void StopRecordAudio()
        {
            if (recordType == RecordType.microphone)
                waveIn.StopRecording();
            else
                capture.StopRecording(); 
            //log("停止"+ audioFile);
        }

         
    }
}
