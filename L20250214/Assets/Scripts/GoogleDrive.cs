using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GoogleDrive : MonoBehaviour
{
    private string imageFileURL = "https://drive.usercontent.google.com/u/0/uc?id=11Tp6Vy-ajbF_H4-yHTqu9TEfTQ_05x23&export=download";
    private string imageFileURL2 = "https://drive.usercontent.google.com/u/0/uc?id=1QZWYgj9V8MdrhCxqsGw9LP_k0dyewhHI&export=download";

    public Image image;
    

    public void Start()
    {
        
    }

    public void Button()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageFileURL); 
        

        if (www.result == UnityWebRequest.Result.Success)
        {
            var texture = ((DownloadHandlerTexture)www.downloadHandler).texture;

            //Texture2D를 UI에서 쓰기 위해 Sprite 형태로 변경
            var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, 1.0f);
            Debug.Log("이미지를 성공적으로 가져왔습니다.");
            image.sprite = sprite;

        }
        else
        {
            Debug.LogError("이미지를 가져오지 못했습니다.");
        }
    }

    public void Button2()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageFileURL2);

        if (www.result == UnityWebRequest.Result.Success)
        {
            var texture = ((DownloadHandlerTexture)www.downloadHandler).texture;

            //Texture2D를 UI에서 쓰기 위해 Sprite 형태로 변경
            var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, 1.0f);
            Debug.Log("이미지를 성공적으로 가져왔습니다.");
            image.sprite = sprite;

        }
        else
        {
            Debug.LogError("이미지를 가져오지 못했습니다.");
        }


    }
    
    
}
