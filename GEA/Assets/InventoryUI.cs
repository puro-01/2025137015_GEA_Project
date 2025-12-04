using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    #region //각 큐브 별 스프라이트
    public Sprite dirtSprite;
    public Sprite diamondSprite;
    public Sprite grassSprite;
    public Sprite waterSprite;
    public Sprite cloudSprite;
    #endregion
    public List<Transform> Slot = new List<Transform>();
    public GameObject SlotIrem;
    List<GameObject> items = new List<GameObject>();

    public int selectedIndex = -1;

    public void UpdateInventory(Inventory myInven)
    {
        //1. 기존 슬롯 초기화
        foreach(var slotItems in items)
        {
            Destroy(slotItems);
        }
        items.Clear();
        //2. 내 인벤토리 데이터를 전체 탐색
        int idx = 0;
        foreach (var item in myInven.items)
        {
#region 슬롯아이템 생성 로직 (게임오브젝트 인스턴스 생성, 위치 조정, SlotItemPrefab 컴포넌트 가져오기, 그 후 아이템 세팅
            var go = Instantiate(SlotIrem, Slot[idx].transform);
            go.transform.localPosition = Vector3.zero;
            SlotItemPrefab sItem = go.GetComponent<SlotItemPrefab>();
            item.Add(go);
#endregion
            switch (item.Key)
            {
                case BlockType.Dirt:
                    sItem.ItemSetting(dirtSprite, "x" + item.Value.ToString(), item.Key);
                    break;
                case BlockType.Grass:
                    sItem.ItemSetting(grassSprite, "x" + item.Value.ToString(), item.Key);
                    break;
                case BlockType.Water:
                    sItem.ItemSetting(waterSprite, "x" + item.Value.ToString(), item.Key);
                    break;

            }

            idx++;

        }
    }
    private void Update()
    {
        for (int i = 0; i < Mathf.Min(9, Slot.Count); i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                SetSelectedIndex(i);
            }
        }
    }
    public void SetSelectedIndex(int idx)
    {
        ResetSelection();
        if (selectedIndex == idx)
        {
            selectedIndex = -1;
        }
        else
        {
            if (idx >= items.Count)
            {
                selectedIndex = -1;
            }
            else
            {
                SetSelection(idx);
                selectedIndex = idx;
            }
        }
    }
    public void ResetSelection()
    {
        foreach(var slot in Slot)
        {
            slot.GetComponent<Image>().color = Color.White;
        }
    }

    void SetSelection(int _idx)
    {
        Slot[_idx].GetComponent<Image>().color = Color.yellow;
    }

    public BlockType GetInventorySlot()
    {
        return items[selectedIndex].GetComponent<SlotItemPrefab>().blockType;
    }
}
