namespace CarShop;

public interface IMenuItem
{
    public string Info { get; }
    public Enum TypeOfItem { get; }
    public Action ItemAction { get; set; }
    public IContent Content { get; set; }
    
    public void SetInfo() { }

    public string GetInfo() { return Info; }
    
    public void SetAction(Action action) { }
} 