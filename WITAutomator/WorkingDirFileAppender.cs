using log4net.Appender;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WITAutomator
{
    /// <summary>
    /// https://stackoverflow.com/questions/1922430/how-do-you-make-log4net-output-to-current-working-directory
    /// </summary>
    public class WorkingDirFileAppender : RollingFileAppender
    {
        public override string File
        {
            set => base.File = Path.Combine(Directory.GetCurrentDirectory(), value);
        }
    }
}
