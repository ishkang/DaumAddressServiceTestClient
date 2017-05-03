using System;
using System.Windows.Forms;
using System.Security.Permissions;
using System.IO;

[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
[System.Runtime.InteropServices.ComVisibleAttribute(true)]
public class AddressHelp : Form
{
    private WebBrowser webBrowser1 = new WebBrowser();
    public string Address { get; set; }

    public AddressHelp()
    {
        KeyPreview = true;

        webBrowser1.Dock = DockStyle.Fill;
        Controls.Add(webBrowser1);
        Load += new EventHandler(Form1_Load);
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        webBrowser1.AllowWebBrowserDrop = false;
        webBrowser1.IsWebBrowserContextMenuEnabled = false;
        webBrowser1.WebBrowserShortcutsEnabled = false;
        webBrowser1.ObjectForScripting = this;
        webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;
        // Uncomment the following line when you are finished debugging.
        //webBrowser1.ScriptErrorsSuppressed = true;

        //webBrowser1.DocumentText = File.ReadAllText("AddressHelp.html");        
        webBrowser1.Navigate("DaumAddressApi.html");
    }

    private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        webBrowser1.Document.InvokeScript("search", new string[] { "강원도 춘천시" });
    }

    public void SetAddress(string address)
    {
        Address = address;
        MessageBox.Show(Address);
    }
}