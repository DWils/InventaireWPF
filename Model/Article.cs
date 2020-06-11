using inventaireWPF.Tools;
using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
using System.Windows;

namespace inventaireWPF.Model
{
    public class Article
    {
        private int id;

        private string nom;
        
        private int categorieId;

        private string description;

        private int quantite;

        public string Nom { get => nom; set => nom = value; }
        public int CategorieId { get => categorieId; set => categorieId = value; }
        public string Description { get => description; set => description = value; }
        public int Id { get => id; set => id = value; }
        public int Quantite { get => quantite; set => quantite = value; }

        public List<Article> getArticleByCategoryId(int catId)
        {
            List<Article> returnArticles = new List<Article>();
            InventaireDBContext idb = new InventaireDBContext();
            foreach (var art in idb.Article.Where(x => x.CategorieId == catId).Where(x => x.Quantite > 0).ToList())
            {
                returnArticles.Add(art);
            }
            return returnArticles;
        }


        public void Save(Article articleToSave)
        {
            InventaireDBContext idb = new InventaireDBContext();
            List<Article> currentArticleList = idb.Article.ToList();
            Article AlreadySavedArticle = currentArticleList.FirstOrDefault(x => x.Nom == articleToSave.Nom);
            if (AlreadySavedArticle == null)
            {
                idb.Article.Add(articleToSave);
                MessageBox.Show($"{articleToSave.Nom} sauvegardé(e)");
            }
            else
            {
                AlreadySavedArticle.Quantite += articleToSave.Quantite;
                MessageBox.Show($"{articleToSave.Nom} déjà présent(e) dans l'inventaire, quantité a été mise à jour");
            }
            idb.SaveChanges();
        }

        public void Update(string articleName, int qty)
        {
            InventaireDBContext idb = new InventaireDBContext();
            Article ArticleToUpdateQty = idb.Article.FirstOrDefault(x => x.Nom == articleName);
            if (ArticleToUpdateQty != null)
            {
                int MemoQty = ArticleToUpdateQty.Quantite;
                ArticleToUpdateQty.Quantite -= qty;
                MessageBox.Show($"{articleName} est passé de {MemoQty} à {ArticleToUpdateQty.Quantite}");
                idb.SaveChanges();
            }
        }

        public int getMaxQtyByArticle(Article selectedArticle)
        {
            
            InventaireDBContext idb = new InventaireDBContext();
            Article ArticleToUpdateQty = idb.Article.FirstOrDefault(x => x.Nom == selectedArticle.Nom);
            if (ArticleToUpdateQty != null)
            {
                return ArticleToUpdateQty.Quantite;
            }
            return 0;
            
        }
    }
}

