using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace micro_ondas.controllers
{
    public class  TimeValueExcetpion : Exception
    {
        public TimeValueExcetpion(string message)
           : base(message)
        {
        }

    }

    public class PowerValueExcetpion : Exception
    {
        public PowerValueExcetpion(string message)
           : base(message)
        {
        }

    }

    public class ProgramNotFoudException : Exception
    {
        public ProgramNotFoudException(string message)
           : base(message)
        {
        }

    }

    
}
