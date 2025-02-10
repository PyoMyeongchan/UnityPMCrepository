using UnityEngine;

public class VectorSample : MonoBehaviour
{
    //�⺻���� (x,y,z) ������ ���� �ۼ�
    //(0,0,0)
    Vector3 vec = new Vector3();
    float x, y, z;

    Vector3 custom_vec = new Vector3();

    //����Ƽ �⺻ ����(���� ��)
    //Vector3 a = Vector.up;(0,1,0);
    //�̸�(��ǥ)
    //up(0,1,0)
    //down(0,-1,0)
    //left(-1,0,0)
    //right(1,0,0)
    //forward(0,0,1)
    //back(0,0,-1)
    //one(1,1,1)
    //zero(0,0,0)

    //���� �⺻ ����(����, ����, ������, ����)
    Vector3 a = new Vector3(1,2,0);
    Vector3 b = new Vector3(3,4,0);


    Vector3 some = Vector3.zero;
    float point = 5.0f;
    //���� ����

    Vector3 Asite = new Vector3(10,0,0);
    Vector3 Bsite = new Vector3(5,0,0);

    void Start()
    {
        //���� : �ܰ������� �ϳ��� ���ʴ�� ó���Ѵ�.
        //������ ����Ǿ ����� �����ϴ�.
        //Ư�� �����ǿ��� ������ ������ ��� ó��
        Vector3 c = a + b;
        var trap_air = some + new Vector3(1, point);
        //var = C#���� ���� �������� �����͸� �ڵ����� �����ϴ� Ű�����Դϴ�.
        //���� �ڵ� �������δ� ���� ���� Vector3�̱� ������ var Vector3

        //����
        //�� ������Ʈ���� �ٸ� ������Ʈ������ �Ÿ��� ������ ���ϴ� ��Ȳ�� ����մϴ�.
        //������ ���� ������ �߿��մϴ�.
        Vector3 d = a - b;

        Vector3 distanse = Asite - Bsite;
        //�� �Ÿ��� ���� �� ������ �Ÿ��� ���ų� ����ٸ� �����ض� ���� �ڵ带 ¥�� �����ϴ�.

        //����
        //������ �� ���п� ��Į�� ���� ���մϴ�.
        //���� * ��Į�� =������ ������ ������ ����Ű�� ����
        //���� ��ü���� ���� ���ְ� ������ ũ�⸦ �����ϴ� ��쿡 ����մϴ�.
        Vector3 e = a * 2;


        //������
        Vector3 Positon = Vector3.one; //(1,1,1)
        Positon = Positon * 4; //(4,4,4)
        Positon = Positon / 4; //(1,1,1)

        //������ ����
        //���� : 2D, 3D �� ����
        //>> �� ������ ������ ���ϰ� �� ����� ��� ���ϴ� ���� ���
        Vector3 k = new Vector3(1,2,3);
        Vector3 L = new Vector3(4,5,6);

        float dot = Vector3.Dot(k, L);
        //k * L = (kx * Lx) + (ky * Ly) + (kz * Lz)
        //�� ����� �� ��ǥ�� �󸶳� ���������� �Ǵ��մϴ�.
        //�� ���� ������ ����



        //���� : 3D���� ���(3D �׷���)
        //���� ���� ��� �ÿ� ���˴ϴ�. (������ ����̳� ������ ���Ͽ� ������ ���� �ǹ�)

        Vector3 cross = Vector3.Cross(k, L);
        //k * L = (ky * Lz - kz * Ly, kz * Lx * kx * Lz, kx * ky = ky * kx)
        //(-3, 72, -3)


        //������ ũ��(������ ����)
        Vector3 m = new Vector3(1, 2, 3);
        float mag = m.magnitude;
        //������ �� ������ ���� ���� ������




    }

}
