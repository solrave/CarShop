namespace CarShop;

public class CarPartContent : IContent
{
    public List<IMenuItem> SubMenu { get; }

    public CarPartContent()
    {
        SubMenu = DataBase.Storage;
    }
}