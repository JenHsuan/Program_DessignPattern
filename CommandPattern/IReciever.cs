using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPattern
{
    public interface IReciever
    {
        String Script { get; set; }
        String Name { get; set; }
        String Msg { get; set; }
        int RunScript();
        int WaitScript();
    }
}
