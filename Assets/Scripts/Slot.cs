using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private int slotNumber;
    [SerializeField] private Button dropButton;
    private Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }


    
    private void Update()
    {
        if (transform.childCount < 1)
        {
            player.inventory.isFull[slotNumber] = false;
        }
    }


    public void ShowDropBtn()
    {
        if (transform.childCount > 0)
        {
            dropButton.onClick.RemoveAllListeners();
            dropButton.onClick.AddListener(() =>
            {
                gameObject.GetComponentInChildren<ItemInventory>().DropItem();
                dropButton.gameObject.SetActive(false);
            });

            dropButton.gameObject.SetActive(true);
        }
    }

}
