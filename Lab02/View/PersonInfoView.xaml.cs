using System.Windows.Controls;
using Lab02.ViewModel;

namespace Lab02.View
{
    /// <summary>
    /// Interaction logic for PersonInfoView.xaml
    /// </summary>
    public partial class PersonInfoView : UserControl
    {
        public PersonInfoView()
        {
            InitializeComponent();
            DataContext = new PersonInfoViewModel(); 
        }
    }
}
