using UnityEngine;
using UnityEngine.UI;

public class ItemInventory : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private Button dropBtn;
    private Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    
    public void dropp()
    {
        dropBtn.gameObject.SetActive(true);
        dropBtn.onClick.AddListener(DropItem);
    }

    public void DropItem()
    {
        Vector3 newPos = new Vector3(player.transform.position.x - 2f, player.transform.position.y - 1f, 0f);
        Instantiate(itemPrefab, newPos, Quaternion.identity);
        Destroy(gameObject);
    }
}
