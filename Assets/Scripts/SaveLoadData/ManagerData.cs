using UnityEngine;

public class ManagerData : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private AmmoManager ammoManager;
    [SerializeField] private Inventory inventory;
    [SerializeField] private EnemySpawner enemySpawner;

    private void Start()
    {
        LoadGame();
    }

    public void SaveGame()
    {
        SaveData data = new SaveData();
        if (player != null)
        {
            data.player = player.GetPlayerData();
        }
        data.enemies = enemySpawner.GetAllEnemiesData();
        data.ammo = ammoManager.GetAmmoData();
        data.inventoryItems = inventory.GetInventoryData();
        data.dropItems = inventory.GetAllDropData();

        SystemData.Save(data);
    }

    public void LoadGame()
    {
        SaveData data = SystemData.Load();

        if (data == null) return;

        player.ApplyPlayerData(data.player);
        ammoManager.ApplyAmmoData(data.ammo);

        if (data.enemies.Count > 0)
        {
            enemySpawner.ClearAllEnemies();
            enemySpawner.SpawnEnemiesFromSave(data.enemies);
        }

        if (data.inventoryItems != null)
        {
            inventory.ApplyInventoryData(data.inventoryItems);
        }

        if(data.dropItems != null)
        {
            inventory.SpawnAllItems(data.dropItems);
        }
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }
}
