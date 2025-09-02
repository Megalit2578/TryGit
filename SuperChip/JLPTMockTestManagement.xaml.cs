using BAL.Service;
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

namespace SuperChip
{
    /// <summary>
    /// Interaction logic for JLPTMockTestManagement.xaml
    /// </summary>
    public partial class JLPTMockTestManagement : Window
    {
        private string userEmail;


        private readonly CandidateService candidateService;
        private readonly MockTestService mocktestService;
        private readonly SystemUserService systemUserService;
        private readonly bool isManager;
        private const int MANAGER_ROLE_ID = 1; // Assuming 1 is manager role ID

        public JLPTMockTestManagement(string userEmail)
        {
            InitializeComponent();
            candidateService = new CandidateService();
            mocktestService = new MockTestService();
            systemUserService = new SystemUserService();
            isManager = systemUserService.GetRoleId(userEmail) == MANAGER_ROLE_ID;

            // Enable/disable CRUD buttons based on role
            //btnAdd.IsEnabled = isManager;
            //btnUpdate.IsEnabled = isManager;
            //btnDelete.IsEnabled = isManager;
            //btnSearchByPlantName.IsEnabled = isManager;
            //btnSearchBySupplier.IsEnabled = isManager;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCandidate();
            loadMockTest();
        }
        private void LoadCandidate()
        {
            dgvDisplay.ItemsSource = candidateService.GetAllCandidates();
        }
        private void loadMockTest()
        {
            dgvDisplay.ItemsSource = mocktestService.GetAllTest();
            //cmbPlantName.ItemsSource = mocktestService.GetAllTest();
            //cmbPlantName.DisplayMemberPath = "Name";
            //cmbPlantName.SelectedValuePath = "Id";
        }

        //private void dgvDisplay_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        //{
        //    var selectedInventory = dgvDisplay.SelectedItem as Inventory;
        //    if (selectedInventory == null)
        //    {
        //        // Clear all UI fields
        //        txtInventoryId.Text = string.Empty;
        //        txtQuantity.Text = string.Empty;
        //        txtPrice.Text = string.Empty;
        //        dpArrivalDate.SelectedDate = null;
        //        txtShelfLife.Text = string.Empty;
        //        txtSupplier.Text = string.Empty;
        //        cmbPlantName.SelectedIndex = -1;
        //        return;
        //    }

        //    // Update text fields
        //    txtInventoryId.Text = selectedInventory.InventoryId.ToString();
        //    txtQuantity.Text = selectedInventory.Quantity.ToString();
        //    txtPrice.Text = selectedInventory.Price.ToString("F2");
        //    dpArrivalDate.SelectedDate = selectedInventory.ArrivalDate.ToDateTime(new TimeOnly(0, 0));
        //    txtShelfLife.Text = selectedInventory.ShelfLife.ToString();
        //    txtSupplier.Text = selectedInventory.Supplier;

        //    // Update the ComboBox selection
        //    var plants = plantService.GetAllPlants();
        //    cmbPlantName.ItemsSource = plants;
        //    cmbPlantName.DisplayMemberPath = "Name";
        //    cmbPlantName.SelectedValuePath = "PlantId";

        //    if (selectedInventory.Plant != null)
        //    {
        //        cmbPlantName.SelectedItem = selectedInventory.Plant;
        //    }
        //    else
        //    {
        //        cmbPlantName.SelectedIndex = -1;
        //    }
        //}

        //private void btnSearchBySupplier_Click(object sender, RoutedEventArgs e)
        //{
        //    if (!isManager)
        //    {
        //        MessageBox.Show("Only managers can search inventory items.", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        return;
        //    }

        //    var supplier = txtSearchBySupplier.Text.Trim();
        //    if (string.IsNullOrEmpty(supplier))
        //    {
        //        LoadInventory();
        //        return;
        //    }
        //    else
        //    {
        //        dgvDisplay.ItemsSource = inventoryService.GetAllInventoriesBySupplier(supplier);
        //    }
        //}

        //private void btnSearchByPlantName_Click(object sender, RoutedEventArgs e)
        //{
        //    if (!isManager)
        //    {
        //        MessageBox.Show("Only managers can search inventory items.", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        return;
        //    }

        //    var plantName = txtSearchByPlantName.Text.Trim();
        //    if (string.IsNullOrEmpty(plantName))
        //    {
        //        LoadInventory();
        //        return;
        //    }
        //    else
        //    {
        //        dgvDisplay.ItemsSource = inventoryService.GetAllInventoriesByPlantName(plantName);
        //    }
        //}


        //private void btnDelete_Click(object sender, RoutedEventArgs e)
        //{
        //    if (!isManager)
        //    {
        //        MessageBox.Show("Only managers can delete inventory items.", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        return;
        //    }

        //    var selectedInventory = dgvDisplay.SelectedItem as Inventory;
        //    if (selectedInventory != null)
        //    {
        //        if (MessageBox.Show("Do you want to delete this inventory?", "Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
        //        {
        //            inventoryService.DeleteInventory(selectedInventory.InventoryId);
        //            LoadInventory();
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please select an inventory to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}
        //public Inventory getInputInventory()
        //{
        //    try
        //    {
        //        var inventoryId = txtInventoryId.Text.Trim();
        //        if (string.IsNullOrEmpty(inventoryId) || !int.TryParse(inventoryId, out int id) || id <= 0)
        //        {
        //            MessageBox.Show("Inventory ID must be a positive integer.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //            return null;
        //        }

        //        var quantity = txtQuantity.Text.Trim();
        //        if (int.TryParse(quantity, out int qty) && qty <= 0)
        //        {
        //            MessageBox.Show("Quantity must be a positive number.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //            return null;
        //        }
        //        var price = txtPrice.Text.Trim();
        //        var ArrivalDate = dpArrivalDate.SelectedDate;
        //        var shelfLife = txtShelfLife.Text.Trim();
        //        var supplier = txtSupplier.Text.Trim();
        //        if (supplier.Length < 20 || supplier.Length > 100)
        //        {
        //            MessageBox.Show("Supplier name must be between 20 and 100 characters.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //            return null;
        //        }
        //        if (!char.IsUpper(supplier[0]) && !char.IsNumber(supplier[0]))
        //        {
        //            MessageBox.Show("Supplier name must start with an uppercase letter or a digit.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //            return null;
        //        }
        //        if (supplier.Any(ch => !char.IsLetterOrDigit(ch) && !char.IsWhiteSpace(ch)))
        //        {
        //            MessageBox.Show("Supplier name can only contain letters, digits, and spaces.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //            return null;
        //        }
        //        var plantId = cmbPlantName.SelectedItem as Plant;
        //        Inventory a = new Inventory()
        //        {
        //            InventoryId = int.TryParse(inventoryId, out int invId) ? invId : 0,
        //            Quantity = int.TryParse(quantity, out int q) ? qty : 0,
        //            Price = decimal.TryParse(price, out decimal prc) ? prc : 0,
        //            ArrivalDate = DateOnly.FromDateTime(ArrivalDate ?? DateTime.Now),
        //            ShelfLife = int.TryParse(shelfLife, out int life) ? life : 0,
        //            Supplier = supplier,
        //            PlantId = plantId?.PlantId ?? 0
        //        };
        //        return a;

        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        //private void btnAdd_Click(object sender, RoutedEventArgs e)
        //{
        //    if (!isManager)
        //    {
        //        MessageBox.Show("Only managers can add inventory items.", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        return;
        //    }

        //    Inventory a = getInputInventory();
        //    if (a != null)
        //    {
        //        if (inventoryService.IsExistedId(a.InventoryId))
        //        {
        //            MessageBox.Show("Inventory ID already exists.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //            return;
        //        }
        //        inventoryService.AddInventory(a);
        //        LoadInventory();
        //    }
        //    return;
        //}

        //private void btnUpdate_Click(object sender, RoutedEventArgs e)
        //{
        //    if (!isManager)
        //    {
        //        MessageBox.Show("Only managers can update inventory items.", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        return;
        //    }

        //    Inventory a = getInputInventory();
        //    if (a != null)
        //    {
        //        var selectedInventory = dgvDisplay.SelectedItem as Inventory;
        //        selectedInventory.Quantity = a.Quantity;
        //        selectedInventory.Price = a.Price;
        //        selectedInventory.ArrivalDate = a.ArrivalDate;
        //        selectedInventory.ShelfLife = a.ShelfLife;
        //        selectedInventory.Supplier = a.Supplier;
        //        selectedInventory.PlantId = a.PlantId;
        //        if (selectedInventory != null)
        //        {
        //            inventoryService.UpdateInventory(selectedInventory);
        //            LoadInventory();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Please select an inventory to update.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //        }
        //    }
        //    return;
        //}

    }
}
