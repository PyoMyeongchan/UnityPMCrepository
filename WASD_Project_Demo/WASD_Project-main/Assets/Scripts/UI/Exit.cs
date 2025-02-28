using UnityEngine;

public class Exit : MonoBehaviour
{  
        void Update()
        {
            if (Input.GetKey("escape"))
                Application.Quit();

        }
    
}
