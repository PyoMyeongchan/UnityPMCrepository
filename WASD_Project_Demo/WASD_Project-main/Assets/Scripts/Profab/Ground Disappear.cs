using UnityEngine;

public class GroundDisappear : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("Disappear", 0.5f);
        
        }
    }

    void Disappear()
    { 
        Destroy(gameObject);
    
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
