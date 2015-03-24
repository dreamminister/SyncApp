using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sync
{
    public partial class Form1 : Form, IView
    {
        private bool isFirstDirSet = false;
        private bool isSecondDirSet = false;

        public event Action<object, Dir> OpenDirDialog;
        public event Func<Operation, string, bool> OperationIsNeeded;

        public Form1()
        {
            InitializeComponent();
        }

        public void ChangeStatusStripText(string message)
        {
            toolStripStatusMessage.Text = message;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ChangeStatusStripText("Please, select directories to work with...");
        }

        private void DirSelectBtn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null && OpenDirDialog != null) 
            {
                Dir dirNum = Dir.First;

                if (btn.Name.Equals(secondDirSelectBtn.Name))
                    dirNum = Dir.Second;

                OpenDirDialog(sender, dirNum);
            }
        }

        public void UpdateUI(List<string> files, Dir number, string dirName)
        {
            if (number == Dir.First)
            {
                firstDirNameLbl.Text = dirName;
                FirstDirLB.Items.Clear();
                FirstDirLB.Items.AddRange(files.ToArray());
                isFirstDirSet = true;

                if (!isSecondDirSet)
                    ChangeStatusStripText("Please, select second folder to proceed...");
            }
            else 
            {
                SecondDirNameLbl.Text = dirName;
                SecondDirLB.Items.Clear();
                SecondDirLB.Items.AddRange(files.ToArray());
                isSecondDirSet = true;

                if (!isFirstDirSet)
                    ChangeStatusStripText("Please, select first folder to proceed...");
            }

            if (isSecondDirSet && isFirstDirSet)
                ChangeStatusStripText("Use action buttons to manipulate with folders content...");

            UpdateActionButtonsUI();
        }

        private void UpdateActionButtonsUI()
        {
            SyncBtn.Enabled = isFirstDirSet && isSecondDirSet;
            AddBtn.Enabled = isFirstDirSet && isSecondDirSet;
            DelBtn.Enabled = (isFirstDirSet && FirstDirLB.SelectedItem != null) ||
                             (isSecondDirSet && SecondDirLB.SelectedItem != null);
            ResetBtn.Enabled = isFirstDirSet || isSecondDirSet;
        }

        bool updatingUI = false;

        private void FileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lb = sender as ListBox;

            if (lb != null && !updatingUI) 
            {
                updatingUI = true;

                if (lb == FirstDirLB && SecondDirLB.SelectedItem != null)
                    SecondDirLB.ClearSelected();
                else if (lb == SecondDirLB && FirstDirLB.SelectedItem != null)
                    FirstDirLB.ClearSelected();

                updatingUI = false;
            }

            UpdateActionButtonsUI();
        }

        private void ActionButton_Click(object sender, EventArgs e)
        {
            Button actionBtn = sender as Button;

            if (actionBtn != null && OperationIsNeeded != null) 
            {
                Operation operation = Operation.None;
                string operationParameter = string.Empty;

                if (actionBtn.Name == SyncBtn.Name) 
                {
                    operation = Operation.Sync;
                }
                else if (actionBtn.Name == AddBtn.Name) 
                {
                    operation = Operation.Add;

                    // to do write code fore creating new file
                }
                else if (actionBtn.Name == DelBtn.Name) 
                {
                    if (FirstDirLB.SelectedItem != null)
                        operationParameter = FirstDirLB.SelectedItem.ToString();
                    else if (SecondDirLB.SelectedItem != null)
                        operationParameter = SecondDirLB.SelectedItem.ToString();

                    operation = Operation.Delete;
                }
                else if (actionBtn.Name == ResetBtn.Name) 
                {
                    operation = Operation.Reset;
                }

                OperationIsNeeded(operation, operationParameter);
            }
        }
    }
}
