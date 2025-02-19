using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// 풀(웅덩이)
// 오브젝트를 풀에 만들어두고, 필요할 때마다 풀 안에 있는 객체를 꺼내서 사용하는 방식
// 매번 실시간으로 파괴하고, 생성하는 것보다 CPU의 부담을 줄일 수 있습니다.
// 대신 미리 할당해두는 방식이기 때문에 메모리를 희생해서 성능을 높이는 방식입니다.

// 풀에 대한 작업 시 필요한 정보들을 보관하고 있는 인터페이스
public interface IPool
{ 
    // Property
    Transform parent { get; set;  }

    Queue<GameObject> pool { get; set; } // FIFO(First In First Out)

    // Function
    //default parameter : 값을 따로 넣지 않았을 경우 지정한 값으로 자동 처리됩니다.
    // ex) var go = GetGameObject();
    // ex) vat go = GetGameObject(action);

    // 몬스터를 가져오는 기능
    GameObject GetGameObject(Action<GameObject> action = null);

    // 몬스터를 반납하는 기능
    void ObjectReturn(GameObject ob, Action<GameObject> action = null);
}


public class ObjectPool : IPool
{
    public Transform parent { get; set; }
    public Queue<GameObject> pool { get; set; } = new Queue<GameObject>();

    public GameObject GetGameObject(Action<GameObject> action = null)
    {
        var obj = pool.Dequeue(); // 풀에 있는 값 하나 빼오겠습니다.

        obj.SetActive(true); // 오브젝트 활성화 진행

        // 액션으로 전달받은 값이 있다면?
        if (action != null)
        {
            // 전달받은 액션을 실행합니다.
            // ?는 null에 대한 설정
            action?.Invoke(obj);

        }
        return obj;
    }

    public void ObjectReturn(GameObject ob, Action<GameObject> action = null)
    {
        pool.Enqueue(ob);
        ob.transform.parent = parent;
        ob.SetActive(false);

        // 액션으로 전달받은 값이 있다면?
        if (action != null)
        {
            // 전달받은 액션을 실행합니다.
            // ?는 null에 대한 설정
            action?.Invoke(ob);

        }
    }
}

    public class PoolManager : MonoBehaviour
    {



    }
