using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whisper.net;

namespace SpeechRecognition
{
    class Recognition
    {
        static public byte[] bufferedModel = File.ReadAllBytes(@"models\ggml-tiny.bin"); 
        static public string toText(string audioFile,string language)
        { 
            var segments = new List<SegmentData>();
            var encoderBegins = new List<EncoderBeginData>();
            using var factory = WhisperFactory.FromBuffer(bufferedModel);
            using var processor = factory.CreateBuilder()
                            .WithLanguage(language)
                            .WithEncoderBeginHandler((e) =>
                            {
                                encoderBegins.Add(e);
                                return true;
                            })
                            .WithSegmentEventHandler(segments.Add)
                            .Build();
            try
            { 
                return ProcessFile(audioFile, segments, processor);
            }
            catch (IOException ix)
            {
                try
                {
                    Tools.delayMs(2000);
                    return ProcessFile(audioFile, segments, processor);
                }
                finally
                {
                    processor.Dispose();
                    factory.Dispose();
                }
            }
            finally
            {
                processor.Dispose();
                factory.Dispose();
            }

        }

        private static string ProcessFile(string audioFile,  List<SegmentData> segments, WhisperProcessor processor)
        {
            using FileStream fileReader = File.OpenRead(audioFile);
            processor.Process(fileReader);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var segment in segments)
            {
                stringBuilder.AppendLine($"{segment.Text}");
            }
            string text = stringBuilder.ToString().TrimEnd((char[])"\r\n".ToCharArray());
            return text;
        }
    }
}
