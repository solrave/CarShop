namespace CarShop;
using static Console;
using System.Threading;
public class MenuNavigator
{
    private Display _display;
    public Stack<List<IMenuItem>> MenuHistory { get; private set; }
    public static int CurrentItemIndex { get; protected internal set; }

    public static List<IMenuItem>? CurrentMenu { get; protected internal set; }
    
    public MenuNavigator()
    {
        MenuHistory = new Stack<List<IMenuItem>>();
        CurrentItemIndex = 0;
        CurrentMenu = DataBase.MainMenu;
    }
    
    public void AddDisplay(Display display)
    {
        _display = display;
    }
    public void SubscribeListener(EventListener eventListener)
    {
        eventListener.OnUpArrowKeyPressed += NavigateUp;
        eventListener.OnDownArrowKeyPressed += NavigateDown;
        eventListener.OnEnterKeyPressed += TriggerThisMenuItem;
        eventListener.OnBackspaceKeyPressed += GoPreviousMenu;
    }

    public void RunMenu()
    {
        MenuHistory.Clear();
        _display.DisplayMenu(CurrentMenu, CurrentItemIndex);
    }
    
    private void TriggerThisMenuItem()
    {
        if (CurrentMenu[CurrentItemIndex].ItemAction == null)
        {
            _display.DisplayNextMenu(this);
        }
        else
        {
            CurrentMenu[CurrentItemIndex].ItemAction.Invoke();
            _display.DisplayNextMenu(this);
        }
    }
    
    private void GoPreviousMenu()
    {
        CurrentMenu = MenuHistory.Pop();
        CurrentItemIndex = 0;
    }

    private void NavigateDown()
    {
        CurrentItemIndex = CurrentItemIndex == CurrentMenu.Count - 1
            ? CurrentItemIndex
            : ++CurrentItemIndex;
    }

    private void NavigateUp()
    {
        CurrentItemIndex = CurrentItemIndex == 0
            ? CurrentItemIndex
            : --CurrentItemIndex;
    }
    
}