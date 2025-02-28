using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Image Item;        
    int current;

    void Start()
    {
        ItemKeeper.haskey = current;
        UpdateItemUI();
    }

    void Update()
    {
        UpdateItemUI();
    }

    private void UpdateItemUI()
    {
        if (Item != null)
        {
            Item.pixelsPerUnitMultiplier = (float)current + (float)ItemKeeper.haskey;
        }
    }
}
