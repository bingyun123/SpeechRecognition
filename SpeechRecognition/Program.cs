using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeechRecognition
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try { 
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //����UI�߳��쳣
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            //�����UI�߳��쳣
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            }
            catch
            {
                MessageBox.Show("error");
            }
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {

            string str = GetExceptionMsg(e.Exception, e.ToString());
            MessageBox.Show(str);

        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string str = GetExceptionMsg(e.ExceptionObject as Exception, e.ToString());
            MessageBox.Show(str);

        }
        static string GetExceptionMsg(Exception ex, string backStr)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("****************************�쳣�ı�****************************");
            sb.AppendLine("������ʱ�䡿��" + DateTime.Now.ToString());
            if (ex != null)
            {
                sb.AppendLine("���쳣���͡���" + ex.GetType().Name);
                sb.AppendLine("���쳣��Ϣ����" + ex.Message);
                sb.AppendLine("����ջ���á���" + ex.StackTrace);
            }
            else
            {
                sb.AppendLine("��δ�����쳣����" + backStr);
            }
            sb.AppendLine("***************************************************************");
            return sb.ToString();
        }


    }
}
