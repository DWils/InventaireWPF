using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using inventaireWPF.Model;
using inventaireWPF.Tools;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace inventaireWPF.ViewModel
{
    public class ArticlesViewModel : ViewModelBase
    {

        private List<Categorie> categoryList;
        private int selectedCategoryId = 0;
        private List<Article> articleList;
        private Article newArticle;
        private Article selectedArticle;
        private int maxQty = 0;
        private int qty = 0;

        public ICommand AddArticleCommand { get; set; }
        public ICommand GetArticleCommand { get; set; }

        public Action CloseAction { get; set; }


        public string Nom
        {
            get => newArticle.Nom;
            set => newArticle.Nom = value;
        }

        public string Description
        {
            get => newArticle.Description;
            set => newArticle.Description = value;
        }

        public int CategoryId
        {
            get => newArticle.CategorieId;
            set => newArticle.CategorieId = value;
        }

        public int Quantite
        {
            get => newArticle.Quantite;
            set => newArticle.Quantite = value;
        }

        public Article SelectedArticle
        {
            get
            {
                return selectedArticle;
            }
            set
            {
                selectedArticle = value;
                RaisePropertyChanged("SelectedArticle");
                RaisePropertyChanged("MaxQty");
                getMaxQty();
            } 
        }

        

        public int Qty
        {
            get => qty;
            set
            {
                qty = value;
                RaisePropertyChanged("Qty");
            }
        }

        public ArticlesViewModel()
        {
            Categorie categorie = new Categorie();
            CategoryList = categorie.getCategories();
            newArticle = new Article();
            SelectedArticle = new Article();
            AddArticleCommand = new RelayCommand(Save);
            GetArticleCommand = new RelayCommand(Update);
            
        }

        public void Update()
        {

            SelectedArticle.Update(SelectedArticle.Nom, Qty);
            SelectedArticle = new Article();
            RaisePropertyChanged("Nom");
            RaisePropertyChanged("Quantite");
            RaisePropertyChanged("CategoryId");
            CloseAction();
        }

        public void Save()
        {
            newArticle.Save(newArticle);
            newArticle = new Article();
            RaisePropertyChanged("Nom");
            RaisePropertyChanged("Description");
            RaisePropertyChanged("Quantite");
            RaisePropertyChanged("CategoryId");
            CloseAction();

        }


        // Liste des Categories
        public List<Categorie> CategoryList
        {
            get => categoryList;
            set
            {
                categoryList = value;
                RaisePropertyChanged("CategoryList");
            }
        }
        public int SelectedCategoryId
        {
            get => selectedCategoryId;
            set
            {
                selectedCategoryId = value;
                RaisePropertyChanged("SelectedCategoryId");
                RaisePropertyChanged("AllowArticleSelection");
                getArticles();
            }
        }

        // Liste des Articles
        public List<Article> ArticleList
        {
            get => articleList;
            set
            {
                articleList = value;
                RaisePropertyChanged("ArticleList");
            }
        }

        public int MaxQty
        {
            get => maxQty;
            set
            {
                maxQty = value;
                RaisePropertyChanged("MaxQty");
            }
        }

        public bool AllowArticleSelection
        {
            get => (SelectedCategoryId > 0);
        }
        

        public void getArticles()
        {
            Article article = new Article();
            ArticleList = article.getArticleByCategoryId(SelectedCategoryId);
        }

        public void getMaxQty()
        {
            Article article = new Article();
            MaxQty = article.getMaxQtyByArticle(SelectedArticle);
        }

      

       
    }
}
