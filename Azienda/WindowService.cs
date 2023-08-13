using AppBase.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azienda.Views;

namespace AppBase
{
    public static class WindowService
    {
        static public  void ShowDialog(string titolo, BaseViewModel viewModel, double? width = null, double? height = null)
        {
            WindowServiceView window = new WindowServiceView()
            {
                DataContext = viewModel
            };

            if(width != null)
            {
                window.Width = width.Value;
                if (height != null)
                    window.Height = height.Value;
            }

            window.ShowDialog();
            
        }   
    }
}
