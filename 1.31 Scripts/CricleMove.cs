using UnityEngine;

public class CricleMove : MonoBehaviour
{
    //Circle�� ������ ��ġ�� Lerp ��Ű�� ��ũ��Ʈ

    public GameObject Circle;
    Vector3 pos = new Vector3(5, -3, 0);


    void Update()
    {
        //Circle.transform.position = Vector3.Lerp(Circle.transform.position, pos,Time.deltaTime);
        //0 �� �Է��� ��� �������� �ʽ��ϴ�.
        //1 �� �ִ�ġ�Դϴ�.
        //������ �ӵ��� ��ǥ �������� �̵��ϰ� ����� ��ũ��Ʈ


        //Circle.transform.position = Vector3.MoveTowards(Circle.transform.position, pos, Time.deltaTime);
        //Vector3.MoveTowards(��������, �� ����, �̵��ӵ�);

        Circle.transform.position = Vector3.Slerp(Circle.transform.position, pos, 0.05f);
        //�������� ������ �ӵ��� ������ ��ǥ �������� �̵��ϰ� ����� ��ũ��Ʈ


    }
}
