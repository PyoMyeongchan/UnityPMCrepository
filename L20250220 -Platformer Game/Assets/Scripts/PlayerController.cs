using System;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem.Processors;


[RequireComponent (typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    Animator animator;
    string current; // 현재 진행중인 애니메이션
    string previous; // 기존에 진행 중인 애니메이션

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

    public static string state = "Playing"; // 현재의 상태(플레이 중)
    


    
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

        // 수평 이동 - 세세한 움직임을 구현하고자하자면 GetAxis로 사용할 것
        axisH = Input.GetAxisRaw("Horizontal");


        if (axisH > 0.0f)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (axisH < 0.0f)
        {
            //백터가 -로 잡히게 되면 좌우 반전
            //Sprite Renderer를 불러서 Flip X를 지정하는 것이 더 안전하긴하다.
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

        // 지정한 두 점을 연결하는 가상의 선에 게임 오브젝트가 접촉하는지를 조사해 true 또는 false로 return해주는 함수
        // up은 Vector 기준 (0,1,0)입니다.
        // 플레이어의 현재 pivot은 bottom

        onGround = Physics2D.Linecast(transform.position, transform.position - (transform.up * 0.1f), groundLayer);

        // 지면 위에 있거나 또는 속도가 0이 아닌 경우
        if (onGround || axisH != 0)
        {
            rbody.linearVelocity = new Vector2(speed * axisH, rbody.linearVelocityY);
        }

        // 지면 위에 있는 상태에서 점프키가 눌린 상황
        if (onGround && goJump)
        { 
            Vector2 jumpPw = new Vector2(0,jump); // 플레이어가 가진 점프 수치만큼 벡터설계
            rbody.AddForce(jumpPw, ForceMode2D.Impulse); // 해당 위치로 힘을 가합니다.
            goJump = false;
        }


        if (onGround)
        {
            if (axisH == 0)
            {
                //Enum.GetName(typeof(enum명),값);
                //해당 enum에 있는 그 값의 이름을 얻어오는 기능
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

        // 현재의 모션이 이전의 모션과 다른 경우(애니메이션이 바뀐 경우)
        if (current != previous)
        { 
            previous = current; // 이전 동작에 대한 세이브
            animator.Play(current); // 현재의 모션 플레이
        
        }


    }


    private void Jump()
    {
        // 플래그 키는 작업
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
        // 현재 플레이어가 가지고 있는 콜라이더의 활성화를 비활성화로 설정합니다.(더 이상 충돌이 발생하지 않도록)
        GetComponent<Collider2D>().enabled = false;
        rbody.AddForce(new Vector2(0, 7), ForceMode2D.Impulse);
    }

    public void GameStop()
    {
        // 속력을 0으로 만들어서 움직이지 못하게
        rbody.linearVelocity = new Vector2(0, 0);
    }

}
