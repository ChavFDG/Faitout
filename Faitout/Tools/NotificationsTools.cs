using Radzen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Faitout.Pages;
using Faitout.Data;
using MatBlazor;

namespace Faitout.Tools
{
    public static class NotificationsTools
    {
        public static void NotifySuccess(this IMatToaster toaster, string title, string message)
        {
            toaster.Add(message, MatToastType.Success, title);
       }
        public static void NotifyFail(this IMatToaster toaster, string title, string message)
        {
            toaster.Add(message, MatToastType.Danger, title);
         }
        public static void NotifyResult(this IMatToaster toaster, Result result, string dataName)
        {
            if(result.OperationPass)
            {
                toaster.NotifySuccess("Modification effectuée", dataName + " sauvegardé avec succès");
            }
            else
            {
                toaster.NotifyFail("Echec de la modification", dataName +" n'a pu être modifié." + "\n\r"+result.ErrorMessage);
            }
        }


    }
}
