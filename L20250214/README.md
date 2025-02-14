### 2025.02.14 수업

* **Scene 등록 방법**
  * file → build profiles → SceneList에 씬을 등록

* 씬 로드 설정
  * single : 다른 씬으로 이동할 경우 기존 씬이 파괴됩니다.
  * additive : 게임 내에 씬이 동시에 켜지게 됩니다. ( 기존 씬에 새 씬이 들어오는 형태)
  * additive 주의 사항
    * Audio Listner 중복 조심
    * 카메라 기준으로 작업하는 코드를 짯을 때 기존의 설정으로 인해 동작이 제대로 안될 가능성이 있습니다.
    * Additive로 씬을 불러올 경우 - 기존의 씬이 Active Scene으로 유지되어 있음.

* 액티브 씬은 간단하게 오브젝트에 대한 생성 진행할 때 귀속되는 씬을 의미합니다.
  *  이 경우는 SceneManager의 SetActiveScene을 통해 설정을 변경해서 사용할 수 있습니다.

```cs
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSample : MonoBehaviour
{
    //유니티 라이프 싸이클(life cycle)
    //유니테에서는 시작 단계부터 종료 단계까지를 함수로 제공합니다.
    //ex) Awake(시작 전) / Start(시작) / Update(진행중)...

    //활성화 되었을 경우

    private void OnEnable()
    {
        Debug.Log("OnSceneLoad가 등록되었습니다.");
        SceneManager.sceneLoaded += OnSceneLoad;
    }


    private void OnDisable()
    {
        Debug.Log("OnSceneLoad가 해제되었습니다.");
        SceneManager.sceneLoaded -= OnSceneLoad;
    }

    
    private void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"현재 로드된 씬의 이름음 {scene.name} 입니다.");
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            SceneManager.LoadScene("BRP Sample Scene");
            //따로 씬 모드를 설정하지 않으면 LoadSceneMode는 Single로 처리됩니다.
            //Single 모드의 설정은 씬을 갈아타도록 설정합니다.
        }
        if (Input.GetKeyDown(KeyCode.I))
        {

            SceneManager.LoadScene("BRP Sample Scene",LoadSceneMode.Additive);
            //LoadSceneMode.Additive의 경우 기존 씬 위에 새로운 씬을 중복해서 로드하는 설정
            //당연히 이 작업을 진행할 경우 기본 오브젝트들(Main Camera, Direction Light) 등도 다 로드되기 때문에 주의해야 합니다.
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            StartCoroutine("LoadSceneC");
            //SceneManager.LoadSceneAsync("BRP Sample Scene",LoadSceneMode.Additive);
            //비동기적(Async) 로드
            //일반적인 작업은 동기적으로 처리됩니다.
            //씬이 로딩이 다 될때까지 다른 요소들은 작동하지 않게됩니다.

        }

    }

    IEnumerator LoadSceneC()
    { 
        yield return SceneManager.LoadSceneAsync("BRP Sample Scene", LoadSceneMode.Additive);

    }
}
```
 
<hr/>

* 동기(synchornous)
  * Task(작업)을 순차적으로 실행하는 방식
  * 하나의 작업이 완료될 때까지 다음 작업은 대기 상태로 유지됩니다.

* 비동기(Asynchornous)
  * 여러 개의 작업(Task)를 동시에 처리하는 방식입니다.

```cs
using System.Threading.Tasks;
using UnityEngine;

//동기(synchornous)
//Task(작업)을 순차적으로 실행하는 방식
//하나의 작업이 완료될 때까지 다음 작업은 대기 상태로 유지됩니다.


//비동기(Asynchornous)
//여러 개의 작업(Task)를 동시에 처리하는 방식입니다.

public class AsyncSceneSample : MonoBehaviour
{
    
    void Start()
    {
        Debug.Log("작업시작");
        Sample1();
        Debug.Log("Process A");
    }

    // async 키워드는 비동기 메소드를 선언할 때 사용하는 키워드입니다.
    // 메소드의 실행 방식으로 비동기적으로 설정합니다.
    // 해당 키워드는 메소드, 람다식 등에 사용될 수 있습니다.
    // 해당 키워드가 붙은 메소드는 Task, Task<T> 또는 void를 return하게 됩니다.

    // Task는 비동기 작업을 나타내는 클래스입니다.
    // System.Threading.Tasks 영역에 존재합니다.

    // await는 비동기 메소드 내에서 사용되는 키워드입니다.
    // 해당 키워드는 Task나 Task<T>를 return하는 메소드나 표현식 앞에 사용할 수 있습니다.

    // 해당 비동기 작업이 완료될 때까지 현재의 메소드를 중지시킵니다.
    // 작업이 완료되면 다시 해당 메소드를 계속 진행시킵니다.

    private async void Sample1()
    {
        Debug.Log("Process B");
        await Task.Delay(10000);
        Debug.Log("Process C");
    }



}
```

* **Tip**
  * 컨트롤 a = 전체 선택
  * 컨트롤 k + f = 선택된 코드 들여쓰기 정렬
  * Initialize = 값설정
 
<hr/>

* 유니티의 디자인 패턴 코드 중 하나 : 싱글톤
  * 싱글톤 패턴의 장점은 별도로 가져올 필요없이 바로 그 기능을 사용할 수 있음.
  * 대신 싱글톤 패턴으로 설계한 인스턴스가 너무 많은 데이터를 공유하는 경우라면 수정이 어렵고 테스트도 까다로워집니다.

```cs
using UnityEngine;


public class Tester : MonoBehaviour
{
    int point = 0;
    private void Start()
    {
        point = SingleTon.Instance.point; // 싱글톤에 있는 프로퍼티

        SingleTon.GetInstance().PointPlus(); //또는 메소드를 통해 클래스 내부의 객체에 접근해서 객체가 가지고 있는 정보를 사용할 수 있습니다.
    
        // 싱글톤 패턴의 장점은 별도로 가져올 필요없이 바로 그 기능을 사용할 수 있음.
        // 대신 싱글톤 패턴으로 설계한 인스턴스가 너무 많은 데이터를 공유하는 경우라면 수정이 어렵고 테스트도 까다로워집니다.
    }

}


    //유니티의 디자인 패턴 코드 : Singleton

    //공통적으로 사용되는 데이터를 하나의 객체(인스턴스)로 돌려쓰겠습니다.

    public class SingleTon : MonoBehaviour
{
    // 1. 인스턴스이면서 전역으로 접근할 수 있게 설계합니다.
   private static SingleTon _instance;


    // 2.  클래스 내부에 표현할 값을 설계합니다.
    public int point = 0;

    public void PointPlus()
    {  
        point++; 
    }

    public void ViewPoint()
    {
        Debug.Log("현재 포인트 :" + point);
    
    }


    //메소드를 통해서 전달
    public static SingleTon GetInstance()
    {
        //현재 값이 비어있다면,
        if (_instance == null)
        {   //새롭게 할당합니다.
            _instance = new SingleTon();

        }
        //일반적인 경우라면 현재의 인스턴스를 return합니다.
        return _instance;
    }

    //프로퍼티로 설계하는 것도 가능합니다.
    public static SingleTon Instance
    {
        get
        {
           if(_instance == null)
           {
                _instance = new SingleTon();


           }
            return _instance;
        }
    
    
    }

}
```
* T 싱글톤
  * <T> 부분에 타입을 넣어서 해당 형태로 만들어주는 싱글톤
```cs
using System.ComponentModel;
using UnityEngine;

// T Singleton
// <T> 부분에 타입을 넣어서 해당 형태로 만들어주는 싱글톤

// 1. <T>는 사용자가 타입을 적는 위치입니다.
// 2. where는 해당 작업에 대한 제약 조건을 의미합니다.
// T : MonoBehaviour라면 T는 MonoBehaviour이거나 또는 상속된 클래스여야 합니다.

public class TSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
   private static T instance;

    public static T Instance
    {
        get 
        {
            // 인스턴스가 비어있다면
            if (instance == null)
            {
                // 게임 씬 내에서 해당 타입을 가지고 있는 오브젝트를 찾아냅니다.
                // (T)를 적은 이유는 해당 데이터의 형태로 변형하기 위해서입니다.
                instance = (T)FindAnyObjectByType(typeof(T));

                // 씬에서 조사를 했는데도 비어있는 상황이라면?
                // ex) 만들려고 하는 데이터가 GameManager라면 이름도 GameManager로 지어질 것입니다.
                if (instance == null)
                {
                    var manager = new GameObject(typeof(T).Name);
                    //매니저에 해당 타입을 컴포넌트로써 연결해줍니다.
                    instance = manager.AddComponent<T>();
                
                }

            }
            return instance;
        
        
        }
    
    }

    // protected 상속 범위까지 적용
    protected void Awake()
    {
        if (instance == null)

        {
            //this는 클래스 자신을 의미
            //as T는 해당 값을 T로 취급하겠다는 코드입니다.
            instance = this as T;
            //파괴처리 되지 않도록 설정해줍니다.
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null)
        { 
            Destroy(gameObject);
        }

        
    }
}
```

```cs
using UnityEngine;

public class GameManager : TSingleton<GameManager>
{
    public int score;

    public void ScorePlus()
    { 
        score++; 
    }  
}
```

<hr/>
* C# 일반화 프로그래밍(Generic Programming)
 * 데이터 형식에 대한 일반화를 진행하는 기법입니다.
 * <T>를 이용해서 설계하는 방식을 의미합니다.

```cs
using UnityEngine;

//C# 일반화 프로그래밍(Generic Programming)
//데이터 형식에 대한 일반화를 진행하는 기법입니다.
//<T>를 이용해서 설계하는 방식을 의미합니다.

public class GenericSample : MonoBehaviour
{
    //배열을 전달받아서 배열의 요소를 순서대로 출력하는 코드
    public static void printIArray(int[] number)
    {
        for (int i = 0; i < number.Length; i++)
        { 
            Debug.Log(number[i]);
        
        }
    
    }

    public static void printFArray(float[] number)
    {
        for (int i = 0; i < number.Length; i++)
        {
            Debug.Log(number[i]);

        }

    }

    public static void printSArray(string[] words)
    {
        for (int i = 0; i < words.Length; i++)
        {
            Debug.Log(words[i]);

        }

    }

    public static void printGArray<T>(T[] values)
    {
        for (int i = 0; i < values.Length; i++)
        {
            Debug.Log(values[i]);

        }

    }


    void Start()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        float[] numbers2 = { 1.1f, 1.2f, 3.3f, 4.4f };
        string[] words = { "hello", "hi" };
        printGArray<int>(numbers);
        printGArray(numbers2);
        printGArray<string>(words);
    }

    
}
```
 

<hr/>

* **에셋 번들**
  * 에셋을 묶은 아카이브 파일을 의미합니다.
  * 에셋 : 유니티 내에서 쓸 수 있는 데이터 model, texture, audioclip ...

  * 에셋 번들을 사용하는 이유?
    * Application에 다운로드 진행을 편리하게 하기 위함
    * 에셋번들을 이용하면 런타임 환경에서 에셋을 불러서 사용할 수 있다.
    * ex) DLC 제공 / 컨텐츠 패치 / 모바일 게임 등에서 초기인스톨 사이즈 감소

  * 에셋 번들 등록 방법
    *  에셋을 클릭하면 아래쪽에 번들에 대한 정보가 나오게 되고 New 부분에 등록을 진행합니다.
  * 에셋 번들 빌드 방법
    * Assets 폴더에 Editor 폴더를 생성해 스크립트를 작성합니다.
   
```cs
using System.IO;
using System.Collections;
using UnityEngine;

public class LoadAssetsBundleManager : MonoBehaviour
{
    //경로 작성
    string path = "Assets/Bundles/asset1";


    void Start()
    {
        StartCoroutine(LoadAsync(path));
    }

    IEnumerator LoadAsync(string path)
    { 
        AssetBundleCreateRequest request = AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes(path));    
        
        //리퀘스트가 끝날때까지 대기
        yield return request;

        //리퀘스트를 통해 받아온 에셋 번들의 정보를 적용합니다.
        AssetBundle bundle = request.assetBundle;

        //전달받은 번들을 통해 에셋을 로드합니다.
        GameObject prefab = bundle.LoadAsset<GameObject>("RedSphere");
        Instantiate(prefab);
        //LoadAssets<T>("이름");



    }

}
```

* 구글드라이브에서 에셋을 가져오는 코드 

```cs
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GoogleDriveAssetBundle : MonoBehaviour
{
    //구글드라이브 다운로드 형태의 사진 URL넣기
    private string imageFileURL = "https://drive.usercontent.google.com/u/0/uc?id=11Tp6Vy-ajbF_H4-yHTqu9TEfTQ_05x23&export=download";
   
    public Image image;

    void Start()
    {
        StartCoroutine("DownLoadImage");        
    }

    IEnumerator DownLoadImage()
    {
        //해당 주소(URL)을 통해 텍스처를 리퀘스트 요청합니다.
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageFileURL);

        //리퀘스트가 완료될 때까지 대기합니다.
        yield return www.SendWebRequest();

        //리퀘스트의 결과가 성공이라면
        if (www.result == UnityWebRequest.Result.Success)
        {
            var texture = ((DownloadHandlerTexture)www.downloadHandler).texture;

            //Texture2D를 UI에서 쓰기 위해 Sprite 형태로 변경
            var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, 1.0f);
            Debug.Log("이미지를 성공적으로 가져왔습니다.");
            image.sprite = sprite;

        }
        else
        {
            Debug.LogError("이미지를 가져오지 못했습니다.");
        }
    }

    
    
}
```


<hr/>

* **어드레서블** - 하나의 보조도구
  * 패키지 →유니티 레지스트리 → addressable 다운 추가
  *  window → asset Management → group : 어드레서블에 대한 기본 설정을 진행할 수 있음
  * Remote : 서버
  * Local : 로컬
  * Default Local Group 클릭
  * Build & Load를 Remote로 변경

  * space is needed in cache 설정인 경우
    * 변경 사항이 있을 때 기존 버전을 유지하다가 공간이 부족한 경우에만 번들 삭제 후 새 번들을 다운로드

  * Cache Clear를 New Version Loaded로 설정
    * 변경 사항이 있을 경우 기존의 값을 삭제하고 새로운 값을 다운 받습니다.

  * Inspect Top Level Settings

  * 카탈로그의 build remote catalog 설정
    * 카탈로그 파일을 빌드하고 원격 서버에 업로드해서 실행중인 앱이 원격 서버에서 카탈로그를 불러올 수 있도록 하는 기능

```cs
using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AssetAddressableMnager : MonoBehaviour
{
    // AssetReference를 특정 타입을 지정하지 않고 어드레서블의 리소스를 참조하게 됩니다.
    // AssetReferenceGameObject는 어드레서블 리소스 중에서 GameObject에 해당하는 값을 참조합니다.
    // AssetReferenceT는 제네릭을 이용해 특정 형태의 어드레서블 리소스를 참조합니다.

    public AssetReferenceGameObject capsule;

    public GameObject go = new GameObject();

    private void Start()
    {


        StartCoroutine("Init");
    }

    private IEnumerator Init()
    { 
        var init = Addressables.InitializeAsync();
        yield return init;
    
    }

    public void OnCreateButtonEnter()
    {
        capsule.InstantiateAsync().Completed += (obj) => 
        {
            go = obj.Result;
        };
              
    
    }
    public void OnReleaseButtonENTER()
    {
        Addressables.ReleaseInstance(go); //해제

    }

}
```
    
