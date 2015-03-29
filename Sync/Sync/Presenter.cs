using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sync
{
    public enum Operation 
    {
        None,
        Sync,
        Delete,
        Add,
        Reset
    }

    class Presenter
    {
        private IView view;
        private Model model;
        FolderBrowserDialog dirDialog = new FolderBrowserDialog();

        public Presenter(IView syncView) 
        {
            view = syncView;
            model = new Model();
            view.OpenDirDialog += view_OpenDirDialog;
            view.OperationIsNeeded += view_RunOperation;
        }

        /// <summary>
        /// Process user action depending on clicked button
        /// </summary>
        private bool view_RunOperation(Operation operation, string param)
        {
            switch (operation)
            {
                case Operation.Add:
                    {
                        string message = "";
                        bool success = model.Add(param, out message);

                        view.UpdateUI(model.FirstDirFiles, Dir.First, "");
                        view.UpdateUI(model.SecondDirFiles, Dir.Second, "");

                        if (success)
                        {
                            view.ChangeStatusStripText(string.Format("File {0} was added ...", param));
                            return true;
                        }
                        else
                        {
                            view.ChangeStatusStripText(message);
                            return false;
                        }
                    }

                case Operation.Delete:
                    {
                        string message = "";
                        bool success = model.Remove(param, out message);

                        view.UpdateUI(model.FirstDirFiles, Dir.First, "");
                        view.UpdateUI(model.SecondDirFiles, Dir.Second, "");

                        if (success)
                        {
                            view.ChangeStatusStripText(string.Format("File {0} was removed ...", param));
                            return true;
                        }
                        else
                        {
                            view.ChangeStatusStripText(message);
                            return false;
                        }
                    }

                case Operation.Sync:
                    {
                        string message = "";
                        bool success = model.Sync(out message);

                        view.UpdateUI(model.FirstDirFiles, Dir.First, "");
                        view.UpdateUI(model.SecondDirFiles, Dir.Second, "");

                        if (success)
                        {
                            view.ChangeStatusStripText("Sync was completed...");
                            return true;
                        }
                        else 
                        {
                            view.ChangeStatusStripText(message);
                            return false;
                        }
                    }

                case Operation.Reset:
                    {
                        string message = "";
                        bool success = model.Reset(out message);

                        view.UpdateUI(model.FirstDirFiles, Dir.First, " ");
                        view.UpdateUI(model.SecondDirFiles, Dir.Second, " ");

                        if (success)
                        {
                            view.ChangeStatusStripText("Reset was completed. Select new directories...");
                            return true;
                        }
                        else 
                        {
                            view.ChangeStatusStripText(message);
                            return false;
                        }
                    }

                case Operation.None:
                default:
                    {
                        return false;
                    }
            }
        }

        private void view_OpenDirDialog(object sender, Dir dirNumber)
        {
            if (dirDialog.ShowDialog() == DialogResult.OK) 
            {
                model.AddFiles(dirDialog.SelectedPath, dirNumber);
            }

            if (dirNumber == Dir.First)
                view.UpdateUI(model.FirstDirFiles, dirNumber, dirDialog.SelectedPath);
            else
                view.UpdateUI(model.SecondDirFiles, dirNumber, dirDialog.SelectedPath);
        }
    }
}
