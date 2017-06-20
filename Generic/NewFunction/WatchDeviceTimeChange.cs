using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFunction
{
    public class WatchDeviceTimeChange
    {
        public void Start()
        {
            SystemEvents.TimeChanged += SystemEvents_TimeChanged;
        }

        private void SystemEvents_TimeChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
