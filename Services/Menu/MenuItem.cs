namespace CarShop;

public class MenuItem : IMenuItem
{ 
    public Enum TypeOfItem { get; }
    public Action ItemAction { get; set; }
    
    public string Info { get; set; }
  
    public IContent Content { get; set; }
   
    public MenuItem(string info)
    {
        Info = info;
    }

    public override string ToString()
    {
        return Info;
    }

}