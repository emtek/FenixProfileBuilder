using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GpfEditor.ViewModels;

namespace GpfEditor.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {

        public Home()
        {
            InitializeComponent();
            this.DataContext = new HomeViewModel();
            
        }

        private void ModernButton_Click(object sender, RoutedEventArgs e)
        {
            GpfTools.GpfUtil.SaveToRepository();
        }

        private void ModernButton_Click_1(object sender, RoutedEventArgs e)
        {
            GpfTools.GpfUtil.SaveToDevice();
        }

       

    }
}
