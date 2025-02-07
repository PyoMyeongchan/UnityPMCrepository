using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class MaterialChnage : MonoBehaviour
{
    
    public Material skyboxMaterial;

    // Update is called once per frame
    void Start()
    {
        
           RenderSettings.skybox = skyboxMaterial;
              
       
    }
}
