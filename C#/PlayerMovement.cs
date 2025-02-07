using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class NewMonoBehaviourScript : MonoBehaviour
{
    public int a = 10;
    public float speed = 5.0f;
    public double jump_force = 5.0;
    public bool isjump = false;

    private Rigidbody2D rigid;


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

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
        Vector3 velocity = new Vector3(x, y, 0) * speed * Time.deltaTime;
        transform.position += velocity;

    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isjump)
            {
                isjump = true;
                rigid.AddForce(Vector3.up * (float)jump_force, ForceMode2D.Impulse);
            }


        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            Debug.Log("∞Ò¿Œ!!!");
            
        }
        if (collision.gameObject.tag == "item")
        {

            collision.gameObject.SetActive(false);


        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isjump = false;
        }
        Debug.Log("∂•¿ª π‚æ“Ω¿¥œ¥Ÿ.");

    }


}
