using inventaireWPF.ViewModel;
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

namespace inventaireWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AjoutArticleBtn_Click(object sender, RoutedEventArgs e)
        {
            AjoutArticle viewAjout = new AjoutArticle();
            viewAjout.Show();
        }

        private void PrendreArticleBtn_Click(object sender, RoutedEventArgs e)
        {
            PrendreArticle viewPrendre = new PrendreArticle();
            viewPrendre.Show();
        }
    }
}
