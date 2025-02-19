using System;
using UnityEditor;
using UnityEngine;


//프로젝트에서 개발할 매니저(종합)

public class Manager : MonoBehaviour
{
    //싱글톤 개발

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

    //Resources 폴더가 반드시 필요한 코드
    public GameObject CreateFromPath(string path)
    { 
        return Instantiate(Resources.Load<GameObject>(path));
    
    }



}
