using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPattern
{
    public class Invoker:IInvoker
    {
        private ICommand Command;
       
        #region IInvoker 成員

        public void SetCommand(ICommand _Command)
        {
            this.Command = _Command;
        }

        public int Execute()
        {
            return this.Command.Execute();
            
        }

        #endregion
    }
}
