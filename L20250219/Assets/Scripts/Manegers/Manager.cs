using System;
using UnityEditor;
using UnityEngine;


//프로젝트에서 개발할 매니저(종합)

public class Manager : MonoBehaviour
{
    //싱글톤 개발

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
