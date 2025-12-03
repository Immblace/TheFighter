using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletDamage = 1f;
    private Vector3 bulletDirection;
    private float speed = 10f;


    void Update()
    {
        transform.Translate(bulletDirection * speed * Time.deltaTime);
    }


    public void Initialization(Vector3 direction, float damage)
    {
        bulletDirection = direction;
        bulletDamage = damage;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamagable>(out IDamagable hit))
        {
            hit.GetDamage(bulletDamage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
