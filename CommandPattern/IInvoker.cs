using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPattern
{
    public interface IInvoker
    {
        void SetCommand(ICommand Command);
        int Execute();
    }
}
