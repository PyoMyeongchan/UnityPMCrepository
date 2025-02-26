using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f;
    Vector3 dir;

    public GameObject explosinFactory;

    private void Start()
    {
  
        // ���� ���� ����

        int rand = Random.Range(0, 10);

        // 10�� �߿��� 3���̹Ƿ� �� 30% Ȯ���̶�� �� �� ����
        if (rand < 3)
        {
            var target = GameObject.Find("Player");

            dir = target.transform.position - transform.position;

            dir.Normalize(); // ������ ũ�⸦ 1�� �����մϴ�.
                             // ���� ���� : Vector3.up, Vector3.down, Vector3.left ...


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
        sm.currentScoreText.text = "�������� : " + sm.currentscore;
        if (sm.currentscore > sm.bestscore)
        { 
            sm.bestscore = sm.currentscore;
            sm.bestScoreText.text = "�ְ����� : " + sm.bestscore;
            PlayerPrefs.SetInt("BestScore", sm.bestscore);

        }


    }
}
