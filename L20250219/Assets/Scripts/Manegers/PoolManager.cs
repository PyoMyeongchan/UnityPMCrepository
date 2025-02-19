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
public class PoolManager
{
    public Dictionary<string, IPool> poolDict = new Dictionary<string, IPool>();
        //key : string
        //Value : IPool

    public IPool PoolObject(string path)
    {
        // �ش� Ű�� ���ٸ� �߰��� �����մϴ�.
        if (poolDict.ContainsKey(path) == false)
        {
            Add(path);
        }

        // ť�� ���� ��� ť �߰�
        if (poolDict[path].pool.Count <= 0)
        { 
        
            AddQ(path);
        
        }

        return poolDict[path];
        //��ųʸ���[Ű] = ��;

    }

    public GameObject Add(string path)
    { 
            var obj = new GameObject(path + "Pool");
            // ���޹��� �̸����� Ǯ ������Ʈ ����
            
            ObjectPool objectPool = new ObjectPool();
            // ������Ʈ Ǯ ����

            poolDict.Add(path, objectPool);
            // ��ο� ������Ʈ Ǯ�� ��ųʸ��� ����
             
            objectPool.parent = obj.transform;
            // Ʈ������ ����

            return obj;
    
    }

    public void AddQ(string path)
    { 
            var go = Manager.Instance.CreateFromPath(path);
            go.transform.parent = poolDict[path].parent;
            poolDict[path].ObjectReturn(go);
    
    }   


}
