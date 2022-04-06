using System;
using System.Collections.Generic;
using System.Data;
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
using WpfProject3.Classes;

namespace WpfProject3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VerkiezingenDB _verkiezingenDB = new VerkiezingenDB();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void FillDataGridPolitiekePartij()
        {
            DataTable partijen = _verkiezingenDB.SelectPolitiekePartijen();

            if (partijen != null)
            {
                dgPolitiekePartijen.ItemsSource = partijen.DefaultView;
                dgPolitiekePartijen.Focus();
            }
        }

        private void FillDataGridStandpunten()
        {
            DataTable standpunten = _verkiezingenDB.SelectStandpunten();

            if (standpunten != null)
            {
                dgStandpunten.ItemsSource = standpunten.DefaultView;
            }
        }

        private void FillDataGridVerkiezingen()
        {
            DataTable verkiezingen = _verkiezingenDB.SelectVerkiezingen();

            if (verkiezingen != null)
            {
                dgVerkiezingen.ItemsSource = verkiezingen.DefaultView;
            }
        }

        private void tcContent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                if (tiPolitiekePartijen.IsSelected)
                {
                    FillDataGridPolitiekePartij();
                }

                if (tiStandpunten.IsSelected)
                {
                    FillDataGridStandpunten();
                }

                if (tiVerkiezingen.IsSelected)
                {
                    FillDataGridVerkiezingen();
                }
            }
        }

        private void BtnAddPolitiekePartij_Click(object sender, RoutedEventArgs e)
        {
            CreatePolitiekePartij createPolitiekePartij = new CreatePolitiekePartij();
            createPolitiekePartij.ShowDialog();
            FillDataGridPolitiekePartij();
        }

        private void BtnAddStandpunt_Click(object sender, RoutedEventArgs e)
        {
            CreateStandpunt createStandpunt = new CreateStandpunt();
            createStandpunt.ShowDialog();
            FillDataGridStandpunten();
        }

        private void BtnAddVerkiezing_Click(object sender, RoutedEventArgs e)
        {
            CreateVerkiezing createVerkiezing = new CreateVerkiezing();
            createVerkiezing.ShowDialog();
            FillDataGridVerkiezingen();
        }

        private void BtnEditPolitiekePartij_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = dgPolitiekePartijen.SelectedItem as DataRowView;

            EditPolitiekePartij editPolitiekePartij = new EditPolitiekePartij(selectedRow);
            editPolitiekePartij.ShowDialog();
            FillDataGridPolitiekePartij();
        }

        private void BtnEditStandpunt_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = dgStandpunten.SelectedItem as DataRowView;

            EditStandpunt editStandpunt = new EditStandpunt(selectedRow);
            editStandpunt.ShowDialog();
            FillDataGridStandpunten();
        }

        private void BtnEditVerkiezing_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = dgVerkiezingen.SelectedItem as DataRowView;

            EditVerkiezing editVerkiezing = new EditVerkiezing(selectedRow);
            editVerkiezing.ShowDialog();
            FillDataGridVerkiezingen();
        }

        private void BtnDeletePolitiekePartij_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = dgPolitiekePartijen.SelectedItem as DataRowView;
            DataTable standpunten = _verkiezingenDB.SelectPartijStandpunten(selectedRow["PartijId"].ToString());
            DataTable verkiezingsdeelname = _verkiezingenDB.SelectPartijVerkiezingsdeelname(selectedRow["PartijId"].ToString());


            if (standpunten.Rows.Count >= 1 && verkiezingsdeelname.Rows.Count >= 1)
            {
                _verkiezingenDB.DeletePartijStandpunten(selectedRow["PartijId"].ToString());
                _verkiezingenDB.DeletePartijVerkiezingsdeelname(selectedRow["PartijId"].ToString());
                _verkiezingenDB.DeletePolitiekePartij(selectedRow["PartijId"].ToString());
            }
            else if (standpunten.Rows.Count >= 1 && verkiezingsdeelname.Rows.Count == 0)
            {
                _verkiezingenDB.DeletePartijStandpunten(selectedRow["PartijId"].ToString());
                _verkiezingenDB.DeletePolitiekePartij(selectedRow["PartijId"].ToString());
            }
            else if (standpunten.Rows.Count == 0 && verkiezingsdeelname.Rows.Count >= 1)
            {
                _verkiezingenDB.DeletePartijVerkiezingsdeelname(selectedRow["PartijId"].ToString());
                _verkiezingenDB.DeletePolitiekePartij(selectedRow["PartijId"].ToString());
            }
            else
            {
                _verkiezingenDB.DeletePolitiekePartij(selectedRow["PartijId"].ToString());
            }

            FillDataGridPolitiekePartij();
        }

        private void BtnDeleteStandpunt_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = dgStandpunten.SelectedItem as DataRowView;

            _verkiezingenDB.DeleteStandpunt(selectedRow["StandpuntId"].ToString());

            FillDataGridStandpunten();
        }

        private void BtnDeleteVerkiezing_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = dgVerkiezingen.SelectedItem as DataRowView;

            _verkiezingenDB.DeleteVerkiezing(selectedRow["VerkiezingId"].ToString());

            FillDataGridVerkiezingen();
        }
    }

    
}
