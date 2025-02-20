using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    
    
    public string sceneName;


    public void Load()
    {
        SceneManager.LoadScene(sceneName);

    }

   
   
}
