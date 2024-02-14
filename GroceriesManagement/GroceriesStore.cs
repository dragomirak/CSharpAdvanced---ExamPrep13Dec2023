using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace GroceriesManagement;

public class GroceriesStore
{
    public int Capacity { get; set; }

    public GroceriesStore(int capacity)
    {
        Capacity = capacity;
        Turnover = 0;
        Stall = new List<Product>();
    }

    public double Turnover { get; set; }
    public List<Product> Stall { get; set; }
    public void AddProduct(Product product)
    {
        if (!Stall.Contains(product) && Stall.Count < Capacity)
        {
            Stall.Add(product);
        }
    }
    public bool RemoveProduct(string name)
    {
        Product productToRemove = Stall.FirstOrDefault(p => p.Name == name);
        if (productToRemove == null)
        {
            return false;
        }

        return Stall.Remove(productToRemove);
    }
    public string SellProduct(string name, double quantity)
    {
        Product productToSell = Stall.FirstOrDefault(p => p.Name == name);
        if (productToSell == null)
        {
            return "Product not found";
        }
        else
        {
            double totalPrice = Math.Round(productToSell.Price * quantity, 2);
            Turnover += totalPrice;
            return $"{productToSell.Name} - {totalPrice:f2}$";
        }

    }
    public string GetMostExpensive()
    {
        Product mostExpensive = Stall.OrderByDescending(p => p.Price).First();
        return mostExpensive.ToString();
    }
    public string CashReport()
    {
        return $"Total Turnover: {Turnover:F2}$";
    }
    public string PriceList()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Groceries Price List:");
        foreach (var product in Stall)
        {
            sb.AppendLine(product.ToString());
        }

        return sb.ToString().Trim();
    }
}
