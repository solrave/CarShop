namespace CarShop;

public class EventListener
{
    public delegate void KeyAction();
    public event KeyAction? OnUpArrowKeyPressed;
    public event KeyAction? OnDownArrowKeyPressed;
    public event KeyAction? OnEnterKeyPressed;
    public event KeyAction? OnBackspaceKeyPressed;
       
    public void Listen()
    {
        var userInput = Console.ReadKey();
        switch (userInput.Key)
        {
            case ConsoleKey.UpArrow:
                //Console.WriteLine("UP");
                OnUpArrowKeyPressed?.Invoke();
                break;
                    
            case ConsoleKey.DownArrow:
                //Console.WriteLine("DOWN");
                OnDownArrowKeyPressed?.Invoke();
                break;
                    
            case ConsoleKey.Enter:
                //Console.WriteLine("ENTER");
                OnEnterKeyPressed?.Invoke();
                break;
                    
            case ConsoleKey.Backspace:
                //Console.WriteLine("QUIT");
                OnBackspaceKeyPressed?.Invoke();
                break;
            default:
                Thread.Sleep(1000);
                break;
        }
            
    }
}