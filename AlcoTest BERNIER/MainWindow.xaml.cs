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

namespace AlcoTest_BERNIER
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CBuveur buveur;

        private string[] listeboisson = { "Bière", "Vodka", "Rhum", "Tequila", "Gin", "Wisky" };

        public MainWindow()
        {



            InitializeComponent();

            foreach (string boisson in listeboisson)
            {
                Cboisson.Items.Add(boisson);
            }
            Cboisson.Text = Cboisson.Items[0] as string;


        }

        public void Maj_Conduite()
        {
            double taux = buveur.get_alcoolemie();
            double conduite = 0;
            double temp = 0;
            

            conduite = taux;

            if (conduite > 0.5)
                do
                {
                    if (Homme.IsChecked == true)
                    {
                        conduite = conduite - 0.1;
                        temp++;
                    }
                    else
                    {
                        conduite = conduite - 0.085;
                        temp++;
                    }

                } while (conduite > 0.5);

            Conduite.Text = Math.Round(temp + 0.5, 2).ToString() + " H";
        }

        public void Maj_Elimination()
        {
            double taux = buveur.get_alcoolemie();
            double elimination = 0;

            if (Homme.IsChecked == true)
            {
                elimination = taux / 0.10;
            }
            else if (Femme.IsChecked == true)
            {
                elimination = taux / 0.085;
            }
            Elimination.Text = Math.Round(elimination, 2).ToString() + " Heures";
        }

        public void Maj_Alcool()
        {
            if (buveur != null)
            {
                int qte = Convert.ToInt32(Qte.Text);
                double taux = Convert.ToDouble(Taux.Text);

                buveur.MAJ_alcoolemie(qte, taux);

                TauxAlcool.Text = buveur.get_alcoolemie().ToString();

                buveur.list.Add(Cboisson.SelectionBoxItem + " " + Qte.Text + "cl " + Taux.Text + "%");

                Liste_Alcool.Items.Add(buveur.list[buveur.i]);
                buveur.i++;
                Maj_Elimination();
                Maj_Conduite();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool ready = false;

            Maj_Alcool();


            if (buveur == null)
            {

                if (Homme.IsChecked == false && Femme.IsChecked == false)
                {
                    MessageBox.Show("Merci de chosir un sexe");
                    ready = false;
                }
                if (Poid.Text == "")
                {
                    MessageBox.Show("Merci d'entrer une valeur de poid");
                    ready = false;
                }
                else
                {
                    ready = true;
                }
            }


            if (buveur == null && ready == true)
            {

                bool homme = true;

                int poid = Convert.ToInt32(Poid.Text);


                if (Homme.IsChecked == true)
                {
                    homme = true;
                }
                if (Femme.IsChecked == true)
                {
                    homme = false;
                }


                buveur = new CBuveur(homme, poid);
                buveur.reset_alcoolemie();

                buveur.i = 0;

                Maj_Alcool();

            }

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (buveur != null)
            {
                TauxAlcool.Text = "";
                Elimination.Text = "";
                Conduite.Text = "";
                Liste_Alcool.Items.Clear();
                buveur = null;
                GC.Collect();
            }
        }

        private void Boisson_TextUpdate(object sender, EventArgs e)
        {

            switch (Cboisson.SelectedItem)
            {
                case "Bière":
                    Taux.Text = "7";
                    Qte.Text = "33";
                    break;

                case "Vodka":
                    Taux.Text = "40";
                    Qte.Text = "2";
                    break;

                case "Rhum":
                    Taux.Text = Convert.ToString(37.5);
                    Qte.Text = Convert.ToString(2);
                    break;

                case "Tequila":
                    Taux.Text = Convert.ToString(35);
                    Qte.Text = Convert.ToString(2);
                    break;

                case "Gin":
                    Taux.Text = Convert.ToString(37.5);
                    Qte.Text = Convert.ToString(2);
                    break;

                case "Wisky":
                    Taux.Text = Convert.ToString(40);
                    Qte.Text = Convert.ToString(2);
                    break;
            }
        }

    }
}
