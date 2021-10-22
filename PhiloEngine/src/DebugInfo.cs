using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PhiloEngine.src
{
    public class DebugInfo
    {
        private string _msg;
        public string Msg { get => _msg; set => _msg = value; }
        public DebugInfo(string msg)
        {
            _msg = msg;
        } 

        public void PrintDebug()
        {
            Debug.WriteLine(_msg);
        }
    }
}
