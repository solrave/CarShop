namespace CarShop;

public class StorageContent : IContent
{
    public List<IMenuItem> SubMenu { get; }

    public StorageContent()
    {
        SubMenu = DataBase.MainMenu;
    }
}