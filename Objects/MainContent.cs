namespace CarShop;

public class MainContent : IContent
{
    public List<IMenuItem> SubMenu { get; }

    public MainContent()
    {
        SubMenu = DataBase.CarList;
    }
    
}