namespace CarShop;
using static Console;
public class CashDesk
{
    private int _carShopMoney;
    private const int STARTING_MONEY = 2000;
    private int _priceForWork;
    
    private Dictionary<Enum, int> _partPrices;
    private Dictionary<JobType, int> _jobPrices;

    public int CarShopMoney
    {
        
        get { return _carShopMoney;}
        private set { _carShopMoney = value; }
    }
    public int PriceForWork { get; private set; }
    public Dictionary<Enum, int> PartPrices => _partPrices;
    public Dictionary<JobType, int> JobPrices => _jobPrices;

    public CashDesk(Dictionary<Enum, int> partPrices, Dictionary<JobType, int> jobPrices)
    {
        _carShopMoney = STARTING_MONEY;
        _partPrices = partPrices;
        _jobPrices = jobPrices;
    }

    public void CalculateRepairCost(Car car, CarPart carPart, JobType jobType)
    {
        var partPrice = GetPartPrice(carPart.TypeOfItem);
        var jobPrice = GetJobPrice(jobType);
        PriceForWork = partPrice + jobPrice;
        if (jobType != JobType.WrongReplacement)
        {
            car.CarMoney -= PriceForWork;
            CarShopMoney += PriceForWork;
            Helper.ClearConsole();
            Write($"A job was performed:{jobType}!\tYou earned:{GetWorkPrice()}");
            Thread.Sleep(2000);
        }
        else
        {
            Helper.ClearConsole();
            CarShopMoney -= PriceForWork;
            Write($"You have replaced a WRONG part!\tYou got penalty:{GetWorkPrice()}");
            Thread.Sleep(2000);
        }
    }

    public int GetWorkPrice()
    {
        return PriceForWork;
    }

    private int GetPartPrice(Enum partType)
    { 
        _partPrices.TryGetValue(partType, out int value);
        return value;
    }

    private int GetJobPrice(JobType jobType)
    {
        _jobPrices.TryGetValue(jobType, out int value);
        return value;
    }
}