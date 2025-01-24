// Author: AJ Allred
// Date: 1/24/2025
// Description: Create a simple food bank system that tracks the current inventory. Funcionality includes adding items, deleting items and printing items.

using System;
using Mission3Food;

internal class Program
{
    // List to hold Food Items
    public static List<FoodItem> foodItems = new List<FoodItem>();
    private static void Main()
    {
        // Create instance of FoodItem class
        //FoodItem fd = new FoodItem();

        string input = "";
        int option = 0;

        // Item parameters 
        string itemName = "";
        string itemCategory = "";
        int itemQuantity = 0;
        string expDate = "";

        // Welcome the user
        Console.WriteLine("Welcome to the Local Food Bank Inventory System!\n");

        // Loop to stay in until 4 is selected to exit
        while (option != 4)
        {
            displayOptions();

            // Checks the input to be an integer and between 1-4. Otherwise it asks the user to input again.
            if (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 4)
            {
                Console.WriteLine("Invalid option. Please try again.");
                continue;
            }
            // Add a new Food Item
            if (option == 1)
            {
                Console.WriteLine("Adding new Food Item\n");

                // Get Food Item Name
                Console.WriteLine("Enter the Food Item name: ");
                itemName = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(itemName))
                {
                    Console.WriteLine("Invalid input. Enter Food Item name: ");
                    itemName = Console.ReadLine();
                }

                // Get Food Item Category
                Console.WriteLine("Enter the Food Item category: ");
                itemCategory = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(itemCategory))
                {
                    Console.WriteLine("Invalid input. Enter Food Item category: ");
                    itemCategory = Console.ReadLine();
                }

                // Get Food Item Quantity
                Console.WriteLine("Enter the quantity: ");
                int quantity = 0;

                // Try to convert the input to an integer and check that it is above 0
                while (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 1)
                {
                    Console.WriteLine("Invalid quantity. Enter quantity again: ");
                }
                itemQuantity = quantity;

                // Get Food Item Expiration Date
                Console.WriteLine("Enter the Food Item Expiration Date (ex. '2025-06-15') : ");
                expDate = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(expDate))
                {
                    Console.WriteLine("Invalid input. Enter Food Item category: ");
                    expDate = Console.ReadLine();
                }

                FoodItem newFoodItem = new FoodItem(itemName, itemCategory, itemQuantity, expDate);
                foodItems.Add(newFoodItem);

                Console.WriteLine("\nFood Item has been logged as the following:");
                newFoodItem.DisplayInfo();
                Console.WriteLine("\n");
            }

            // Delete a food item
            else if (option == 2)
            {
                Console.WriteLine("Deleting Food Item\n");
                printItems();
                int itemNum;

                if (foodItems.Count < 1)
                {
                    Console.WriteLine("Please return to the menu and add a food item first.\n");
                }
                else
                {
                    Console.WriteLine($"Enter the index of the item you want to delete (0-{foodItems.Count - 1}): ");

                    // Checks the input to be an integer and between in the range 
                    if (!int.TryParse(Console.ReadLine(), out itemNum) || itemNum < 0 || itemNum >= foodItems.Count)
                    {
                        //
                        Console.WriteLine("Invalid input. Please select the delete option to try again. \n");
                        continue;
                    }

                    deletItem(itemNum);
                }

            }
            else if (option == 3)
            {
                Console.WriteLine("Printing List of Current Food Items\n");
                printItems();
            }
        }

        // Option is 4 so user exits the program
        Console.WriteLine("\nThank you for using the Food Bank Inventory System! Have a great day!");

    }

    // Method to display the menu options
    public static void displayOptions()
    {
        Console.WriteLine("Please select an option (1-4): \n" + "1: Add Food Items\n" + "2: Delete Food Items\n"
            + "3: Print List of Current Food Items\n" + "4: Exit the program\n");
    }

    // Method to delete food item
    public static void deletItem(int numItem)
    {
        Console.WriteLine($"Deleting the following item:");
        foodItems[numItem].DisplayInfo(); // Display the item being deleted
        Console.WriteLine();
        foodItems.RemoveAt(numItem);
    }

    // Method to print all items in the dictionary
    public static void printItems()
    {
        if (foodItems.Count == 0)
        {
            Console.WriteLine("The food items list is empty.\n");
            return;
        }

        Console.WriteLine("Current Food Items:\n");
        for (int i = 0; i < foodItems.Count; i++)
        {
            Console.WriteLine($"Index: {i}");
            foodItems[i].DisplayInfo(); // Call the DisplayInfo method for each FoodItem
            Console.WriteLine(); // Add a blank line for better readability
        }
    }

}