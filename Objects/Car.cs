using System.Data.SqlTypes;

namespace CarShop;

public class Car : IMenuItem
{
    private const int CAR_MONEY = 500;
    public string Info { get; private set; }
    public Action ItemAction { get; set; }
   
    public Enum TypeOfItem { get; private set; }
    public int CarMoney { get; set; }
    public string Name { get; set; }
    public IContent Content { get; set; }
    
    public Car(CarType typeOfCar)
    {
        TypeOfItem = typeOfCar;
        CarMoney = CAR_MONEY;
        Name = Helper.GetRandomCarName();
        Content = new CarContent(typeOfCar);
    }

    public void SetInfo()
    {
        Info = $"CarBrand: {Name}\tCarType: {TypeOfItem.ToString()}\tCarMoney: {CarMoney}";
    }

    public string GetInfo() { return Info; }

    public void SetAction(Action action)
    {
        ItemAction = action;
    }
    
    public override string ToString()
    {
        var output = new string($"CarBrand: {Name}\tCarType: {TypeOfItem.ToString()}\tCarMoney: {CarMoney}");
        return output;
    }


}