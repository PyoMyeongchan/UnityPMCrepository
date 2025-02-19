using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Ǯ(������)
// ������Ʈ�� Ǯ�� �����ΰ�, �ʿ��� ������ Ǯ �ȿ� �ִ� ��ü�� ������ ����ϴ� ���
// �Ź� �ǽð����� �ı��ϰ�, �����ϴ� �ͺ��� CPU�� �δ��� ���� �� �ֽ��ϴ�.
// ��� �̸� �Ҵ��صδ� ����̱� ������ �޸𸮸� ����ؼ� ������ ���̴� ����Դϴ�.

// Ǯ�� ���� �۾� �� �ʿ��� �������� �����ϰ� �ִ� �������̽�
public interface IPool
{ 
    // Property
    Transform parent { get; set;  }

    Queue<GameObject> pool { get; set; } // FIFO(First In First Out)

    // Function
    //default parameter : ���� ���� ���� �ʾ��� ��� ������ ������ �ڵ� ó���˴ϴ�.
    // ex) var go = GetGameObject();
    // ex) vat go = GetGameObject(action);

    // ���͸� �������� ���
    GameObject GetGameObject(Action<GameObject> action = null);

    // ���͸� �ݳ��ϴ� ���
    void ObjectReturn(GameObject ob, Action<GameObject> action = null);
}


public class ObjectPool : IPool
{
    public Transform parent { get; set; }
    public Queue<GameObject> pool { get; set; } = new Queue<GameObject>();

    public GameObject GetGameObject(Action<GameObject> action = null)
    {
        var obj = pool.Dequeue(); // Ǯ�� �ִ� �� �ϳ� �����ڽ��ϴ�.

        obj.SetActive(true); // ������Ʈ Ȱ��ȭ ����

        // �׼����� ���޹��� ���� �ִٸ�?
        if (action != null)
        {
            // ���޹��� �׼��� �����մϴ�.
            // ?�� null�� ���� ����
            action?.Invoke(obj);

        }
        return obj;
    }

    public void ObjectReturn(GameObject ob, Action<GameObject> action = null)
    {
        pool.Enqueue(ob);
        ob.transform.parent = parent;
        ob.SetActive(false);

        // �׼����� ���޹��� ���� �ִٸ�?
        if (action != null)
        {
            // ���޹��� �׼��� �����մϴ�.
            // ?�� null�� ���� ����
            action?.Invoke(ob);

        }
    }
}

    public class PoolManager : MonoBehaviour
    {



    }
