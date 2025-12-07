using UnityEngine;

public class ManagerData : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Inventory inventory;

    private void Start()
    {
        LoadGame();
    }

    public void SaveGame()
    {
        SaveData data = new SaveData();
        data.player = player.GetPlayerData();

        SystemData.Save(data);
    }

    public void LoadGame()
    {
        SaveData data = SystemData.Load();

        if (data == null) return;

        player.ApplyPlayerData(data.player);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }
}
