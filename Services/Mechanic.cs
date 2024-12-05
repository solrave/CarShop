namespace CarShop;
using static Console;
using System.Threading;
public class Mechanic
{
    private CashDesk _cashDesk;
    
    private JobType _jobType;
    private List<IMenuItem> _storage;
    
    public Car CarToRepair {get;set;}
    public CarPart BrokenItem {get;set;}
    public CarPart GoodItem {get;set;}
    public JobType JobType => _jobType;
    
    public Mechanic(List<IMenuItem> storage, CashDesk cashDesk)
    {
        _cashDesk = cashDesk;
        _storage = storage;
        Helper.InvokeRepair += StartRepair;
    }
    
    public void StartRepair(CarPart brokenPart, CarPart goodPart, Car carToRepair)
    {
        BrokenItem = brokenPart;
        GoodItem = goodPart;
        CarToRepair = carToRepair;
        _jobType = GetJobType();
        CarToRepair.Content.SubMenu.Remove(BrokenItem);
        CarToRepair.Content.SubMenu.Add(GoodItem);
        _storage.Remove(GoodItem);
        _cashDesk.CalculateRepairCost(CarToRepair, GoodItem, JobType);
    }

    private JobType GetJobType()
    {
        JobType jobType = JobType.WrongReplacement;
        if (GoodItem.GetType() == BrokenItem.GetType() && BrokenItem.IsBroken)
        {
            var partType = GoodItem.GetCarPartType();
            switch (partType)
            {
                case CarPartType.Wheel:
                    jobType = JobType.WheelReplacement;
                    break;
                
                case CarPartType.Engine:
                    jobType = JobType.EngineReplacement;
                    break;
                
                case CarPartType.Oil:
                    jobType = JobType.OilReplacement;
                    break;
                
                case CarPartType.Bumper:
                    jobType = JobType.BumperReplacement;
                    break;
                
                case CarPartType.Brakes:
                    jobType = JobType.BrakesReplacement;
                    break;
            }
        }
        else if (GoodItem.GetType() != BrokenItem.GetType())
        {
            jobType = JobType.WrongReplacement;
        }
        return jobType;
    }
}