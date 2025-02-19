using System;
using UnityEditor;
using UnityEngine;


//������Ʈ���� ������ �Ŵ���(����)

public class Manager : MonoBehaviour
{
    //�̱��� ����

    public static Manager Instance;


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
}
