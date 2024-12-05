namespace CarShop;

public interface IContent
{
    List<IMenuItem> SubMenu { get; }
    
    void SaveCar(){}
    void SaveBrokenPart(){}
    void SaveGoodPart(){}
    void GetSubMenu(){}
   
}