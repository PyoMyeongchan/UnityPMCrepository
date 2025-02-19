using System;
using UnityEditor;
using UnityEngine;


//������Ʈ���� ������ �Ŵ���(����)

public class Manager : MonoBehaviour
{
    //�̱��� ����

    public static Manager Instance;

    private static PoolManager PoolManager = new PoolManager();
    public static PoolManager Pool 
    {
        get
        {
            return PoolManager;
        }
        
    }


    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);

        }
        else 
        { 
            Destroy(gameObject);
        }
    }

    //Resources ������ �ݵ�� �ʿ��� �ڵ�
    public GameObject CreateFromPath(string path)
    { 
        return Instantiate(Resources.Load<GameObject>(path));
    
    }



}
