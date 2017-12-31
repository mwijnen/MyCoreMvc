using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCoreMvc.Utilities
{
    public class LocalEmailClient
    {

        public static void SendEmail(string description, string controller, string action, string actionUrl)
        {
            string root = System.IO.Directory.GetCurrentDirectory();
            string emailDirectory = @"\LocalEmails\";
            DateTime now = DateTime.Now;
            string path = emailDirectory + description + "_" + now.ToShortDateString() + "_" + now.ToShortTimeString() + ".email";
            path = path.Replace(' ', '_');
            path = path.Replace(':', '-');
            StringBuilder emailBuilder = new StringBuilder();
            emailBuilder.AppendLine(now.ToLongTimeString());
            emailBuilder.AppendLine(description);
            emailBuilder.AppendLine(controller);
            emailBuilder.AppendLine(action);
            emailBuilder.AppendLine(actionUrl);
            
            System.IO.File.WriteAllText(root + path, emailBuilder.ToString());
        }
    }
}
