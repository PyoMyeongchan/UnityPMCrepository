using UnityEngine;

public class UsingObserver : MonoBehaviour
{
    //������ ����� ���� ��������Ʈ ���� ����
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
