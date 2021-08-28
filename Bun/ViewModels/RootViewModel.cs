using Stylet;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Bun.ViewModels
{
    public class RootViewModel : Conductor<Screen>.Collection.OneActive
    {
        private IContainer _container;

        private IWindowManager _windowManager;

        public string IP { get; set; }

        public int Port { get; set; }

        public Socket s { get; set; }

        public RootViewModel(IContainer container, IWindowManager windowManager)
        {
            _container = container;
            _windowManager = windowManager;
        }

        protected override void OnViewLoaded()
        {
            // Todo: customized ip
            IP = "127.0.0.1";
            Port = 8999;
            s = new Socket(SocketType.Stream, ProtocolType.Tcp);
            s.Connect("127.0.0.1", 8999);
        }

        public void SendData()
        {
            s.Send(Encoding.Default.GetBytes(Input));
            var buf = new byte[512];
            var n = s.Receive(buf);
            var result = new byte[n];
            Array.Copy(buf, result, n);
            Output = Encoding.Default.GetString(result);
        }

        private string _input;
        public string Input
        {
            get { return _input; }
            set
            {
                SetAndNotify(ref _input, value);
            }
        }

        private string _output;
        public string Output
        {
            get { return _output; }
            set
            {
                SetAndNotify(ref _output, value);
            }
        }
    }
}
