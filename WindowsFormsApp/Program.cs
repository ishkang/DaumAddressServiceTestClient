using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IAddressHelp addressHelp = new AddressHelp();
            string addressInfo = addressHelp.GetAddressInfo("강원도 춘천시");
            MessageBox.Show(addressInfo);
        }
    }
}
