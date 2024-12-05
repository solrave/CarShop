
namespace CarShop;

public delegate void RepairWork(CarPart brokenPart, CarPart goodPart, Car carToRepair);//ДЕЛЕГАТ ДОСТУПНЫЙ НА ВСЕЙ ПРОГРАММЕ ВО ВСЕХ КЛАССАХ

class Program
{
    static void Main(string[] args)
    {
        Dictionary<Enum, int> partPrices = new Dictionary<Enum, int>()
        {
            {CarPartType.Wheel, 5},
            { CarPartType.Engine, 20},
            { CarPartType.Oil, 2},
            { CarPartType.Bumper, 7},
            { CarPartType.Brakes, 10}
        };

        Dictionary<JobType, int> jobPrices = new Dictionary<JobType, int>()
        {
            { JobType.WheelReplacement ,20},
            { JobType.EngineReplacement ,50},
            { JobType.OilReplacement ,10},
            { JobType.BumperReplacement ,15},
            { JobType.BrakesReplacement ,30},
            { JobType.WrongReplacement ,300}
        };
        
        var cashDesk = new CashDesk(partPrices, jobPrices);
        var display = new Display();
        var listener = new EventListener();
        Mechanic mechanic = new Mechanic(DataBase.Storage, cashDesk);
        var menu = new MenuNavigator();
        menu.SubscribeListener(listener);
        menu.AddDisplay(display);
        DataBase.AssignMainMenuContent();
        DataBase.AssignMenuActions();
        DataBase.AssignContent();
        while (true)
        {
            menu.RunMenu();
            listener.Listen();
            Helper.ClearConsole();
        }
    }
}