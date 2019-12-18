using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Projet_C_Sharp
{
      public class Arbre_binaire
    {
         public List<Noeud> ListeNoeud; // cree une liste de noeud

        // creation d'une liste qui lira les caracteres du fichier
          public  void AvoirListeDuFichier(string NomDuFichier, out List<Noeud> Liste)
        {
            Liste = null;
      ListeNoeud=new List<Noeud>();
      
                FileStream fichier = new FileStream(NomDuFichier, FileMode.Open, FileAccess.Read); // effectue une lecture du fichier choisie

                for (int i = 0; i < fichier.Length; i++)
                {
                    string lu = Convert.ToChar(fichier.ReadByte()).ToString(); // lecture d'un caractere
                    if (ListeNoeud.Exists(noeud=> noeud.Cle == lu)) // est ce que le caractere a ete crée bien avant?
                    {
                        ListeNoeud[ListeNoeud.FindIndex(noeud => noeud.Cle == lu)].AugmenterFrequencer(); // si oui, cherche l'index du noeud et augmente sa fréquence
                    }
                    else
                    {
                        ListeNoeud.Add(new Noeud(lu)); // Sinon cree un nouveau noeud et ajoute dans la liste des noeuds
                    }

                }

                ListeNoeud.Sort();  // Trie les noeuds de la liste en fonction de leur frequence
                Liste = ListeNoeud;
            
            
            
        }

        // Creation d'un arbre en fonction des noeuds(clé, frequence)
        public void AvoirArbreDeListe(List<Noeud> listenoeud)
        {
            Noeud NouveauNoeud;
            
            int ind;
            while (listenoeud.Count > 1)
            {
                
                Noeud noeud1 = listenoeud[0];  // recupere le noeud du 1er index de la liste
                listenoeud.RemoveAt(0);         // supprime le
                Noeud noeud2 = listenoeud[0];     // recupere le noeud du 1er index de la liste
                listenoeud.RemoveAt(0);         // supprime le
                NouveauNoeud = new Noeud(noeud1, noeud2);//cree un nouveau noeud a partir des deux noeuds
                listenoeud.Add(NouveauNoeud);   // Ajouter le nouveau noeud dans la liste 
                listenoeud.Sort(); // range encore en fonction des frequences
                ind= listenoeud.FindIndex(x => x.Cle == NouveauNoeud.Cle); // recupere l'index du nouveau noeud
               

                for (int i = 0; i < listenoeud.Count; i++)
                {

                    if (listenoeud[ind].Frequence == listenoeud[i].Frequence && i<ind)
                    {
                        listenoeud.Reverse();
                    }
                }
            }
        }

        // Mise en place des codes des noeuds de l'arbre
        public void MettreCodeDeArbre(string code, Noeud noeud)
        {
            if (noeud == null)
                return;
            if (noeud.NoeudGauche == null && noeud.NoeudDroit == null)
            {
                noeud.Code = code;
                return;
            }

            MettreCodeDeArbre(code + "0", noeud.NoeudGauche);
            MettreCodeDeArbre(code + "1",noeud.NoeudDroit);
        }


        //  Ecrire chaque information d'un noeud de la Liste des noeuds
        public void EcrireInformation(List<Noeud> ListeNoeud, out string Ecriture)
        {
            Ecriture = "";
            foreach (var item in ListeNoeud)
               Ecriture="Symbol :" + item.Cle + " - " + "Frequency : " + item.Frequence ;
              
        }


        // Printing the symbols and codes of the Nodes on the tree.
        public void PrintfLeafAndCodes(Noeud Noeud, out List<string> noeud)
        {
            noeud = new List<string>();
         
            if (Noeud == null)
                return;
            if (Noeud.NoeudGauche == null && Noeud.NoeudDroit == null)
            {
                noeud.Add( "Symbol : " +Noeud.Cle +" -  " + "Code : " + Noeud.Code);
                return;
            }
            
            PrintfLeafAndCodes(Noeud.NoeudGauche, out noeud);
            PrintfLeafAndCodes(Noeud.NoeudDroit, out noeud);
        }
    }
}
