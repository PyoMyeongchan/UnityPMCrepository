using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public interface UseIt
{ 
    void Add(Button button);

    void Remove(Button button);

    void Notigfy();





}

public abstract class Button
{
    public abstract void OnNotify();
}

public class Button1 : Button
{
    public override void OnNotify()
    {


        Debug.Log("ť�갡 �����Ǿ����ϴ�.");
    
    }

}

public class Button2 : Button
{
    public override void OnNotify()
    {
        Debug.Log("ť�갡 �����Ǿ����ϴ�.");
    }

}
