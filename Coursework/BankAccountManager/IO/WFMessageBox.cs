namespace BankAccountManager.IO
{
    using BankAccountManager.IO.Contracts;
    using System.Windows.Forms;

    public class WFMessageBox : IWFMessageBox
    {
        public void Show(string message)
        {
            MessageBox.Show(message);
        }
    }
}
