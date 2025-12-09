using System;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float stopDistance = 1.7f;
    [SerializeField] private GameObject[] dropItemPrefabs;
    [SerializeField] private int enemyType;
    private float health = 10f;
    private float speed = 1.2f;
    private Animator animator;
    private Player player;
    public event Action<float> onEnemyGetDamage;
    private bool PlayerDetection = false;
    private float timeToAttack = 0.5f;
    private bool readyforAttack = false;
    private float enemyDamage = 1f;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (PlayerDetection)
        {
            RunToPlayer();
        }

        if (readyforAttack)
        {
            Attack();
        }
    }

    private void RunToPlayer()
    {
        if (player != null)
        {
            Vector3 distance = player.transform.position - transform.parent.position;

            if (distance.magnitude > stopDistance)
            {
                animator.SetInteger("State", (int)States.Walk);
                Vector3 direction = (player.transform.position - transform.parent.position).normalized;
                transform.parent.position += direction * speed * Time.deltaTime;
                readyforAttack = false;
            }
            else
            {
                if (!readyforAttack)
                {
                    readyforAttack = true;
                    animator.SetInteger("State", (int)States.Idle);
                }
            }
        }
    }

    private void Attack()
    {
        if (timeToAttack > 0)
        {
            timeToAttack -= Time.deltaTime;
        }
        else
        {
            animator.SetInteger("State", (int)States.Attack);
            Collider2D[] collider = Physics2D.OverlapCircleAll(attackPoint.position, 3f, playerLayer);

            foreach (var collision in collider)
            {
                if (collision.gameObject.TryGetComponent<IDamagable>(out IDamagable hit))
                {
                    hit.GetDamage(enemyDamage);
                }
            }
            readyforAttack = false;
            timeToAttack = UnityEngine.Random.Range(0.8f, 3.5f);
        }
    }

    public void GetDamage(float damage)
    {
        health -= damage;
        onEnemyGetDamage?.Invoke(health);

        if (health == 0)
        {
            Instantiate(dropItemPrefabs[UnityEngine.Random.Range(0,dropItemPrefabs.Length)], transform.position, Quaternion.identity);
            Destroy(transform.parent.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerDetection = true;
            player = collision.gameObject.GetComponent<Player>();

            if (player.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetInteger("State", (int)States.Idle);
            PlayerDetection = false;
            player = null;
        }
    }

    public EnemyData GetEnemyData()
    {
        Vector3 pos = transform.parent.position;
        return new EnemyData()
        {
            enemyType = enemyType,
            health = health,
            x = pos.x,
            y = pos.y
        };
    }

    public void ApplyEnemyData(EnemyData data)
    {
        transform.parent.position = new Vector3(data.x, data.y, 0f);
        health = data.health;
        onEnemyGetDamage?.Invoke(health);
    }

    private enum States
    {
        Idle,
        Walk,
        Attack
    }
}
