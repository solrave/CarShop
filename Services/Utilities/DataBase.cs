namespace CarShop;

public static class DataBase
{
   public static readonly List<IMenuItem>  MainMenu = new () // Start Menu
    {
        new MenuItem("Start the Work"),
        new MenuItem("Show Stats"),
        new MenuItem("Exit")
    };
   
  public static List<IMenuItem> CarList = new() // Car Objects
    {
        new Car(CarType.Motorbike),
        new Car(CarType.Sedan),
        new Car(CarType.Truck)
    };
  
   public static List<IMenuItem> Storage = Helper.CreateStorage();// Storage

   public static void AssignMainMenuContent()
   {
       MainMenu[0].Content = new MainContent();
       
   }

   public static void AssignContent()
   {
       foreach (var car in CarList)
       {
           foreach (var part in car.Content.SubMenu)
           {
               part.Content = new CarPartContent();
           }
       }

       foreach (var part in Storage)
       {
           part.Content = new StorageContent();
       }
   }

   public static void AssignMenuActions()
   {
       MainMenu[1].ItemAction = Helper.ShowStats;
       MainMenu[2].ItemAction = Helper.ExitProgram;

       foreach (var car in CarList)
       {
           car.ItemAction = Helper.SaveCar;
       }

       foreach (var car in CarList)
       {
           foreach (var part in car.Content.SubMenu)
           {
               part.ItemAction = Helper.SavePart;
           }
       }

       foreach (var part in Storage)
       {
           part.ItemAction = Helper.CallForMechanic;
       }
   }

}