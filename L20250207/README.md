#### 오디오

* 오디오 소스
  * 재생을 하는 위해서는 오디오 리스너(Audio Listener)나 오디서 믹서(Audio Mixer)를 통해서 재생이 가능합니다.
  * 믹서의 경우는 따로 만들어야하며, 리스너의 경우 메인카메라에 붙어있습니다.

<hr/>

* **컴포넌트의 프로퍼티**
 
|기능|내용|
|:---:|:--------------------|
|Audio Resource|재생을 진행할 사운드 클립에 대한 등록|
|Output|기본적으로 오디오 리스너에 직접 출력됩니다.(None) <br> 만든 오디오 믹서가 있다면 그 믹서를 통해 출력합니다.|
|Mute|체크 시 음소거 처리|
|Bypass Effects|오디오 소스에 적용되어있는 필터 효과를 분리|
|Bypass Listener Effects|리스너 효과를 키거나 끄는 기능|
|Bypass Reverb Zones|리버브 존을 키거나 끄는 효과|

<hr/>

* **리버브 존** : 오디오 리스너의 위치에 따라 잔향 효과를 설정하는 도구

|기능|내용|
|:---:|:----------------------------------------------|
|Play On Awake|해당 옵션을 체크했을 경우 씬이 실행되는 시점에 사운드 재생이 처리가 됩니다. <br> 해당 기능 비활성화 시 스크립트를 통해 Play() 명령을 진행해 사운드를 재생합니다.|
|Loop|옵션 활성화 시 재생이 끝날 때 오디오 클립을 루프합니다.|
|Priority|오디오 소스의 우선 순위 <br> 0 = 최우선 <br> 128 = 기본 <br> 256 = 최하위|
|Volume|리스너 기준으로 거리 기준 소리에 대한 수치 <br> 컴퓨터 내의 소리를 재생하는 여러 가지 요소 중 하나를 제어|
|Pitch|재생 속도가 빨라지거나 느려질 때의 피치 변화량 <br> 1은 일반 속도 <br> 최대 수치 = 3|
|Stero Pan|소리 재생 시 좌우 스피커 간의 소리 분포를 조절 기능 <br> -1 = 왼쪽 스피커 <br> 0 = 양쪽 균등 <br> 1 = 오른쪽 스피커|
|Spatial Blend|0 = 사운드가 거리와 상관없이 일정하게 들어갑니다. <br> 1 = 사운드가 사운드 트는 도구의 거리에 따라 변화|	     
|Reverb Zone Mix|리버브 존에 대한 출력 신호 양을 조절합니다. <br> 0 = 영향을 받지 않겠습니다. <br> 1 = 오디오 소스와 리버브 존 사이의 신호를 최대치 <br> 1.1 = 10db 증폭|

* 리버브 존을 따로 설계해야하는 상황
  * ex) 동굴에서 소리가 울리는 효과 연출 / 건물 등에서 다른 부분을 반해서 울리는 소리에 대한 설정  

<hr/>

* **3D Sound Settings**

|기능|내용|
|:---:|:----------------------------------------------|
|Doppler Level|거리에 따른 사운드 높낮이 표현 <br> 0 = 효과가 없음|
|Spread|사운드가 퍼지는 각도 (0~360) <br> 0 = 한 점에서 사운드가 나오는 방식 <br> 360 = 모든 방향으로 균일하게 퍼져서 사운드가 나오는 방식|
|Volume Rolloff|그래프 설정 <br> 1. 로그 그래프 : 가까우면 사운드가 크고, 멀수록 점점 빠르게 사운드가 작아짐 <br> 2. 선형 그래프 : 거리에 따라 일정하게 사운드가 변화하는 구조 <br> 3. 커스텀 그래프 : 직접 조절하는 영역|

<hr/>

 * 예제 실습 및 스크립트
   * 오디오 재생 및 재생버튼 만들기
```cs
using Mono.Cecil;
using System.Collections;
using UnityEditor.Overlays;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AudioSourceSample : MonoBehaviour
{
    //0) 인스펙터에서 직접 연결하는 경우
    public AudioSource audioSourceBGM;

   
    //1) AudioSourceSample 객체가 자체적으로 오디오 소스를 가지고 있는 경우
    //private AudioSource own_audioSource;

    //3) 씬에서 찾아서 연결하는 경우
    //4) Resource.Load() 기능을 이용해 리소스 폴더에 있는 오디오 소스의 클립을 받아오겠습니다.
    public AudioSource audioSourceSFX;

    public AudioClip bgm; // 오디오 클립에 대한 연결

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //1)의 경우 GetComponent<T>를 통해 해당 객체가 가지고 있는 오디오 소스 연결 가능
        // own_audioSource = GetComponent<AudioSource>();

        //3)의 경우 GameObject.Find() 활용
        //GameObject.Find()는 씬에서 찾은  gameObject를 return하는 기능을 가지고 있음. 즉 이 값은 gameObject임.
        //GameObject이기 때문에 GetComponent<T>를 이어 작성함으로써 오브젝트가 가진 컴포넌트의 값을 return합니다.
        //따라서 저 결과물은 AudioSource가 됩니다.
        audioSourceSFX = GameObject.Find("SFX").GetComponent<AudioSource>();
        
        audioSourceBGM.clip = bgm;
        //오디오 소스의 클립을 bgm으로 설정합니다.
        
        audioSourceSFX.clip = Resources.Load("Explosion") as AudioClip;
        //Resource.Load()는 리소스 폴더에서 오브젝트를 찾아 로드하는 기능입니다.
        //이때 받아오는 값은 Object이므로, as 클래스명을 통해 해당 데이터가 어떤 형태인지 표현해주면
        //그 형태로 받아오게 됩니다.

        audioSourceSFX.clip = Resources.Load("Audio/BombCharge") as AudioClip;
        //리소스 로드 시 경로가 정해져있다면 폴더명/파일명으로 작성합니다.
        //리소스 로드 시 작성하는 이름에는 확정자명(EX) .json, .avi)를 작성하지 않습니다.

        //UnityWebRequest의 GetAudioClip 기능 활용
        StartCoroutine("GetAudioClip");

        audioSourceBGM.Play();
        //오디오 소스 스크립트 기능
        //audioSourceBGM.Play(); 클립을 실행하는 도구
        //audioSourceBGM.Pause(); 일시 정지 기능
        //audioSourceBGM.PlayOneShot(bgm); 클립 하나를 한순간 플레이를 진행합니다.
        //audioSourceBGM.Stop(); 오디오 클립 재생 중지
        //audioSourceBGM.UnPause(); 일시 정지 해제
        //audioSourceBGM.PlayDelayed(1.0f); 1초 뒤에 재생

        

    }

    IEnumerator GetAudioClip()
    {
        UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip("file:///"+Application.dataPath + "/Audio/" + "Explosion" + ".wav", AudioType.WAV);

        yield return uwr.SendWebRequest(); // 전달

        var new_clip = DownloadHandlerAudioClip.GetContent(uwr);
        //받은 경로를 기반으로 다운로드 진행

        audioSourceBGM.clip = new_clip; //클립 등록
        audioSourceBGM.Play(); //플레이
    }
    //이걸로 호출할 경우 작업 끝나면 값 사라짐.

    public void mute()
    {
            audioSourceBGM.Stop();


    }

    // Update is called once per frame
    void Update()
    {
       
    }
}

   ```
* 소리를 보여주는 도구 만들기
  * 보드 만들기
```cs
using UnityEngine;

public class Board : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

```
  * 오디오보드 보여주는 도구 만들기
```cs
using UnityEngine;
using UnityEngine.Audio;

//보드를 이용해서 오디오를 화면에서 표현하는 도구
//AudioUI 오브젝트에 연결

public class AudioBoardVisualizer : MonoBehaviour
{
    //보드 증가량
    public float minBoard = 50.0f;
    public float maxBoard = 500.0f;


    //사용할 오디오 클립
    public AudioClip audioClip;
    
    //사용할 오디오 소스
    public AudioSource audioSource;

    //오디어 믹서 연결
    public AudioMixer audioMixer;

    public Board[] boards;


    //스펙트럼용 samples
    public int samples = 64;//고정 수치


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boards = GetComponentsInChildren<Board>();
        //GetComponentsInChildren<T>는 오브젝트에 연결된 자식 컴포넌트들을 가져오는 코드

    //== 게임 오브젝트를 만들어서 컴포넌트를 등록해주는 코드 ==
        //오디오 소스가 null이라면
        if (audioSource == null)
        {
            //"AudioSource" 게임 오브젝트를 생성하고, 해당 오브젝트에 AudioSource 컴포넌트를 추가하겠습니다.
            audioSource = new GameObject("AudioSource").AddComponent<AudioSource>();
            
        }
        else
        { 
            //존재하면 씬에서 찾아서 등록하겠습니다.
            audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
            
        }
        
        audioSource.clip = audioClip;
        audioSource.outputAudioMixerGroup = audioMixer.FindMatchingGroups("Master")[0];
        //오디오믹서 그룹 중에서 "Master" 그룹을 찾아 적용합니다.
        audioSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        float[] data = audioSource.GetSpectrumData(samples, 0, FFTWindow.Rectangular);
        //GetSpectrumData(samples, channel, FFTWindow);

        //samples = FFT(신호에 대한 주파수 영역)를 저장할 배열, 이 배열 값은 2의 제곱수로 표현합니다.
        //채널은 최대 8개의 채널을 지원해주고 있음. 일반적으로 0을 사용합니다.
        //FFWindow는 샘플링 진행할 때 쓰는 값


        //보드 각각의 개수만큼 작업을 진행합니다.
        for (int i = 0; i < data.Length; i++)
        {
            var size = boards[i].GetComponent<RectTransform>().rect.size;
            //보드 각각이 가지고 있는 사이즈를 얻어오겠습니다.

            size.y = minBoard + (data[i] * (maxBoard - minBoard) * 3.0f);

            boards[i].GetComponent<RectTransform>().sizeDelta = size; 
            //sizeDelta는 부모를 기준으로 크기가 얼마나 큰지 작은지를 나타낸 수치를 의미합니다.
        }
    }
}
```

* 사운드 컨트롤러 만들기
  
```cs
using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


//에디터에서 GUI를 보여주는 시스템
//IMGUI : 디버그에서 사용

//UGUI : 일반적으로 사용하는 UI 도구

//UIElements : 에디터 기반으로 진행하는 도구

//슬라이더(Slider)는 UI

//자동완성으로 만들어지는 슬라이더 조인트 2D(SliderJoint 2D)의 경우는
//RigidBody 물리 제어를 받은 게임 오브젝트가 공간에서 선을 따라 미끄러지게 하는 설정을 할 때 사용
//ex) 미닫이문

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider MasterVolumeSlider;
    [SerializeField] private Slider BGMVolumeSlider;
    [SerializeField] private Slider SFXVolumeSlider;

    

    private void Awake()
    {
        MasterVolumeSlider.onValueChanged.AddListener(SetMaster);
        BGMVolumeSlider.onValueChanged.AddListener(SetBGM);
        SFXVolumeSlider.onValueChanged.AddListener(SetSFX);
      
    }

    private void SetMaster(float volume)
    {
        //오디오믹서가 가지고 있는 파라미터(Expose)의 수치를 설정하는 기능
        audioMixer.SetFloat("Master",Mathf.Log10(volume) * 20);

       

        //자주 사용되는 Mathf 함수
        //1.Mathf.Deg2Rad
        //degree(60분법)을 통해 radian(호도법)을 계산하는 코드
        //--> 각도 계산 코드
        //PI / 180, PI * 2 /360

        //2. Mathf.Rad2Deg
        //라디안 값을 디그리 값으로 바꿔줍니다.
        //360 / (pi * 2)
        //1라디안은 약 57도

        //3. Mathf.ABS()
        //절대값을 계산해주는 기능

        //4. Mathf.Atan
        //아크 탄젠트 값을 계산합니다.

        //5. Mathf.Ceil
        //소수점 올림 계산

        //6. Mathf.Clamp(value,min,max)
        //value를 min과 max 사이의 값으로 고정하는 기능

        //7. Mathf.Log10
        //베이스가 10으로 지정되어있는 수의 로그를 반환해주는 기능
        //ex) Debug.Log(Mathf.Log10(100))

        //이번 예제에서는 오디오 믹서의 최소 ~ 최대 볼륨 값 때문에 로그 함수가 사용되었습니다.
        //최소가 -80, 최대가 0
        //그래서 수치 변경시 Mathf.Log10((슬라이더 수치) * 20);을 통해 범위를 설정하고
        //슬라이더 최소 값이 0.0001일 경우 -80이 1일 경우 0이 계산됩니다.

    }

    private void SetBGM(float volume)
    {
        audioMixer.SetFloat("BGM", Mathf.Log10(volume) * 20);
    }
    private void SetSFX(float volume)
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }
}

```


