using System.ComponentModel;
using UnityEngine;

// T Singleton
// <T> �κп� Ÿ���� �־ �ش� ���·� ������ִ� �̱���

// 1. <T>�� ����ڰ� Ÿ���� ���� ��ġ�Դϴ�.
// 2. where�� �ش� �۾��� ���� ���� ������ �ǹ��մϴ�.
// T : MonoBehaviour��� T�� MonoBehaviour�̰ų� �Ǵ� ��ӵ� Ŭ�������� �մϴ�.

public class TSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
   private static T instance;

    public static T Instance
    {
        get 
        {
            // �ν��Ͻ��� ����ִٸ�
            if (instance == null)
            {
                // ���� �� ������ �ش� Ÿ���� ������ �ִ� ������Ʈ�� ã�Ƴ��ϴ�.
                // (T)�� ���� ������ �ش� �������� ���·� �����ϱ� ���ؼ��Դϴ�.
                instance = (T)FindAnyObjectByType(typeof(T));

                // ������ ���縦 �ߴµ��� ����ִ� ��Ȳ�̶��?
                // ex) ������� �ϴ� �����Ͱ� GameManager��� �̸��� GameManager�� ������ ���Դϴ�.
                if (instance == null)
                {
                    var manager = new GameObject(typeof(T).Name);
                    //�Ŵ����� �ش� Ÿ���� ������Ʈ�ν� �������ݴϴ�.
                    instance = manager.AddComponent<T>();
                
                }

            }
            return instance;
        
        
        }
    
    }

    // protected ��� �������� ����
    protected void Awake()
    {
        if (instance == null)

        {
            //this�� Ŭ���� �ڽ��� �ǹ�
            //as T�� �ش� ���� T�� ����ϰڴٴ� �ڵ��Դϴ�.
            instance = this as T;
            //�ı�ó�� ���� �ʵ��� �������ݴϴ�.
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null)
        { 
            Destroy(gameObject);
        }

        
    }
}
