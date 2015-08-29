using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPattern
{
    public class Reciever:IReciever
    {
        private string script;
        private string name;
        private string msg;
        private System.Diagnostics.Process process;
        private string exePath;
        private string exeDir ;
        public Reciever()
        {
            this.exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            this.exeDir = System.IO.Path.GetDirectoryName(exePath);
            this.Msg = "";
        }
        public Reciever(String _script)
        {
            this.script = _script;
            this.exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            this.exeDir = System.IO.Path.GetDirectoryName(exePath);
            this.Msg = "";
        }
        #region IReciever 成員

        public string Script
        {
            get
            {
                return script;
            }
            set
            {
                script = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Msg
        {
            get
            {
                return msg;
            }
            set
            {
                msg = value;
            }
        }

        public int RunScript()
        {
            string command = this.script +" > "+this.Name+".txt";
            System.Diagnostics.ProcessStartInfo procStartInfo =
            new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);
            //procStartInfo.RedirectStandardOutput = true;
           procStartInfo.UseShellExecute =true;
           // procStartInfo.CreateNoWindow = true;

            process = new System.Diagnostics.Process();
           // System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
           // startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
           // startInfo.FileName = "cmd.exe";
           // startInfo.Arguments = procStartInfo;
            process.StartInfo = procStartInfo;
            process.Start();
            return 0;
        }

        public int WaitScript()
        {
            process.WaitForExit();
            return 0;
        }

        #endregion
    }
}
