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

        GameObject smobjext = GameObject.Find("ScoreManager");
        ScoreManager sm = smobjext.GetComponent<ScoreManager>();
        sm.currentscore++;
        sm.currentScoreText.text = "현재점수 : " + sm.currentscore;
        if (sm.currentscore > sm.bestscore)
        { 
            sm.bestscore = sm.currentscore;
            sm.bestScoreText.text = "최고점수 : " + sm.bestscore;
            PlayerPrefs.SetInt("BestScore", sm.bestscore);

        }


    }
}
