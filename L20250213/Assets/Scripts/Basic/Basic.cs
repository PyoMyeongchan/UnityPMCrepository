using UnityEngine;
using UnityEngine.UI;
public class Basic : MonoBehaviour
{
    // 유니티에서 만들 클래스
    // 1. MonoBehaviour가 연결되어있는 클래스 : 유니티 씬에 직접 연결할 수 있는 클래스
    // 2. 일반 클래스 : 유니티 내에서 특정 데이터를 설계할 때 사용합니다.
    // 3. ScriptableObject가 연결되어있는 클래스 : 유니티 Assets 폴더 내부에 스크립트를 에세으로 저장할 수 있는 클래스


    // 1. 접근제한자
    // 프로그램에서 접근에 관련된 설정을 진행할 수 잇는 키워드
    // public : 유니티 인스펙터에서 확인 가능
    // private : 유니티 인스펙터에서 확인 불가능

    //[SerializeField] 속성이 붙은 필드(변수)의 경우에는 인스펙터에서 공개됩니다.
    //[Serialiable] 속성이 붙은 클래스를 변수로 사용할 경우 인스펙터에서 공개됩니다.

    public int number;
    private int count;
    [SerializeField] private bool able;

    public Text text;
    public GameObject cube;
    public SampleCode s;



    // 씬을 시작할 때, 1번 실행되는 코드를 작성하는 위치
    // 주로 값에 대한 설정을 진행할 때 해당 위치에서 작업을 진행
    void Start()
    {
        cube = new GameObject();
        
        s = GameObject.Find("GameObject (1)").GetComponent<SampleCode>();

        // 함수사용법(함수 호출)
        // 함수명(인자값);

        // 매개변수(parameter) : 함수 설계 시 호출하는 쪽에서 받아줄 데이터에 대한 표현
        // 함수의 ()부분에 작성합니다.

        // 인자(Argment) : 함수를 호출할 때 넣어주는 값

        NumberFive();
        Debug.Log(number);
        SetNumber(10);
        Debug.Log(number);
        TextHello();
    }

    // 메소드 : 클래스 내부에서 만들어지는 함수
    // 함수 = 명령문 집합체(특정 하나의 기능을 수행하기 위한)

    // 함수 만드는 방법
    // 접근제한자 반환타입 함수명(매개변수)
    // {
    //      실행할 명령문;
    // }

    // 1. void 형태의 함수
    //  실행할 기능만 만들어줍니다.
    public void NumberFive()
    {
        number = 5;
    }

    public void SetNumber(int value)
    { 
    number = value;

    }

    public void TextHello()
    {
        text.text = "Hello";
    }

    // 함수 기능을 유추할 수 있도록 이름을 만들어야한다.


    // 2. void 이외의 함수
    //  실행이 끝나고 전달해줄 값을 고려해서 설계합니다.



}