using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Projet_C_Sharp
{
    public partial class Form1 : Form
    {
        Arbre_binaire Arbre= new Arbre_binaire();
        List<Noeud> ListeDesNoeud;
        FileStream fichier;

        // Printing the symbols and codes of the Nodes on the tree.
         public static void PrintfLeafAndCodes(Noeud Noeud,ListBox l)
        {
           

            if (Noeud == null)
                return;
            if (Noeud.NoeudGauche == null && Noeud.NoeudDroit == null)
            {
                l.Items.Add("Clé : " + Noeud.Cle + " -  " + "Code : " + Noeud.Code);
                
                return;
            }

            PrintfLeafAndCodes(Noeud.NoeudGauche,l);
            PrintfLeafAndCodes(Noeud.NoeudDroit,l);
        }

         public static void PrintfLeafAndCodes(Noeud Noeud, TextBox t)
         {


             if (Noeud == null)
                 return;
             if (Noeud.NoeudGauche == null && Noeud.NoeudDroit == null)
             {
                 t.Text= Noeud.Code;

                 return;
             }

             PrintfLeafAndCodes(Noeud.NoeudGauche, t);
             PrintfLeafAndCodes(Noeud.NoeudDroit, t);
         }


        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            fichier = new FileStream(textBox1.Text, FileMode.Open, FileAccess.Read);
            List<Noeud> LISTE;
            List<string> ListeString = new List<string>();
            ListeDesNoeud = new List<Noeud>();
            Arbre.AvoirListeDuFichier(textBox1.Text, out LISTE);
            ListeDesNoeud = LISTE;
            foreach (var item in ListeDesNoeud)
            {
                listBox1.Items.Add("Clé:" + item.Cle + " - " + "Frequence: " + item.Frequence);
           
           
            }
            listBox1.Items.Add("");
            listBox1.Items.Add("");

            

            for (int i = 0; i < ListeDesNoeud.Count; i++)
            {
                Arbre.AvoirArbreDeListe(ListeDesNoeud);
                  Arbre.MettreCodeDeArbre("",ListeDesNoeud[i]);
                 PrintfLeafAndCodes(ListeDesNoeud[i], listBox1);
                
            }

            for (int i = 0; i < ListeDesNoeud.Count; i++)
            {
                PrintfLeafAndCodes(ListeDesNoeud[i], textBox2);
            }
             
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
             double taille;
            openFileDialog1.FileName = null;
        this.openFileDialog1.ShowDialog();
       
        if (openFileDialog1.FileName != null)
            {
            this.textBox1.Text = this.openFileDialog1.FileName;
                fichier = new FileStream(textBox1.Text, FileMode.Open,FileAccess.Read);
                taille=fichier.Length;
                 

            if(taille>1024)
                 { 
                
		         taille=taille/1024;
                 this.label2.Text = "Taille originale du Fichier :" + taille + " " + "Ko";
                 }

            else if (taille > Math.Pow(1024,2))
                    {
                taille=taille/Math.Pow(1024,2);
                this.label2.Text = "Taille originale du Fichier :" + taille + " " + "Mo";
	                 }

                   else if(taille > Math.Pow(1024,3))
	                    {
                    taille=taille/Math.Pow(1024,3);
                    this.label2.Text = "Taille originale du Fichier :" + taille + " " + "Go";
	                    }

            else
            {
                this.label2.Text = "Taille originale du Fichier :" + taille + " " + "Octets";
            }
                    
            }
            }
           
 

        }
    }

