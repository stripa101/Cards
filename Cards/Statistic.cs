using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    internal class Statistic
    {
        private int _counter;
        public int Counter
        {
            get
            {
                _counter++;
                return _counter;
            }
        }
    }
}
