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
using System.Text.RegularExpressions;
using WpfProject3.Classes;

namespace WpfProject3
{
    /// <summary>
    /// Interaction logic for CreatePolitiekePartij.xaml
    /// </summary>
    public partial class CreatePolitiekePartij : Window
    {
        VerkiezingenDB _verkiezingenDB = new VerkiezingenDB();

        public CreatePolitiekePartij()
        {
            InitializeComponent();
        }

        private void BtnAddPolitiekePartij_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(txbPartijnaam.Text))
            {
                MessageBox.Show("Voer een partijnaam in!", "Melding", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (!string.IsNullOrEmpty(txbPartijnaam.Text))
            {
                _verkiezingenDB.CreatePolitiekePartij(txbPartijnaam.Text, txbAdres.Text, txbPostcode.Text, txbGemeente.Text, txbEmail.Text, txbTelefoon.Text);
                this.Close();
            }
        }

        
    }
}
