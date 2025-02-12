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


        Debug.Log("큐브가 삭제되었습니다.");
    
    }

}

public class Button2 : Button
{
    public override void OnNotify()
    {
        Debug.Log("큐브가 생성되었습니다.");
    }

}
