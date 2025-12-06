using UnityEngine;
using UnityEngine.UI;

public class ItemInventory : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab;
    private Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    
    public void DropItem()
    {
        Vector3 newPos = new Vector3(player.transform.position.x - 2f, player.transform.position.y - 1f, 0f);
        Instantiate(itemPrefab, newPos, Quaternion.identity);
        Destroy(gameObject);
    }
}
