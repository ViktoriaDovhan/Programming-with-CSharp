using Lab01.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace Lab01.View
{
    public partial class BirthdayAppView : UserControl
    {
        public BirthdayAppView()
        {
            InitializeComponent();
            DataContext = new BirthdayAppViewModel();
        }
    }
}
