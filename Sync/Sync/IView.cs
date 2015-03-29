using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync
{
    interface IView
    {
        // status strip message displaying
        void ChangeStatusStripText(string message);
        // folder dialog for dir selecting
        event Action<object, Dir> OpenDirDialog;
        // event for operations handling
        event Func<Operation, string, bool> OperationIsNeeded;
        // update UI (textboxes) with folder's content
        void UpdateUI(List<string> files, Dir number, string dirName);
    }
}
