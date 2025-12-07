using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject[] slots;
    [SerializeField] private TextMeshProUGUI countTxt;
    public bool[] isFull = new bool[6];
    private bool isActive;

    private int slot1;
    private int slot2;
    private int slot3;
    private int slot4;
    private int slot5;
    private int slot6;

    private int sum;


    private void Update()
    {
        if (isFull[0])
        {
            slot1 = 1;
        }
        else
        {
            slot1 = 0;
        }

        if (isFull[1])
        {
            slot2 = 1;
        }
        else
        {
            slot2 = 0;
        }

        if (isFull[2])
        {
            slot3 = 1;
        }
        else
        {
            slot3 = 0;
        }

        if (isFull[3])
        {
            slot4 = 1;
        }
        else
        {
            slot4 = 0;
        }

        if (isFull[4])
        {
            slot5 = 1;
        }
        else
        {
            slot5 = 0;
        }

        if (isFull[5])
        {
            slot6 = 1;
        }
        else
        {
            slot6 = 0;
        }

        sum = slot1 + slot2 + slot3 + slot4 + slot5 + slot6;

        if (sum > 1)
        {
            countTxt.text = sum.ToString();
        }
        else
        {
            countTxt.text = "";
        }

    }

    public void InventorySwitcher()
    {
        isActive = !isActive;
        gameObject.SetActive(isActive);
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




}
