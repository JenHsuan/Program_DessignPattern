using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPattern
{
    public class Command:ICommand
    {
        private List<IReciever> recievers;
        public Command()
        {
            recievers=new List<IReciever>();
        }
        #region ICommand 成員
        public int Execute()
        {
            foreach (IReciever reciever in recievers)
            {
                reciever.RunScript();
                reciever.Msg = reciever.Name + " :  Start to execute\r\n";
                reciever.WaitScript();
                reciever.Msg =reciever.Msg+ reciever.Name + " :  Finnish\r\n";
            }
            return 0;
        }

        public void AddReciever(IReciever Reciever)
        {
            this.recievers.Add(Reciever);
        }

        public void RecmoveRecievers()
        {
            this.Recievers.Clear();
        }

        public List<IReciever> Recievers
        {
            get
            {
                return recievers;
            }
            set
            {
                recievers = value;
            }
        }

        #endregion
    }
}
