using DialogSample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Dialogs;
using System.Windows;
using Newtonsoft.Json;
using System.Windows.Input;

namespace DialogSample
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            OpenDialogCommand = new RelayCommand(OpenDialog);
            CustomOpenDialogCommand = new RelayCommand(CustomOpenDialog);
        }

        public RelayCommand OpenDialogCommand { get; }

        private void OpenDialog()
        {
            DialogService.Instance.Show(new ViewA(),null, CallBack);
        }

        private void CallBack(IDialogResult obj)
        {
            MessageBox.Show(JsonConvert.SerializeObject(obj, Formatting.Indented), "CallSite:MainWindowViewModel.CallBack");
        }

        public ICommand CustomOpenDialogCommand { get; }

        private void CustomOpenDialog()
        {
            DialogService.Instance.Show(new ViewA(), null, CallBack,()=>new MyDialogWindow());
        }
    }
}
