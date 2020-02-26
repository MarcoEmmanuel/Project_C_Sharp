using System;
using System.Collections.Generic;
using System.Collections;
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
       public static List<Noeud> liste;
        static FileStream fichier;

         static List<Noeud> LISTE;
            
        // Printing the symbols and codes of the Nodes on the tree.
         public static void PrintfLeafAndCodes(Noeud Noeud,ListBox l, TextBox t,List<Noeud> liste,string TEXT)
        {
           fichier= new FileStream(TEXT,FileMode.Open, FileAccess.Read);
           int ind;
            if (Noeud == null)
                return;
            if (Noeud.NoeudGauche == null && Noeud.NoeudDroit == null)
            {
                l.Items.Add("Clé : " + Noeud.Cle + " -  " + "Code : " + Noeud.Code);

                  for (int i = 0; i < fichier.Length; i++)
                {
                    string lu = Convert.ToChar(fichier.ReadByte()).ToString(); // lecture d'un caractere
                    if (liste.Exists(noeud => noeud.Cle == lu)) // est ce que le caractere a ete crée bien avant?
                    {
                        ind = liste.FindIndex(noeud => noeud.Cle == lu); // si oui, cherche l'index du noeud et augmente sa fréquence

                        t.AppendText(liste[ind].Code);
                    }
                     

                }
                        
                 return;
             }


            PrintfLeafAndCodes(Noeud.NoeudGauche,l,t,liste,TEXT);
            PrintfLeafAndCodes(Noeud.NoeudDroit,l,t,liste,TEXT);
        }

         public static void RecupererChaqueCodeCaractere(String Nomfichier, List<Noeud> ListeDesNoeud, TextBox t)
         {
             fichier = new FileStream(Nomfichier, FileMode.Open, FileAccess.Read);
             int ind;

                 for (int i = 0; i < fichier.Length; i++)
                 {
                     string lu = Convert.ToChar(fichier.ReadByte()).ToString(); // lecture d'un caractere
                     if (ListeDesNoeud.Exists(noeud => noeud.Cle == lu)) // est ce que le caractere a ete crée bien avant?
                     {
                         ind = ListeDesNoeud.FindIndex(noeud => noeud.Cle == lu); // si oui, cherche l'index du noeud et augmente sa fréquence
                         
                         t.AppendText(ListeDesNoeud[ind].Code);
                     }


                 }
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
            
            List<string> ListeString = new List<string>();
            liste = new List<Noeud>();
            Noeud noeudS = new Noeud("");
            Arbre.AvoirListeDuFichier(textBox1.Text, out LISTE);
            liste = LISTE.ToList();

            foreach (var item in liste)
            {
                listBox1.Items.Add("Clé:" + item.Cle + " - " + "Frequence: " + item.Frequence);
           
           
            }
            listBox1.Items.Add("");
            listBox1.Items.Add("");

            textBox2.Text = "";
 
            for (int i = 0; i < liste.Count; i++)
            {
                Arbre.AvoirArbreDeListe(liste);
                  Arbre.MettreCodeDeArbre("",liste[i],out noeudS);
                 
                 PrintfLeafAndCodes(liste[i], listBox1, textBox2,liste,textBox1.Text);
                
                 LISTE.Add(noeudS);
                 RecupererChaqueCodeCaractere(textBox1.Text,LISTE,textBox2);
            }


            int bits;
            bits = textBox2.TextLength;
            label3.Text = " Taille du fichier compressé  :" + bits + " Bits";

            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
             double taille;
            openFileDialog1.FileName = null;
        this.openFileDialog1.ShowDialog();
       
        if (openFileDialog1.FileName != null)
            {
            this.textBox1.Text = this.openFileDialog1.FileName;
                fichier = new FileStream(textBox1.Text, FileMode.Open,FileAccess.Read);
                textBox3.Text = File.ReadAllText(textBox1.Text);
                {

                }
                taille=fichier.Length*8;
                 

            //if(taille>1024)
            //     { 
                
            //     taille=taille/1024;
            //     this.label2.Text = "Taille originale du Fichier :" + taille + " " + "Ko";
            //     }

            //else if (taille > Math.Pow(1024,2))
            //        {
            //    taille=taille/Math.Pow(1024,2);
            //    this.label2.Text = "Taille originale du Fichier :" + taille + " " + "Mo";
            //         }

            //       else if(taille > Math.Pow(1024,3))
            //            {
            //        taille=taille/Math.Pow(1024,3);
            //        this.label2.Text = "Taille originale du Fichier :" + taille + " " + "Go";
            //            }

            //else
            //{
                this.label2.Text = "Taille originale du Fichier :" + taille + " " + "Bits";
            //}
                    
            }
            }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            string Code_Cle="";
            foreach (char bit in textBox2.Text)
            {
                Code_Cle = Code_Cle + bit;
                for (int i = 0; i < LISTE.Count; i++)
                {
                    if (Code_Cle==LISTE[i].Code)
                    {
                        textBox4.AppendText(LISTE[i].Cle);
                        int taille = textBox4.TextLength;
                        label4.Text = "Taille du fichier décompressé : " + taille*8 + " Bits";
                        Code_Cle = "";
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
           
 

        }
    }

