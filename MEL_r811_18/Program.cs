using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Exchange.WebServices.Data;
//using System.Windows.Forms.Calendar;

namespace MEL_r811_18
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
            //service.Credentials = new WebCredentials("joewilson@ustsubaki.com", "Wfefes5245");
            //service.TraceEnabled = true;
            //service.TraceFlags = TraceFlags.All;
            //service.AutodiscoverUrl("joewilson@ustsubaki.com", RedirectionUrlValidationCallback);
            //EmailMessage email = new EmailMessage(service);
            //email.ToRecipients.Add("ioe416@gmail.com");
            //email.Subject = "HelloWorld";
            //email.Body = new MessageBody("This is the first email I've sent by using the EWS Managed API.");
            //email.Send();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainScreen());
        }
        
        
    }
}
