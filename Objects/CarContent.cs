namespace CarShop;

public class CarContent : IContent
{
    public List<IMenuItem> SubMenu { get; }

    public CarContent(CarType typeOfCar)
    {
        SubMenu = Helper.SetCarParts(typeOfCar);
    }
}