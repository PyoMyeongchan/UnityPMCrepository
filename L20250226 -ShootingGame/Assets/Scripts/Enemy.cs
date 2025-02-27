using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f;
    Vector3 dir;

    public GameObject explosinFactory;

    private void OnEnable() // 활성화 단계에 호출되는 함수
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
        ScoreManager.instance.score++;


        GameObject explosion = Instantiate(explosinFactory);
        explosion.transform.position = transform.position;

        // 부딪힌 물체의 이름이 bullet이 포함된다면
        // 오브젝트 풀로 만들어질 이름은 Bullet
        if (other.gameObject.name.Contains("Bullet"))
        {
            other.gameObject.SetActive(false);

        }
        else
        { 
            Destroy(other.gameObject);
        }

        gameObject.SetActive(false); // 적도 비활성화


    }
}
