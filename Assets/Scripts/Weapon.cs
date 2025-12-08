using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform bulletSpawn;
    private float damage = 1f;


    public void Shoot()
    {
        if (AmmoManager.instance.TryUseAmmo())
        {
            Bullet bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            bullet.Initialization(damage);
        }
    }
}
