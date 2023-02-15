using gaiEntiry.ViewModel;
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
using System.Windows.Shapes;

namespace gaiEntiry.Edit
{
    /// <summary>
    /// Interaction logic for EditRankView.xaml
    /// </summary>
    public partial class EditRankView : Window
    {
        public EditRankView(Rank rankToEdit)
        {
            InitializeComponent();
            DataContext = new RepositoriesVM();
            RepositoriesVM.SelectedRank = rankToEdit;
            RepositoriesVM.RankRank1 = rankToEdit.Rank1;
        }
    }
}
