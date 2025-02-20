using System;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem.Processors;


[RequireComponent (typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    Animator animator;
    string current; // ���� �������� �ִϸ��̼�
    string previous; // ������ ���� ���� �ִϸ��̼�

    public enum ANIME_STATE
    { 
        PlayerIDLE,
        PlayerRun,
        PlayerJump,
        PlayerClear,
        PlayerGameOver   
    
    }


    Rigidbody2D rbody;
    float axisH = 0.0f;
    public float speed = 3.0f;

    public float jump = 9.0f;
    public LayerMask groundLayer;
    bool goJump = false;
    bool onGround = false;

    public static string state = "Playing"; // ������ ����(�÷��� ��)
    


    
    void Start()
    {
        animator = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>();
        state = "Playing";
    }

    
    void Update()
    {
        if (state != "Playing")
        {
            return;
        
        }

        // ���� �̵� - ������ �������� �����ϰ������ڸ� GetAxis�� ����� ��
        axisH = Input.GetAxisRaw("Horizontal");


        if (axisH > 0.0f)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (axisH < 0.0f)
        {
            //���Ͱ� -�� ������ �Ǹ� �¿� ����
            //Sprite Renderer�� �ҷ��� Flip X�� �����ϴ� ���� �� �����ϱ��ϴ�.
            transform.localScale = new Vector2(-1, 1);
            
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        
        }
    }

    private void FixedUpdate()
    {
        if (state != "Playing")
        {
            return;

        }

        // ������ �� ���� �����ϴ� ������ ���� ���� ������Ʈ�� �����ϴ����� ������ true �Ǵ� false�� return���ִ� �Լ�
        // up�� Vector ���� (0,1,0)�Դϴ�.
        // �÷��̾��� ���� pivot�� bottom

        onGround = Physics2D.Linecast(transform.position, transform.position - (transform.up * 0.1f), groundLayer);

        // ���� ���� �ְų� �Ǵ� �ӵ��� 0�� �ƴ� ���
        if (onGround || axisH != 0)
        {
            rbody.linearVelocity = new Vector2(speed * axisH, rbody.linearVelocityY);
        }

        // ���� ���� �ִ� ���¿��� ����Ű�� ���� ��Ȳ
        if (onGround && goJump)
        { 
            Vector2 jumpPw = new Vector2(0,jump); // �÷��̾ ���� ���� ��ġ��ŭ ���ͼ���
            rbody.AddForce(jumpPw, ForceMode2D.Impulse); // �ش� ��ġ�� ���� ���մϴ�.
            goJump = false;
        }


        if (onGround)
        {
            if (axisH == 0)
            {
                //Enum.GetName(typeof(enum��),��);
                //�ش� enum�� �ִ� �� ���� �̸��� ������ ���
                current = Enum.GetName(typeof(ANIME_STATE), 0);
            }
            else
            {
                current = Enum.GetName(typeof(ANIME_STATE), 1);
            }
        }
        else
        {
            current = Enum.GetName(typeof(ANIME_STATE), 2);

        }

        // ������ ����� ������ ��ǰ� �ٸ� ���(�ִϸ��̼��� �ٲ� ���)
        if (current != previous)
        { 
            previous = current; // ���� ���ۿ� ���� ���̺�
            animator.Play(current); // ������ ��� �÷���
        
        }


    }


    private void Jump()
    {
        // �÷��� Ű�� �۾�
        goJump = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            Goal();
        }
        else if (collision.gameObject.tag == "Dead")
        {
            Dead();
        }
    }

    public void Goal()
    {
        animator.Play(Enum.GetName(typeof(ANIME_STATE), 3));
        state = "gameclear";
        GameStop();
    }

    

    public void Dead()
    {
        animator.Play(Enum.GetName(typeof(ANIME_STATE), 4));
        state = "gameover";
        GameStop();
        // ���� �÷��̾ ������ �ִ� �ݶ��̴��� Ȱ��ȭ�� ��Ȱ��ȭ�� �����մϴ�.(�� �̻� �浹�� �߻����� �ʵ���)
        GetComponent<Collider2D>().enabled = false;
        rbody.AddForce(new Vector2(0, 7), ForceMode2D.Impulse);
    }

    public void GameStop()
    {
        // �ӷ��� 0���� ���� �������� ���ϰ�
        rbody.linearVelocity = new Vector2(0, 0);
    }

}
