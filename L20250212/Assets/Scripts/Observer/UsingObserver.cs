using UnityEngine;

public class UsingObserver : MonoBehaviour
{
    //옵저버 사용을 위한 델리게이트 변수 선언
    delegate void NotifyHandler();
    NotifyHandler _notifyHandler;

    private void Start()
    {
        Observer1 observe1 = new Observer1();
        Observer2 observe2 = new Observer2();

        _notifyHandler += new NotifyHandler(observe1.OnNotify);
        _notifyHandler += observe2.OnNotify;

        _notifyHandler();
    }

}
