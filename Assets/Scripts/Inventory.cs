using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject[] slots;
    [SerializeField] private TextMeshProUGUI countTxt;
    [SerializeField] private GameObject[] inventoryItemPrefabs;
    [SerializeField] private GameObject[] dropItemPrefabs;
    [SerializeField] private Button dropButton;
    public bool[] isFull = new bool[6];
    private bool isActive;


    private void Start()
    {
        CalculateSlots();
    }

    private void Update()
    {
        CheckInventoryCount();
    }

    public void InventorySwitcher()
    {
        isActive = !isActive;
        gameObject.SetActive(isActive);
        dropButton.gameObject.SetActive(false);
    }

    private void CalculateSlots()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].transform.childCount > 0)
            {
                isFull[i] = true;
            }
        }
    }

    private void CheckInventoryCount()
    {
        int sum = 0;
        for (int i = 0; i < slots.Length; i++)
        {
            if (isFull[i])
            {
                sum++;
            }
        }

        if (sum > 1)
        {
            countTxt.text = sum.ToString();
        }
        else
        {
            countTxt.text = "";
        }
    }

    public void CheckSlots(GameObject item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (!isFull[i])
            {
                isFull[i] = true;
                Instantiate(item, slots[i].transform);
                break;
            }
        }
    }

    public List<InventoryData> GetInventoryData()
    {
        List<InventoryData> inventoryItems = new List<InventoryData>();

        for (int i = 0; i < isFull.Length; i++)
        {
            if (isFull[i])
            {
                ItemInventory itemInv = slots[i].GetComponentInChildren<ItemInventory>();
                InventoryData itemData = new InventoryData()
                {
                    itemType = itemInv.GetItemType(),
                    slotNumber = i
                };

                inventoryItems.Add(itemData);
            }
        }
        return inventoryItems;
    }

    public void ApplyInventoryData(List<InventoryData> data)
    {
        foreach (var item in data)
        {
            GameObject itemPrefab = Instantiate(inventoryItemPrefabs[item.itemType], slots[item.slotNumber].transform);
        }
    }

    public List<DropData> GetAllDropData()
    {
        List<DropData> list = new List<DropData>();

        Item[] dropItems = FindObjectsByType<Item>(FindObjectsSortMode.None);

        if (dropItems != null)
        {
            foreach (Item item in dropItems)
            {
                list.Add(item.GetDropData());
            }
        }
        return list;
    }

    public void SpawnAllItems(List<DropData> data)
    {
        foreach (var item in data)
        {
            GameObject dropItem = Instantiate(dropItemPrefabs[item.itemType]);
            dropItem.GetComponent<Item>().ApplyDropData(item);
        }
    }

}
