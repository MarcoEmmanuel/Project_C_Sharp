using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_Sharp
{
     public class Noeud : IComparable<Noeud>
    {       public Noeud NoeudDroit;
            public Noeud NoeudGauche;
            public Noeud NoeudParent;
            private string cle;
            private int frequence;
            private string code;
            private bool etrefeuille;


        public Noeud(string valeur)    // Crée un noeud avec une valeur(de caractère).
        {
            cle = valeur;     // attribue le caractere.
            frequence= 1;      // A la creation d'un noeud ,Sa frequence est a  1.
            
            NoeudDroit = NoeudGauche = NoeudParent = null;       // n'a pas de parent ni de noeud a gauche ni a droite.

            code = "";          // It will be Assigned on the making Tree. Now it is empty.
            etrefeuille = true;      // Because all Node we create first does not have a parent Node.
        }


        public Noeud(Noeud noeud1, Noeud noeud2) // joint les 2 noeuds pour un faire 2.
        {
            // Firsly we are adding this 2 Nodes' variables. Except the new Node's left and right tree.
            code = "";
            etrefeuille = false;
            NoeudParent = null;

            // Now the new Node need leaf. They are node1 and node2. if node1's frequency is bigger than or equal to node2's frequency. It is right tree. Otherwise left tree. The controllers are below:
            if (noeud1.frequence >= noeud2.frequence)
            {
                NoeudDroit = noeud1;
                NoeudGauche = noeud2;
                NoeudDroit.NoeudParent = NoeudGauche.NoeudParent = this;     // "this" means the new Node!
                cle = noeud1.cle + noeud2.cle;
                frequence = noeud1.frequence + noeud2.frequence;
            }
            else if (noeud1.frequence < noeud2.frequence)
            {
                NoeudDroit = noeud2;
                NoeudGauche = noeud1;
                NoeudGauche.NoeudParent = NoeudDroit.NoeudParent = this;     // "this" means the new Node!
                cle = noeud2.cle + noeud1.cle;
                frequence = noeud2.frequence + noeud1.frequence;
            }
        }

            public void AugmenterFrequencer() // Face a un meme une meme valeur dans la liste on incremente la frequence de ce noeud
            {
                frequence++;
            }

            public int CompareTo( Noeud autreNoeud)
            {
                // TODO: implement
                return this.frequence.CompareTo(autreNoeud.frequence);
            }

        #region Accesseurs
        public string Cle
        {
            get { return cle; }
            set { cle = value; }
        }

        public int Frequence
        {
            get { return frequence; }
            set { frequence = value; }
        }

        public string Code
        {
            get { return code; }
            set { code = value; }
        }
#endregion
     }
 }
