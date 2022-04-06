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
using System.Data;
using WpfProject3.Classes;

namespace WpfProject3
{
    /// <summary>
    /// Interaction logic for EditPolitiekePartij.xaml
    /// </summary>
    public partial class EditPolitiekePartij : Window
    {
        VerkiezingenDB _verkiezingenDB = new VerkiezingenDB();

        public EditPolitiekePartij(DataRowView partij)
        {
            InitializeComponent();

            tbPartijId.Text = partij["PartijId"].ToString();
            txbPartijnaam.Text = partij["PartijName"].ToString();
            txbAdres.Text = partij["Adres"].ToString();
            txbPostcode.Text = partij["Postcode"].ToString();
            txbGemeente.Text = partij["Gemeente"].ToString();
            txbEmail.Text = partij["EmailAdres"].ToString();
            txbTelefoon.Text = partij["Telefoonnummer"].ToString();
        }

        private void BtnEditPolitiekePartij_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txbPartijnaam.Text))
            {
                MessageBox.Show("Voer een partijnaam in!", "Melding", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (!string.IsNullOrEmpty(txbPartijnaam.Text))
            {
                _verkiezingenDB.EditPolitiekePartij(tbPartijId.Text, txbPartijnaam.Text, txbAdres.Text, txbPostcode.Text, txbGemeente.Text, txbEmail.Text, txbTelefoon.Text);
                this.Close();
            }
        }
    }
}
