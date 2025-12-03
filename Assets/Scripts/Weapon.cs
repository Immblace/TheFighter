using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform bulletSpawn;
    private float damage = 1f;





    public void Shoot(Vector3 bulletDirection)
    {
        Bullet bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
        bullet.Initialization(bulletDirection, damage);
    }



}
