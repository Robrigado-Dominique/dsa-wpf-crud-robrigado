using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using static crud_robrigado.MainWindow;

namespace crud_robrigado
{
    public partial class MainWindow : Window
    {
        public List<Items> Item { get; }
        public ObservableCollection<basket> cartz { get; set; }
        public class basket
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
        }
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
            cartz = new ObservableCollection<basket>();
            Item = new List<Items>
            {
                new Items
                {
                    Id = 1,
                    Name = "Laptop",
                    Description = "A high-performance laptop",
                    Price = 40000
                },

                new Items
                {
                    Id = 2,
                    Name = "Smartphone",
                    Description = "A sleek smartphone with wide storage",
                    Price = 7000
                },

                new Items
                {
                    Id = 3,
                    Name = "Desktop",
                    Description = "An advanced desktop with high-power GPU",
                    Price = 50000
                }
            };

            this.DataContext = this;
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(NameAdd.Text) &&
                !string.IsNullOrEmpty(DescAdd.Text) &&
                !string.IsNullOrEmpty(PriceAdd.Text) &&
                !string.IsNullOrEmpty(IdAdd.Text))

                {
                    {
                        string deets =
                            $"Product ID: {IdAdd.Text}\n" +
                            $"Product Name: {NameAdd.Text}\n" +
                            $"Description: {DescAdd.Text}\n" +
                            $"Price: ₱{PriceAdd.Text}\n\n" +
                            "Do you want to add this product?";

                        MessageBoxResult result = MessageBox.Show(
                            deets,
                            "Confirm Add Product",
                            MessageBoxButton.YesNo,
                            MessageBoxImage.Question);

                        if (result == MessageBoxResult.Yes)
                        {
                            Item.Add(new Items
                            {
                                Id = int.Parse(IdAdd.Text),
                                Name = NameAdd.Text,
                                Description = DescAdd.Text,
                                Price = decimal.Parse(PriceAdd.Text)
                            });

                            itemz.Items.Refresh();

                            IdAdd.Clear();
                            NameAdd.Clear();
                            DescAdd.Clear();
                            PriceAdd.Clear();

                            MessageBox.Show("Item added successfully!");
                        }

                        else
                        {
                            MessageBox.Show("Please fill all the necessary fields!");
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please fill all the necessary fields correctly!");
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            RemoveClick(sender, e);
        }

        private void RemoveClick(object sender, RoutedEventArgs e)
        {
            if (itemz.SelectedItem != null)
            {
                Items selectedItem = itemz.SelectedItem as Items;

                if (selectedItem != null)
                {
                    string details =
                        $"Product ID: {selectedItem.Id}\n" +
                        $"Product Name: {selectedItem.Name}\n" +
                        $"Description: {selectedItem.Description}\n" +
                        $"Price: ₱{selectedItem.Price}\n\n" +
                        "Do you want to remove this product?";

                    MessageBoxResult result = MessageBox.Show(
                        details,
                        "Confirm Remove Product",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {
                        Item.Remove(selectedItem);
                        itemz.Items.Refresh();

                        MessageBox.Show("Item removed from Available Items.");
                    }

                    return;
                }
            }

            MessageBox.Show("Please select an item to remove.");
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            IdAdd.Clear();
            NameAdd.Clear();
            DescAdd.Clear();
            PriceAdd.Clear();
        }

        private void AddCart_Click(object sender, RoutedEventArgs e)
        {
            Items selectedItem = itemz.SelectedItem as Items;

            if (selectedItem != null)
            {
                string details =
                    $"Product ID: {selectedItem.Id}\n" +
                    $"Product Name: {selectedItem.Name}\n" +
                    $"Description: {selectedItem.Description}\n" +
                    $"Price: ₱{selectedItem.Price}\n\n" +
                    "Do you want to add this product to the cart?";

                MessageBoxResult result = MessageBox.Show(
                    details,
                    "Confirm Add To Cart",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    basket newItemForCart = new basket
                    {
                        Id = selectedItem.Id,
                        Name = selectedItem.Name,
                        Description = selectedItem.Description,
                        Price = selectedItem.Price
                    };

                    cartz.Add(newItemForCart);

                    MessageBox.Show("Item added to cart!");
                }
            }
            else
            {
                MessageBox.Show("Please select an item from the shop to add to your cart!");
            }
        }

        private void RemoveCart_Click(object sender, RoutedEventArgs e)
        {
            if (cartzz.SelectedItem is basket selectedCartItem)
            {
                string details =
                    $"Product ID: {selectedCartItem.Id}\n" +
                    $"Product Name: {selectedCartItem.Name}\n" +
                    $"Description: {selectedCartItem.Description}\n" +
                    $"Price: ₱{selectedCartItem.Price}\n\n" +
                    "Do you want to remove this product from the cart?";

                MessageBoxResult result = MessageBox.Show(
                    details,
                    "Confirm Remove From Cart",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    cartz.Remove(selectedCartItem);

                    MessageBox.Show("Item removed from cart!");
                }
            }
            else
            {
                MessageBox.Show("Please select an item from the cart.");
            }
        }
    }
}