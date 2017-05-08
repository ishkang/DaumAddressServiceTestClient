using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class DaumAddressSearchForm : Form
    {
        string input;
        string output;

        public DaumAddressSearchForm()
        {
            InitializeComponent();
        }

        private void DaumAddressSearchForm_Load(object sender, EventArgs e)
        {
            webBrowser.AllowWebBrowserDrop = false;
            webBrowser.IsWebBrowserContextMenuEnabled = false;
            webBrowser.WebBrowserShortcutsEnabled = false;
            webBrowser.ObjectForScripting = this;
            // Uncomment the following line when you are finished debugging.
            //webBrowser.ScriptErrorsSuppressed = true;

            //webBrowser.Navigate("http://localhost:50978/DaumAddressSearch.html");
            webBrowser.Navigate("http://em.neoiplus.com/DaumAddressSearch.html");
        }

        #region
        public void SetOutput(string output)
        {
            this.output = output;

            DialogResult = DialogResult.OK;
            Close();
        }

        public new void Resize(int height)
        {
        }

        public void Cancel()
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion

        #region
        public void SetInput(string input)
        {
            this.input = input;
        }

        public string GetOutput()
        {
            return output;
        }
        #endregion
    }
}
