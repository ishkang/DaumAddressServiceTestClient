using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public class AddressHelp2 : IAddressHelp
    {
        string requestAddress;
        string responseAddressInfo;
        AutoResetEvent closedEvent;

        public string GetAddressInfo(string address)
        {
            requestAddress = address;
            closedEvent = new AutoResetEvent(false);

            using (WebBrowser webBrowser = new WebBrowser())
            {
                webBrowser.Url = new Uri("http://localhost:50978/DaumAddressHelp.html");
                webBrowser.AllowWebBrowserDrop = false;
                webBrowser.IsWebBrowserContextMenuEnabled = false;
                webBrowser.WebBrowserShortcutsEnabled = false;
                webBrowser.ObjectForScripting = this;
                webBrowser.DocumentCompleted += WebBrowser_DocumentCompleted;
                // Uncomment the following line when you are finished debugging.
                //webBrowser.ScriptErrorsSuppressed = true;

                while (!Thread.CurrentThread.Join(1000))
                {
                    if (closedEvent.WaitOne(0, true))
                        break;
                }

                return responseAddressInfo;
            }
        }

        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser webBrowser = sender as WebBrowser;
            webBrowser.DocumentCompleted -= WebBrowser_DocumentCompleted;
            webBrowser.Document.InvokeScript("showWindow", new string[] { requestAddress });
        }

        public void SetAddressInfo(string addressInfo)
        {
            responseAddressInfo = addressInfo;
            closedEvent.Set();
        }

        public void Cancel()
        {
            closedEvent.Set();
        }
    }
}
