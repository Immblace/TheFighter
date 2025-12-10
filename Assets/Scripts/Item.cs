using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefabInv;
    [SerializeField] private int itemType;
    private Player player;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.inventory.CheckSlots(itemPrefabInv);
            Destroy(gameObject);
        }
    }

    public DropData GetDropData()
    {
        Vector2 pos = transform.position;
        return new DropData()
        {
            itemType = itemType,
            x = pos.x,
            y = pos.y
        };
    }

    public void ApplyDropData(DropData data)
    {
        transform.position = new Vector3(data.x, data.y, 0f);
    }


}
