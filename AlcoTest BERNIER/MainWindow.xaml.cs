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

        private string[] listeboisson = { "Bière", "Vodka", "Rhume", "Tequila", "Gin", "Wisky" };

        public MainWindow()
        {

            

            InitializeComponent();
            
            foreach (string boisson in listeboisson)
            {
                Cboisson.Items.Add(boisson);
            }
            Cboisson.Text = Cboisson.Items[0] as string;


        }

        public void Maj_Alcool()
        {
            if (buveur != null)
            {
                int qte = Convert.ToInt32(Qte.Text);
                double taux = Convert.ToDouble(Taux.Text);

                buveur.MAJ_alcoolemie(qte, taux);


                TauxAlcool.Text = buveur.get_alcoolemie().ToString();

                buveur.list.Add(Cboisson.SelectionBoxItem+" "+Qte.Text+"cl "+Taux.Text+"%");


                TextBox test = new TextBox();
                test.Name = "Liste_" + buveur.i.ToString();
                test.Text = buveur.list[buveur.i];
                Liste_Alcool.Items.Add(buveur.list[buveur.i]);
                buveur.i++;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Maj_Alcool();

            if (buveur == null)
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
                buveur.reset_alcoolemie();
                TauxAlcool.Text = buveur.get_alcoolemie().ToString();
                buveur.list.Clear();
                Liste_Alcool.Items.Clear();
                buveur.i = 0;


            }
        }

        private void boisson_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string boisson = String.Format(Cboisson.SelectionBoxItem.ToString());

            switch (boisson)
            {
                case "Bière":
                    Qte.Text = Convert.ToString(7);
                    case "Vodkha:"
            }
        }
    }
}
