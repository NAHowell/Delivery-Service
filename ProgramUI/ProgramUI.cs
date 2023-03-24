using _Delivery;


public class ProgramUI
{
    private DelRepo _DelList = new DelRepo();

    public void Run()
    {
        SeedData();
        Menu();
    }

    private void Menu()
    {
        bool keeprunning = true;
        while (keeprunning)
        {
            Console.Clear();

            System.Console.WriteLine(
                "Selcet an option!\n" +
                "1. Create new delivery\n" +
                "2. View all the deliveries\n" +
                "3. Update delivery status\n" +
                "4. Remove a delivery\n" +
                "5. Exit"
            );

            string input = Console.ReadLine();

            switch(input)
            {
                case "1":
                    CreateNewDel();
                    break;
                case "2":
                    ViewAllContent();
                    break;
                case "3":
                    UpdateDelStatus();
                    break;
                case "4":
                    RemoveDel();
                    break;
                case "5":
                    System.Console.WriteLine("Good Bye");
                    keeprunning = false;
                    break;
                default:
                System.Console.WriteLine("Please enter a valid number");
                break;
            }
            System.Console.WriteLine("Please press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }
    }

    private void CreateNewDel()
    {
        Console.Clear();
        DeliveryContent newContent = new DeliveryContent();

        System.Console.WriteLine("Enter the order date(mm/dd/yyyy):");
        newContent.OrderDate = Console.ReadLine();

        System.Console.WriteLine("Enter the delivery date(mm/dd/yyyy)");
        newContent.DeliveryDate = Console.ReadLine();

        System.Console.WriteLine("Enter the status of the dilivery(Scheduled, EnRoute, Complete, or Canceled)");
        newContent.Status = Console.ReadLine();

        System.Console.WriteLine("Enter the item number:");
        string ItemAsString = Console.ReadLine();
        newContent.ItemNumber = double.Parse(ItemAsString);
        
        System.Console.WriteLine("Enter the quantity:");
        string QuaAsString = Console.ReadLine();
        newContent.Quantity = double.Parse(QuaAsString);
        
        System.Console.WriteLine("Enter the Id(example: 'B-1000'):");
        newContent.Id = Console.ReadLine();
        
        _DelList.AddContentToList(newContent);
    }
    private void ViewAllContent()
    {
        Console.Clear();
        List<DeliveryContent> ListOfContent = _DelList.GetContent();
        foreach (DeliveryContent content in ListOfContent)
        {
            System.Console.WriteLine($"Customer Id:{content.Id} Item Number:{content.ItemNumber} Quantity:{content.Quantity}\n" + 
                $"Status:{content.Status}\n" +
                $"Order Date:{content.OrderDate}\n" +
                $"Delivery Date:{content.DeliveryDate}");
        }
    }
    private void UpdateDelStatus()
    {
        Console.Clear();
        ViewAllContent();

        System.Console.WriteLine("Enter the Id of the order you want to update the status on:");

        string oldStatus = Console.ReadLine();
        

        DeliveryContent newStatus = new DeliveryContent();

        System.Console.WriteLine("Enter the order date(mm/dd/yyyy):");
        newContent.OrderDate = Console.ReadLine();

        System.Console.WriteLine("Enter the delivery date(mm/dd/yyyy)");
        newContent.DeliveryDate = Console.ReadLine();

        System.Console.WriteLine("Enter the status of the dilivery(Scheduled, EnRoute, Complete, or Canceled)");
        newContent.Status = Console.ReadLine();

        System.Console.WriteLine("Enter the item number:");
        string ItemAsString = Console.ReadLine();
        newContent.ItemNumber = double.Parse(ItemAsString);
        
        System.Console.WriteLine("Enter the quantity:");
        string QuaAsString = Console.ReadLine();
        newContent.Quantity = double.Parse(QuaAsString);
        
        System.Console.WriteLine("Enter the Id(example: 'B-1000'):");
        newContent.Id = Console.ReadLine();

        bool wasUpdated = _DelList.UpdateContent(oldStatus, newStatus);

        if (wasUpdated)
        {
            System.Console.WriteLine("Content seccessfully updated!");
        }
        else 
        {
            System.Console.WriteLine("Could not update the content....");
        }

    }
    private void RemoveDel()
    {
        Console.Clear();
        ViewAllContent();

        System.Console.WriteLine("Enter the Id of the delivery you want to remove(Example: B-1000):");
        string remove = Console.ReadLine();
        

        bool wasDeleted = _DelList.RemoveContent(remove);

        if (wasDeleted)
        {
            System.Console.WriteLine("The order was removed.");
        }
        else 
        {
            System.Console.WriteLine("The order was not removed.");
        }
    }

    private void SeedData()
    {
        DeliveryContent Order1057 = new DeliveryContent("(12/13/2023)", "(12/15/2023)", "Scheduled", 16, 2, "B-1057");
        DeliveryContent Order1023 = new DeliveryContent("(03/09/2023)", "(03/13/2023)", "Scheduled", 4, 1, "B-1023");
        DeliveryContent Order1009 = new DeliveryContent("(01/20/2023)", "(01/23/2023)", "Complete", 7, 5, "B-1009");

        _DelList.AddContentToList(Order1057);
        _DelList.AddContentToList(Order1023);
        _DelList.AddContentToList(Order1009);

    }
}