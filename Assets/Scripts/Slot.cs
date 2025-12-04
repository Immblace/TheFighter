using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] private int slotNumber;
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




}
