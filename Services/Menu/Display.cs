namespace CarShop;
using static Console;

public class Display
{
    protected internal void DisplayMenu(List<IMenuItem> _currentMenu, int CurrentItemIndex)
    {
        Helper.ClearConsole();
        for (int i = 0; i < _currentMenu.Count; i++)
        {
            WriteLine(i == CurrentItemIndex
                ? $">{_currentMenu[i]}<"
                : _currentMenu[i]);
        }

        WriteLine("=====CONTROLS========");
        WriteLine("UP - Up Arrow key\tDOWN - Down Arrow key\tENTER - Enter key\tPREVIOUS MENU - Backspace key");
    }
    
    protected internal void DisplayNextMenu(MenuNavigator navigator)
    {
        navigator.MenuHistory.Push(MenuNavigator.CurrentMenu);
        Helper.ClearConsole();
        MenuNavigator.CurrentItemIndex = 0; 
        MenuNavigator.CurrentMenu = MenuNavigator.CurrentMenu[MenuNavigator.CurrentItemIndex].Content.SubMenu;
    }
}