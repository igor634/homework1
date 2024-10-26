using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Text.Json;

public partial class Form1 : Form
{
    private List<Car> carCollection = new List<Car>();
    private const string FilePath = "cars.json";

    public Form1()
    {
        InitializeComponent();
        LoadCarsFromFile();
        DisplayCars();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
           
            string brand = txtAuto.Text;
            string model = txtMark.Text;
            decimal price = decimal.Parse(txtPrice.Text);
            int mileage = int.Parse(txtSpeed.Text);

            
            var car = new Car(brand, model, price, mileage);
            carCollection.Add(car);
            DisplayCars();

            
            txtAuto.Clear();
            txtMark.Clear();
            txtPrice.Clear();
            txtSpeed.Clear();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка ввода данных: " + ex.Message);
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (lstCars.SelectedIndex >= 0)
        {
            carCollection.RemoveAt(lstCars.SelectedIndex);
            DisplayCars();
        }
        else
        {
            MessageBox.Show("Выберите автомобиль для удаления.");
        }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        SaveCarsToFile();
        MessageBox.Show("Коллекция автомобилей сохранена.");
    }

    private void DisplayCars()
    {
        lstCars.Items.Clear();
        foreach (var car in carCollection)
        {
            lstCars.Items.Add(car.ToString());
        }
    }

    private void SaveCarsToFile()
    {
        try
        {
            var json = JsonSerializer.Serialize(carCollection);
            File.WriteAllText(FilePath, json);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка сохранения: " + ex.Message);
        }
    }

    private void LoadCarsFromFile()
    {
        try
        {
            if (File.Exists(FilePath))
            {
                var json = File.ReadAllText(FilePath);
                carCollection = JsonSerializer.Deserialize<List<Car>>(json) ?? new List<Car>();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка загрузки файла: " + ex.Message);
        }
    }

    
    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public int Mileage { get; set; }

        public Car(string brand, string model, decimal price, int mileage)
        {
            Brand = brand;
            Model = model;
            Price = price;
            Mileage = mileage;
        }

        public override string ToString()
        {
            return $"{Brand} {Model} - {Price} USD, {Mileage} km";
        }
    }
}