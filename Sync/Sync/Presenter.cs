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

        private bool view_RunOperation(Operation operation, string param)
        {
            switch (operation)
            {
                case Operation.Add:
                    {
                        return model.Add(param);
                    }

                case Operation.Delete:
                    {
                        return model.Remove(param);
                    }

                case Operation.Sync:
                    {
                        return model.Sync();
                    }

                case Operation.Reset:
                    {
                        return model.Reset();
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
                view.UpdateUI(model.FirstDir, dirNumber, dirDialog.SelectedPath);
            else
                view.UpdateUI(model.SecondDir, dirNumber, dirDialog.SelectedPath);
        }
    }
}
