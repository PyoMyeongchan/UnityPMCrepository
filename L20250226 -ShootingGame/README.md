#### 슈팅게임 만들기

* 기본설정
  * 해상도 640 * 960
  * 카메라 오토그래픽모드
  * Window - Rendering -Environment - lighting : Color - 255/255/255
  * Ambient Color(환경광) - 빛이 없어도 물체의 색을 그대로 표현

|공식|설명|
|:------|:------|
|물체의 이동 공식| P = P0 + vt <br> 미래의 위치 = 현재의 위치 + 속도 * 시간|
|등가속도 운동| V = V0 + AT <br> 속도 = 현재속도 + 가속도 * 시간|
|가속도|F = ma <br> 힘 = 질량 * 가속도 |

1. 플레이어 설정
  - 플레이어인 큐브 제작
  - 총알인 캡슐 제작
  - 플레이어 스크립트 넣기

`` 플레이어 움직임 코드

    	using UnityEngine;

	public class PlayerMove : MonoBehaviour
	{public float speed = 5.0f;


    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, v, 0);

        //transform.translate

        transform.position += dir * speed * Time.deltaTime;

        // 물체의 이동 공식
        // P = P0 + vt
        // 미래의 위치 = 현재의 위치 + 속도 * 시간

        // 등가속도 운동
        // V = V0 + AT
        // 속도 = 현재속도 + 가속도 * 시간

        // 가속도
        // F = ma
        // 힘 = 질량 * 가속도


    }


``


`` 플레이어의 총구 설정 + 플레이어에 빈gameObjects넣고 총구로 설정

	using UnityEngine;

	public class PlayerFire : MonoBehaviour
	{
    public GameObject bulletFactory; // 총알 프리팹
    public GameObject firePosition;  // 총구

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Left crtl
        {
            // 총알 생성
            GameObject bullet = Instantiate(bulletFactory);

            // 총알 위치 변경
            bullet.transform.position = firePosition.transform.position;
        }
    }
	}
``

<hr>
  
2. 총알 설정

``총구에서 나올 총알 설정

 	using UnityEngine;

	public class Bullet : MonoBehaviour	
	{
    public float speed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }


	}
``

- 총구에 총알이 나오도록 컴포넌트 설정

<hr>
  
3. 적 만들기
  - 슈팅게임인 만큼 적이 필요하다. 위에서 나올 적 만들기작업

`` 적은 플레이어와 충돌하거나 총알에 충돌하면 사라짐 (+ 파티클 작업으로 사라지면서 나오는 효과 넣어줘야한다.)

    using UnityEngine;

	public class Enemy : MonoBehaviour
	{
    public float speed = 3.0f;
    Vector3 dir;

    public GameObject explosinFactory;

    private void Start()
    {
  
        // 적의 방향 설정

        int rand = Random.Range(0, 10);

        // 10개 중에서 3개이므로 약 30% 확률이라고 볼 수 있음
        if (rand < 3)
        {
            var target = GameObject.Find("Player");

            dir = target.transform.position - transform.position;

            dir.Normalize(); // 방향의 크기를 1로 설정합니다.
                             // 방형 벡터 : Vector3.up, Vector3.down, Vector3.left ...


        }
        else 
        {
            dir = Vector3.down;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        
        GameObject explosion = Instantiate(explosinFactory);
        explosion.transform.position = transform.position;

        Destroy(other.gameObject);
        Destroy(gameObject);



    }
	}
``
<hr>

4. 적의 스포너를 만들어 랜덤하게 맵에 나올 수 있도록 설정

`` 스포너를 맵위로 여러개 설치해서 랜덤하게 나오도록

 	using UnityEngine;

	public class EnemyManager : MonoBehaviour
	{    
    float currentTime;
    public float createTime = 1.0f;
    public GameObject enemyFactory;
    float min = 1, max = 5;

    public void Start()
    {
        createTime = Random.Range(min, max);
    }


    private void Update()
    {
        // 시간이 흐른다.
        currentTime += Time.deltaTime;

        // 현재 시간이 일정 시간에 도달한다면 적을 생성
        if (currentTime >= createTime)
        { 
            GameObject enemy = Instantiate(enemyFactory);

            enemy.transform.position = transform.position;
            // 소환 후 시간을 0으로 리셋합니다.
            currentTime = 0;
            createTime = Random.Range(min, max);
        }

    }

	}
``

<hr>

5. 게임의 메모리를 위해 충돌하지않고 지나가는 적을 삭제해주는 D-Zone을 만들어야한다!

``D-Zone에 적이나 총알이 충돌할 경우 삭제되도록 설정

	using UnityEngine;

	public class DZone : MonoBehaviour
	{


    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
	
    }
	}
``
트리거와 충돌로 작용하는것 차이
-OnTriggerEnter의 함수사용을 위해 트리거를 받는 오브젝트의 콜라이더에서 trigger를 true로 해야함
-충돌은 아님.

-isKinematic 으로 충돌을 인지
-레이어 설정을 D-ZONE으로

#### Physics 설정에서 레이어끼리 충돌하지않도록 설정!!

<hr>

5. 뒷배경 설정
  - material을 생성하여 해당 배경을 설정
  - Quad를 생성해서 material 넣기
  - 움직이는 효과를 내기위해 배경을 Scroll하여 연출
  - 확인한 것 : 머티리얼의 offset을 건드렸더니 이미지가 밀림.

`` 배경의 움직임 표현
	
 	using UnityEngine;

	public class BackGround : MonoBehaviour
	{
    public Material backgroundMaterial;

    public float scrollSpeed = 0.2f;

    void Update()
    {
        Vector2 dir = Vector2.up;

        backgroundMaterial.mainTextureOffset += dir * scrollSpeed * Time.deltaTime;
    }
	}
 ``


+Tip.변수 표기법

backMoon - 일반 변수

BackMoon - 클래스 이름, 이벤트, 프로퍼티, 네임스페이스

back_moon - c++

필드 변수가 private일경우 _로 이름을 시작하는 경우가 있
 
