// Author: AJ Allred
// Date: 1/24/2025

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission3Food
{
    public class FoodItem
    {
        public string ItemName { get; set; }
        public string ItemCategory { get; set; }
        public int Quantity { get; set; }
        public string ExpDate { get; set; }

        //  Constructor to create food item
        public FoodItem(string itemName, string itemCategory, int quantity, string expDate)
        {
            ItemName = itemName;
            ItemCategory = itemCategory;
            Quantity = quantity;
            ExpDate = expDate;
        }

        // Method to display details about the food item
        public void DisplayInfo()
        {
            Console.WriteLine($"Item: {ItemName}, Category: {ItemCategory}, Quantity: {Quantity}, Expiration Date: {ExpDate}");
        }
    }
}

