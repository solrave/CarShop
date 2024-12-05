namespace CarShop;

public class CarPart : IMenuItem
{
    public string Info { get; private set; }
    public Action ItemAction { get; set; }
    public string Name { get; }
    public Enum TypeOfItem { get; }
    public bool IsBroken { get; }
    
    public IContent Content { get; set; }
    
    public CarPart(CarPartType typeOfItem)
    {
        Name = Helper.GetRandomName(typeOfItem);
        TypeOfItem = typeOfItem;
        IsBroken = Helper.GetRandomBool();
    }

    public CarPart(CarPartType typeOfItem, bool isBroken)
    {
        Name = Helper.GetRandomName(typeOfItem);
        TypeOfItem = typeOfItem;
        IsBroken = isBroken;
    }

    public Enum GetCarPartType()
    {
        return TypeOfItem;
    }
    
    public void SetInfo()
    {
        Info = $"PartName: {Name}\tCarType: {TypeOfItem.ToString()}\tIsBroken: {IsBroken}";
    }

    public string GetInfo() { return Info; }

    public void SetAction(Action action)
    {
        ItemAction = action;
    }
    
    public override string ToString()
    {
        var output = new string($"PartName: {Name}\tPartType: {TypeOfItem}\t Status: {Helper.GetCondition(IsBroken)}");
        return output;
    }

}