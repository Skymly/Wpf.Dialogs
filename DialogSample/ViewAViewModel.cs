using Dialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogSample
{
    public class ViewAViewModel : ViewModelBase, IDialogAware
    {
        public ViewAViewModel()
        {
            CloseDialogCommand = new RelayCommand(CloseDialog);
        }
        public RelayCommand CloseDialogCommand { get; }
        private void CloseDialog()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK, new DialogParameters { { "Name", "张辽" }, { "兵力", 800 } }));
        }
        public string Title => "ViewA";
        public event Action<IDialogResult> RequestClose;
        public bool CanCloseDialog() => true;

        public void OnDialogClosed() => Debug.WriteLine($"{DateTime.Now:G}  ViewAViewModel.OnDialogClosed");

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Debug.WriteLine($"{DateTime.Now:G}  ViewAViewModel.OnDialogOpened  parameters.Count={parameters?.Count ?? 0}");
            foreach (var item in parameters.Keys)
            {
                Debug.WriteLine($"{item} {parameters.GetValue<object>(item)}");
            }

        }
    }
}
