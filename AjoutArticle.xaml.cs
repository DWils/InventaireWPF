﻿using inventaireWPF.ViewModel;
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

namespace inventaireWPF
{
    /// <summary>
    /// Logique d'interaction pour AjoutArticle.xaml
    /// </summary>
    public partial class AjoutArticle : Window
    {
        public AjoutArticle()
        {
            InitializeComponent();
            ArticlesViewModel vm = new ArticlesViewModel();
            this.DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }
    }
}
