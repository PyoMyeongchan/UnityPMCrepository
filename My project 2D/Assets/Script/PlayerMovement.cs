using System;
using UnityEngine;
//�÷��̾��� �̵�(������ٵ�)

//�ش� ����� ���� �� ��ũ��Ʈ�� ������Ʈ�ν� ����� ���
//������� ������Ʈ�� �䱸�ϰ� �˴ϴ�.
//1. �ش� ������Ʈ�� ���� ������Ʈ�� ������ ��쿡�� �ڵ����� ������ ����
//2. �� ��ũ��Ʈ�� ����� ���¶�� �� ������Ʈ�� ����� ������Ʈ�� ������ �� �����ϴ�.

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    public int a = 10;
    public float speed = 2.0f; //�Ҽ����� ���� ���� �������� f ��ȣ�� ����մϴ�.

    //�Ҽ��� �� 6�ڸ� ���� ��Ȯ�ϰ� ���

    public double jump_force = 3.5; //double�� �Ǽ��� ǥ���ϴ� �ڷ����̸� �� ��쿡�� f�� ������ �ʽ��ϴ�.

    //�Ҽ��� �� 15 �ڸ� ���� ��Ȯ�ϰ� ���

    public bool isjump = false;

    private Rigidbody2D rigid;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        //GetComponent<T>
        //�ش� ������Ʈ�� ���� ������ ���
        //T�κп��� ������Ʈ�� ���¸� �ۼ����ݴϴ�.
        //������Ʈ�� ���°� �ٸ��ٸ� ���� �߻�
        //�ش� �����Ͱ� �������� ���� ����� null(���� ����)�� ��ȯ�ϰ� �˴ϴ�.

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        //GetAxisRaw("Ű�̸�");�� ��ǲ �Ŵ����� Ű�� �����鼭
        //Ŭ���� ���� -1, 0, 1�� ��ġ�� ���� ���ɴϴ�.

        //Horizontal : ���� �̵� a, d Ű�� Ű������ ����, ������ Ű
        //Vertical : ���� �̵� w, s Ű�� Ű������ ��, �Ʒ� Ű

        //���� �ڵ带 ���� ������ ������ ����մϴ�.

        Vector3 velocity = new Vector3(x, y, 0) * speed * Time.deltaTime;
        //�ӷ� = ���� * �ӵ�

        transform.position += velocity;

    }

    private void Jump()
    {
        //����ڰ� Ű���� Space Ű�� �Է��ߴٸ�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //!�� ������ �ݴ�� ó���ϴ� ���
            //������ ����� true�� ��� false
            //������ ����� false�� ��� true

            if (!isjump) //���� ���°� �ƴ� ���
            {
                isjump = true; //���� ���·� �����մϴ�.
                rigid.AddForce(Vector3.up * (float)jump_force,ForceMode2D.Impulse); //�ѹ��� ����� �ִ°� Impulse
                //type casting(Ÿ�� ĳ����)
                //(Ÿ�� �̸�) ������ ���� �ش� ������ ������ Ÿ������ ������ �� �ֽ��ϴ�.
                //�� ĳ������ ������ ���������� ������ �� �ֽ��ϴ�.

                //�ַ� int �� float ���� ���� ����
                //������ Ÿ���� ���� ȣȯ���� �ʴ� ����� ��� �Ұ�
              
            }
        }
       

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            Debug.Log("����!!!");
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //����Ƽ���� ũ�⸦ ���ϴ� ������
        //a==b : a�� b�� ũ�Ⱑ �����ϴ�.(���� ����)
        //a!=b : a�� b�� ũ�Ⱑ �ٸ���.(���� �ٸ���)
        //a>b,a<b,a>=b,a<=b
        //�浹ü�� ���� ������Ʈ�� ���̾ 7�� ������ �� ũ�Ⱑ ���ٸ�
        if (collision.gameObject.layer == 7)
        {
            isjump = false;
        }
        Debug.Log("���� ��ҽ��ϴ�.");

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isjump = false;
        }
        Debug.Log("���� ��ҽ��ϴ�.");
    }
   
}