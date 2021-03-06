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
    /// Interaction logic for CreateVerkiezing.xaml
    /// </summary>
    public partial class CreateVerkiezing : Window
    {
        VerkiezingenDB _verkiezingenDB = new VerkiezingenDB();

        public CreateVerkiezing()
        {
            InitializeComponent();
            FillComboBox();
        }

        private void FillComboBox()
        {
            DataTable verkiezingsoorten = _verkiezingenDB.SelectVerkiezingsoorten();

            cmbVerkiezingssoort.ItemsSource = verkiezingsoorten.DefaultView;
        }

        private void BtnAddVerkiezingen_Click(object sender, RoutedEventArgs e)
        {
            DataRowView verkiezingsoortData = (DataRowView) cmbVerkiezingssoort.SelectedItem;

            if (verkiezingsoortData == null)
            {
                MessageBox.Show("Selecteer een verkiezingsoort!", "Melding", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (dpDatum.SelectedDate.HasValue == false)
            {
                MessageBox.Show("Selecteer een datum!", "Melding", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (verkiezingsoortData != null && dpDatum.SelectedDate.HasValue == true)
            {
                string selectedDate = dpDatum.SelectedDate.Value.ToString("yyyy/MM/dd");
                _verkiezingenDB.CreateVerkiezing(verkiezingsoortData["SoortId"].ToString(), verkiezingsoortData["Verkiezingsoort"].ToString(), selectedDate);
                this.Close();
            }
        }
    }
}
