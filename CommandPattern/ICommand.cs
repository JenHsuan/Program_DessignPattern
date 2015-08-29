using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPattern
{
    public interface ICommand
    {
        //String Script { get; set; }
        int Execute();
        void AddReciever(IReciever Reciever);
        void RecmoveRecievers();
        List<IReciever> Recievers { get; set; }

    }
}
