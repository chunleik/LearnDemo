using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class ExecutingAttribute : Attribute
    {
        private DateTime _dateTime;
        public DateTime Time
        {
            get { return _dateTime; }
            set
            {
                _dateTime = value;
            }
        }

        public ExecutingAttribute(string time)
        {
            DateTime.TryParse(time, out _dateTime);
        }
    }
}
