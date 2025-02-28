using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{    
    public Image heartImage;
    int maxHp = 3;

    void Start()
    {
            APlayerController.playerHp = maxHp;
            UpdateHealthUI();
    }

    void Update()
    {
            UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        if (heartImage != null)
        {
                heartImage.fillAmount = (float)APlayerController.playerHp / maxHp;
        }
    }
}
