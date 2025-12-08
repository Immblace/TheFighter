using NUnit.Framework;
using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public class SaveData 
{
    public PlayerData player;
    public List<EnemyData> enemies;
    public List<InventoryData> inventoryItems;
    public AmmoData ammo;
}
