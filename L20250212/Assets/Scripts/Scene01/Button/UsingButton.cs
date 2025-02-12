using UnityEngine;

public class UsingButton : MonoBehaviour
{
    delegate void NotifyHandler();
    NotifyHandler _notifyHandler;


    private void Start()
    {
        Button1 button1 = new Button1();
        Button2 button2 = new Button2();

        _notifyHandler += new NotifyHandler(button1.OnNotify);
        _notifyHandler += new NotifyHandler(button2.OnNotify);

        _notifyHandler();
    }

    
}
