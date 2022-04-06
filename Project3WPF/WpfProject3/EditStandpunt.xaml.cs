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
    /// Interaction logic for EditStandpunt.xaml
    /// </summary>
    public partial class EditStandpunt : Window
    {
        VerkiezingenDB _verkiezingenDB = new VerkiezingenDB();

        public EditStandpunt(DataRowView standpunt)
        {
            InitializeComponent();
            FillComboBoxes();

            tbStandpuntId.Text = standpunt["StandpuntId"].ToString();
            cmbPolitiekePartij.SelectedValue = standpunt["PartijId"].ToString();
            cmbThema.SelectedValue = standpunt["ThemaId"].ToString();
            txbStandpunt.Text = standpunt["Standpunt"].ToString();
        }

        private void FillComboBoxes()
        {
            DataTable partijen = _verkiezingenDB.SelectPolitiekePartijen();
            DataTable themas = _verkiezingenDB.SelectThemas();

            cmbPolitiekePartij.ItemsSource = partijen.DefaultView;
            cmbThema.ItemsSource = themas.DefaultView;
        }

        private void BtnEditStandpunt_Click(object sender, RoutedEventArgs e)
        {
            DataRowView partijData = (DataRowView)cmbPolitiekePartij.SelectedItem;
            DataRowView themaData = (DataRowView)cmbThema.SelectedItem;

            if (partijData == null)
            {
                MessageBox.Show("Selecteer een partij!", "Melding", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (themaData == null)
            {
                MessageBox.Show("Selecteer een thema!", "Melding", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (string.IsNullOrEmpty(txbStandpunt.Text))
            {
                MessageBox.Show("Voer een standpunt in!", "Melding", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (partijData != null && themaData != null && !string.IsNullOrEmpty(txbStandpunt.Text))
            {
                _verkiezingenDB.EditStandpunt(tbStandpuntId.Text, partijData["PartijId"].ToString(), partijData["PartijName"].ToString(), themaData["ThemaId"].ToString(), themaData["Thema"].ToString(), txbStandpunt.Text);
                this.Close();
            }
        }
    }
}
