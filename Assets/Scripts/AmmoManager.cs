using System;
using TMPro;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammoText;
    public static AmmoManager instance;

    private int MaxAmmo = 30;
    private int CurrentAmmo;


    private void Awake()
    {
        instance = this;
        CurrentAmmo = MaxAmmo;
        ammoText.text = "ammo: " + CurrentAmmo + "/" + MaxAmmo;
    }

    public bool TryUseAmmo()
    {
        if (CurrentAmmo <= 0) return false;

        CurrentAmmo--;
        ammoText.text = "ammo: " + CurrentAmmo + "/" + MaxAmmo; 
        return true;
    }

    public AmmoData GetAmmoData()
    {
        return new AmmoData()
        {
            Ammo = CurrentAmmo
        };
    }

    public void ApplyAmmoData(AmmoData data)
    {
        CurrentAmmo = data.Ammo;
        ammoText.text = "ammo: " + CurrentAmmo + "/" + MaxAmmo;
    }
}
