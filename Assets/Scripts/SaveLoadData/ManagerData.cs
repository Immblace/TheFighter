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
        data.player = player.GetPlayerData();
        data.enemies = enemySpawner.GetAllEnemiesData();
        data.ammo = ammoManager.GetAmmoData();

        SystemData.Save(data);
    }

    public void LoadGame()
    {
        SaveData data = SystemData.Load();

        if (data == null) return;

        player.ApplyPlayerData(data.player);
        ammoManager.ApplyAmmoData(data.ammo);

        if (data.enemies != null)
        {
            enemySpawner.ClearAllEnemies();
            enemySpawner.SpawnEnemiesFromSave(data.enemies);
        }
    }

    public void DeleteAllSave()
    {
        SystemData.DeleteSave();
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }
}
