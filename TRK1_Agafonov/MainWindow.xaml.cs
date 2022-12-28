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
using TRK1_Agafonov.Database.Entity;
using TRK1_Agafonov.DataBase;
using TRK1_Agafonov.VisualEntities;

namespace TRK1_Agafonov
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static int selectied = 0;
        private static int selectiedName = 0;
        List<Service> services = EfModel.Init().Services.ToList();

        List<Selection> selections = new List<Selection>()
        { 
            new Selection()
            {
                Name = "По убыванию",
                Number = 2
            },
             new Selection()
            {
                Name = "По возрастанию",
                Number = 1
            },
             new Selection()
            {
                Name = "Дефолт",
                Number = 0
            }
        };


        public MainWindow()
        {
            
            InitializeComponent();
            cbSort.ItemsSource = selections;
            cbSortName.ItemsSource = selections;
            SeletItems();

            
            
        }
        private void SeletItems()
        {
            if (selectied == 0 && selectiedName == 0)
                lvSuplies.ItemsSource = EfModel.Init().Services.Where(s => s.Title.Contains(tbSearch.Text) || s.Description.Contains(tbSearch.Text)).ToList();
            else if (selectied == 1 && selectiedName == 0)
                lvSuplies.ItemsSource = EfModel.Init().Services.OrderBy(s => s.Cost).Where(s => s.Title.Contains(tbSearch.Text) || s.Description.Contains(tbSearch.Text)).ToList();
            else if (selectied == 2 && selectiedName == 0)
                lvSuplies.ItemsSource = EfModel.Init().Services.OrderByDescending(s => s.Cost).Where(s => s.Title.Contains(tbSearch.Text) || s.Description.Contains(tbSearch.Text)).ToList();
            else if (selectied == 0 && selectiedName == 1)
                lvSuplies.ItemsSource = EfModel.Init().Services.OrderByDescending(s => s.Title).Where(s => s.Title.Contains(tbSearch.Text) || s.Description.Contains(tbSearch.Text)).ToList();
            else if (selectied == 0 && selectiedName == 2)
                lvSuplies.ItemsSource = EfModel.Init().Services.OrderByDescending(s => s.Title).Where(s=> s.Title.Contains(tbSearch.Text) || s.Description.Contains(tbSearch.Text)).ToList();
            else if(selectied == 1 && selectiedName == 1)
                lvSuplies.ItemsSource = EfModel.Init().Services.Where(s => s.Title.Contains(tbSearch.Text) || s.Description.Contains(tbSearch.Text)).ToList();
            else if (selectied == 2 && selectiedName == 2)
                lvSuplies.ItemsSource = EfModel.Init().Services.Where(s => s.Title.Contains(tbSearch.Text) || s.Description.Contains(tbSearch.Text)).ToList();
            else if (selectied == 1 && selectiedName == 2)
                lvSuplies.ItemsSource = EfModel.Init().Services.Where(s => s.Title.Contains(tbSearch.Text) || s.Description.Contains(tbSearch.Text)).ToList();
            else if (selectied == 2 && selectiedName == 1)
                lvSuplies.ItemsSource = EfModel.Init().Services.Where(s => s.Title.Contains(tbSearch.Text) || s.Description.Contains(tbSearch.Text)).ToList();
            
        }

        private void btnDeleteClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Deleted!");
        }

        private void btnChangeClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Changed");
        }

        private void SelectedCbChange(object sender, SelectionChangedEventArgs e)
        {
            Selection sel = new Selection();
            sel = cbSort.SelectedItem as Selection;
            selectied = sel.Number;
            SeletItems();
        }

        private void NameCbChange(object sender, SelectionChangedEventArgs e)
        {
            Selection sel = new Selection();
            sel = cbSortName.SelectedItem as Selection;
            selectiedName = sel.Number;
            SeletItems();
        }

      

        private void textChange(object sender, TextChangedEventArgs e)
        {
            SeletItems();
        }
    }
}
