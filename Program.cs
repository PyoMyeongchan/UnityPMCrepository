namespace L20250123
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int 정수 10, 20, -1
            //float 실수 0.1, 0.0032
            //char 유니코드 한글자 'A' ==65

            //성적처리

            int korean = 10; //camelcsae == 변수 만들때 띄워쓰기 인식 못함, 대문자로 띄워쓰기 구분 룰이니 기억해라.koreanScore
            int mathmatics = 100;
            int english = 50;

            //여기서 korean = 50; 을 넣는다면 위와 상관없이 korean은 50이다.

            int sum = korean + mathmatics + english;
            float average = (float)sum / 3.0f;

            //여기서 average = 0; 을 넣는다면 위와 상관없이 average는 0이다.

            Console.WriteLine(average);
            //내가 무엇을 의도했는지 적어줘야한다. 생략 금지!
            // 연산자 == +, -, *, /, %
            //대입문 =
        }
    }
}

#region 필기
//00P 
//static void Main(string[] args) - 시작점이며 암기 필수!
//누가 어떻게 뭐한다 / console(기본입출력장치).writeline(입력하다).("")
//디버그 : 내가 만들걸 고친다, 확인한다. 단축키 : F5
// F9 - 표시 = 내가 실행하기전에 확인할거니 이전까지만 실행해줘.
//언어를 배우기위해 스스로 많이 해봐야한다.
//일단 따라쳐봐라! 그리고 고치면서 공부해라.
//.exe = 프로그램 실행

//byte x = 10;
//메모리 공간에 내가 쓸 x의 공간을 알려달라는 뜻이다.
// = 는 넣어달라는 뜻이다.(대입)
//문자 역시도 숫자코드표를 넣은 것이다.

//char 65 = 'A'; (아스키코드)
//Console.WriteLine(x); == A
//short x = 256; 2에 16승까지
//int x = 256;
//float x = 256.0;6자리까지
//double x = 256.00 6자리 이상
//[][][][] 변수 
//입력 - 처리 - 출력(반복)
//어떻게 숫자로 만들어낼지 생각하기
//하지말라는 경고문 작성도 역시 개발자의 일
//자료를 구조로 만드는 것

#endregion

