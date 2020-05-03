using Radzen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Faitout.Pages;

namespace Faitout.Tools
{
    public static class DialogsTools
    {
        public static void OpenConfirmDialog(this DialogService dialogService, string title, string message, object parameter)
        {
            dialogService.Open<ConfirmDialog>(title, new Dictionary<string, object>() {
            { nameof(ConfirmDialog.Message), message},
            { nameof(ConfirmDialog.Object), parameter},
            { nameof(ConfirmDialog.DialogService), dialogService}});
        }
    }
}
