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
using static crud_robrigado.MainWindow;

namespace crud_robrigado
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Items> Item{ get; }
        public class Items
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }

        }
        public MainWindow()
        {
            InitializeComponent();

            Item = new List<Items>
{
        new Items { Id = 1, Name = "Laptop", Description = "A high-performance laptop", Price = 40000 },
        new Items { Id = 2, Name = "Smartphone", Description = "A sleek smartphone with wide storage", Price = 7000 },
        new Items{ Id = 3, Name = "Desktop", Description = "An advanced desktop with high-power GPU",  Price = 50000 }
};
            this.DataContext = this;
        }
        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (NameAdd.Text != " " && DescAdd.Text != " " && PriceAdd.Text != " " && IdAdd.Text != " ")
                {
                    Item.Add(new Items
                    {
                        Id = int.Parse(IdAdd.Text),
                        Name = NameAdd.Text,
                        Description = DescAdd.Text,
                        Price = decimal.Parse(PriceAdd.Text)
                    });
                    itemz.Items.Refresh();

                    IdAdd.Text = " ";
                    NameAdd.Text = " ";
                    DescAdd.Text = " ";
                    PriceAdd.Text = " ";
                }
            }

            catch
            {
                MessageBox.Show("Fill all the necessary fields correctly!");
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            Items selectedItem = itemz.SelectedItem as Items;
            if (selectedItem != null)
            {
                Item.Remove(selectedItem);
                itemz.Items.Refresh();
                MessageBox.Show("An item was removed successfully.");
            }
            else
            {
                MessageBox.Show("Please select an item to remove.");
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            IdAdd.Text = " ";
            NameAdd.Text = " ";
            DescAdd.Text = " ";
            PriceAdd.Text = " ";
        }
        
        private void AddCart_Click(object sender, RoutedEventArgs e)
        {

            Items selectItem = dataGrid.SelectedItem as Items;
            if (selectItem != null)
            {
                selectItem.Id = int.Parse(IdAdd.Text);
                selectItem.Name = NameAdd.Text;
                selectItem.Description = DescAdd.Text;
                selectItem.Price = decimal.Parse(PriceAdd.Text);


                dataGrid.Items.Refresh();
                MessageBox.Show("Item added successfully!");
            }
            else
            {
                MessageBox.Show("Please click a field.");
            }
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
    }
