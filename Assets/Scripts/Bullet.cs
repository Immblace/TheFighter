using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletDamage = 1f;
    private float speed = 10f;


    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }


    public void Initialization(float damage)
    {
        bulletDamage = damage;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            return;
        }

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
