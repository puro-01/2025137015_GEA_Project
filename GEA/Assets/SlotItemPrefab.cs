using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotItemPrefab : MonoBehaviour
{
    public Image itemlmage;
    public TextMeshProUGUI itemText;
    public BlockType blockType;

    public void ItemSetting(Sprite itemSprite, string txt)
    {
        itemlmage.sprite = itemSprite;
        itemText.text = txt;
        blockType = type;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
