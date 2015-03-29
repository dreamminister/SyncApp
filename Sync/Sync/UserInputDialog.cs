using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sync
{
    /// <summary>
    /// Custom menu for adding file to folders. User provides file name.
    /// </summary>
    public partial class UserInputDialog : UserControl
    {
        public event Action OnFileNameIsReady;
        public string SelectedFileName = string.Empty;

        public UserInputDialog()
        {
            InitializeComponent();
        }

        private void CreateFileBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(fileNameTxt.Text) && OnFileNameIsReady != null)
            {
                SelectedFileName = fileNameTxt.Text;
                OnFileNameIsReady();
                this.Hide();
            }
            else 
            {
                SelectedFileName = string.Empty;
                MessageBox.Show("Please provide non-empty file name to proceed...", "Sync", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
