using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsService_Proj
{
    public partial class Scheduler : ServiceBase
    {
        private Timer timer = null;
        public Scheduler()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer = new Timer();
            this.timer.Interval = 300000000000000;
            this.timer.Elapsed += new ElapsedEventHandler(this.timer_Tick);
            timer.Enabled = true;



            LogService();
        }


        private void timer_Tick(object sender, ElapsedEventHandler e)
        {
            //call some function which will be run by the service
        }

        protected override void OnStop()
        {
            timer.Enabled = false;

        }
    }
}
