using System;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class ItemController : MonoBehaviour
{

    public GameObject item;
    PlayerController playerController;

    void Start()
    {
        
    }

 
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            GetItem();
        }
        
    }

    public void GetItem()
    {
        if (gameObject.name == "JumpItem")
        {
            playerController.jump = playerController.jump * 2;
        }

    }
}
