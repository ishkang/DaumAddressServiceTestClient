using System;
using System.Windows.Forms;
using System.Security.Permissions;
using System.IO;

[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
[System.Runtime.InteropServices.ComVisibleAttribute(true)]
public class AddressHelpForm : Form
{
    string requestAddress;
    string responseAddressInfo;

    public AddressHelpForm()
    {
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
        }

        base.Dispose(disposing);
    }

    public DialogResult ShowDialog(string address)
    {
        requestAddress = address;

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

            ShowInTaskbar = false;
            WindowState = FormWindowState.Minimized;
            return ShowDialog();
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
        DialogResult = DialogResult.OK;
        Close();
    }

    public string GetAddressInfo()
    {
        return responseAddressInfo;
    }

    public void Cancel()
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}