using inventaireWPF.Tools;
using System;
using System.Collections.Generic;
using System.Linq;

namespace inventaireWPF.Model
{
    public class Categorie
    {
        private int id;
        private string nom;

        public string Nom { get => nom; set => nom = value; }
        public int Id { get => id; set => id = value; }

        public List<Categorie> getCategories()
        {
            List<Categorie> returnCategories = new List<Categorie>();
            InventaireDBContext idb = new InventaireDBContext();
            foreach (var cat in idb.Categorie.ToList())
            {
                returnCategories.Add(cat);
            }
            return returnCategories;
        }
    }
}