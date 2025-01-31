using UnityEngine;

public class CricleMove : MonoBehaviour
{
    //Circle을 지정된 위치로 Lerp 시키는 스크립트

    public GameObject Circle;
    Vector3 pos = new Vector3(5, -3, 0);


    void Update()
    {
        //Circle.transform.position = Vector3.Lerp(Circle.transform.position, pos,Time.deltaTime);
        //0 을 입력할 경우 움직이지 않습니다.
        //1 이 최대치입니다.
        //일정한 속도로 목표 지점까지 이동하게 만드는 스크립트


        //Circle.transform.position = Vector3.MoveTowards(Circle.transform.position, pos, Time.deltaTime);
        //Vector3.MoveTowards(시작지머, 끝 지점, 이동속도);

        Circle.transform.position = Vector3.Slerp(Circle.transform.position, pos, 0.05f);
        //원형으로 일정한 속도를 가지고 목표 지점까지 이동하게 만드는 스크립트


    }
}
