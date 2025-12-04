using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotItemPrefab : MonoBehaviour, IPointerClickHandler
{
    public Image itemlmage;
    public TextMeshProUGUI itemText;
    public ItemType blockType;
    public CraftingPanel craftingPanel;

    public void ItemSetting(Sprite itemSprite, string txt, ItemType type)
    {
        itemlmage.sprite = itemSprite;
        itemText.text = txt;
        blockType = type;
    }
    
    void Awake()
    {
        if (!craftingPanel)
            craftingPanel = FindAnyObjectByType<CraftingPanel>(true);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Right) return;
        if (!craftingPanel) return;

        craftingPanel.AddPlanned(blockType, 1);
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
