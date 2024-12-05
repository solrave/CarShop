namespace CarShop;
using static Console;
using System.Reflection;
public enum JobType
{
    WheelReplacement,
    EngineReplacement,
    OilReplacement,
    BumperReplacement,
    BrakesReplacement,
    WrongReplacement
}

public enum CarType
{
    Motorbike,
    Sedan,
    Truck
}

public enum CarPartType
{
    Wheel,
    Engine,
    Oil,
    Bumper,
    Brakes
}

public static class Helper
{
    private static readonly Random Randomizer = new();

    public static Car? SelectedCar { get; private set; }
    public static CarPart? SelectedCarPart { get; private set; }
    public static CarPart? SelectedStoragePart { get; private set; }
    public static event RepairWork InvokeRepair;
 
   // ////////////////////////NAME CREATORS AND BOOL/////////////////////////////////////////////// 
    public static string GetRandomCarName()
    {
        string carCaption = "";
        string[] carBrands = new[] { "BMW", "HONDA", "TOYOTA", "VOLKSWAGEN", "SUBARU" };
        for (int i = 0; i < carBrands.Length; i++)
        {
            carCaption = carBrands[Randomizer.Next(0, carBrands.Length - 1)];
        }

        return carCaption;
    }
    
    public static string GetRandomName(CarPartType partType)
    {
        string caption = "";
        string[] wheelCaptions = new[] { "Pirelli", "GoodYear", "Kumi" };
        string[] engineCaptions = new[] { "WR-19", "SLS-Turbo", "Work-8823" };
        string[] oilCaptions = new[] { "Shell", "Mogul", "Luk-oil" };
        string[] bumperCaptions = new[] { "BumperSoft", "BumperMedium", "BumperHard" };
        string[] brakesCaptions = new[] { "Brake1", "Brake2", "Brake3" };
        switch (partType)
        {
            case CarPartType.Wheel:
                for (int i = 0; i < wheelCaptions.Length; i++)
                {
                    caption = wheelCaptions[Randomizer.Next(0, wheelCaptions.Length - 1)];
                }

                break;

            case CarPartType.Engine:
                for (int i = 0; i < engineCaptions.Length; i++)
                {
                    caption = engineCaptions[Randomizer.Next(0, engineCaptions.Length - 1)];
                }

                break;

            case CarPartType.Oil:
                for (int i = 0; i < oilCaptions.Length; i++)
                {
                    caption = oilCaptions[Randomizer.Next(0, oilCaptions.Length - 1)];
                }

                break;

            case CarPartType.Bumper:
                for (int i = 0; i < bumperCaptions.Length; i++)
                {
                    caption = bumperCaptions[Randomizer.Next(0, bumperCaptions.Length - 1)];
                }

                break;
            case CarPartType.Brakes:
                for (int i = 0; i < brakesCaptions.Length; i++)
                {
                    caption = brakesCaptions[Randomizer.Next(0, brakesCaptions.Length - 1)];
                }

                break;
        }

        return caption;
    }

    public static bool GetRandomBool()
    {
        if (Randomizer.Next(1, 20) % 2 == 0) return true;
        return false;
    }
 
    // ////////////////////////////PART CREATORS/////////////////////////////////////////////////////
    
    public static List<IMenuItem>? SetCarParts(CarType carType)
    {
        List<IMenuItem>? carParts = new List<IMenuItem>();
        switch (carType)
        {
            case CarType.Motorbike:

                carParts.Add(new CarPart(CarPartType.Engine));
                carParts.Add(new CarPart(CarPartType.Oil));

                for (int i = 0; i < 2; i++)
                {
                    carParts.Add(new CarPart(CarPartType.Wheel));
                }

                for (int i = 0; i < 2; i++)
                {
                    carParts.Add(new CarPart(CarPartType.Brakes));

                }

                break;

            case CarType.Sedan:

                carParts.Add(new CarPart(CarPartType.Engine));
                carParts.Add(new CarPart(CarPartType.Oil));

                for (int i = 0; i < 4; i++)
                {
                    carParts.Add(new CarPart(CarPartType.Wheel));
                }

                for (int i = 0; i < 2; i++)
                {
                    carParts.Add(new CarPart(CarPartType.Brakes));
                }

                for (int i = 0; i < 2; i++)
                {
                    carParts.Add(new CarPart(CarPartType.Bumper));
                }

                break;

            case CarType.Truck:

                carParts.Add(new CarPart(CarPartType.Engine));
                carParts.Add(new CarPart(CarPartType.Oil));

                for (int i = 0; i < 8; i++)
                {
                    carParts.Add(new CarPart(CarPartType.Wheel));
                }

                for (int i = 0; i < 4; i++)
                {
                    carParts.Add(new CarPart(CarPartType.Brakes));
                }

                for (int i = 0; i < 2; i++)
                {
                    carParts.Add(new CarPart(CarPartType.Bumper));
                }

                break;
        }

        return carParts;
    }

    public static List<IMenuItem> CreateStorage()
    {
        List<IMenuItem> storage = new List<IMenuItem>();
        foreach (CarPartType type in Enum.GetValues(typeof(CarPartType)))
        {
            for (int i = 0; i < 5; i++)
            {
                storage.Add(new CarPart(type, false));
            }
        }

        return storage;
    }

    // //////////////////////////////////////////////////////////////////////////////////////////////
    public static string GetCondition(bool isBroken)
    {
        var output = "";
        if (isBroken)
        {
            output = "Detail Broken!";
        }
        else output = "Detail is OK.";

        return output;
    }

    public static void ClearConsole()
    {
        Clear();
        WriteLine("\x1b[3J");
    }

    public static void ExitProgram()
    {
        Environment.Exit(0);
    }

    public static void ShowStats()
    {

    }

    public static void SaveCar()
    {
        SelectedCar = MenuNavigator.CurrentMenu[MenuNavigator.CurrentItemIndex] as Car;
    }

    public static void SavePart()
    {
        SelectedCarPart = MenuNavigator.CurrentMenu[MenuNavigator.CurrentItemIndex] as CarPart;
    }

    public static void CallForMechanic()
    {
        SelectedStoragePart = MenuNavigator.CurrentMenu[MenuNavigator.CurrentItemIndex] as CarPart;
        InvokeRepair(SelectedCarPart, SelectedStoragePart, SelectedCar);
    }
}
