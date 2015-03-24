using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync
{
    interface IView
    {
        void ChangeStatusStripText(string message);


        event Action<object, Dir> OpenDirDialog;
        event Func<Operation, string, bool> OperationIsNeeded;

        void UpdateUI(List<string> files, Dir number, string dirName);
    }
}
