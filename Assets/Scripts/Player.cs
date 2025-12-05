using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, IDamagable
{
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private float speed = 5;
    [SerializeField] private Weapon weapon;
    [SerializeField] private Slider healthBar;
    private float health = 10;
    private Animator animator;
    public Inventory inventory;

    private void Start()
    {
        animator = GetComponent<Animator>();
        healthBar.value = health / 10;
    }


    private void Update()
    {
        PlayerMove();
        WeaponRotation();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    private void PlayerMove()
    {
        transform.parent.position += new Vector3(joystick.Horizontal, joystick.Vertical, 0f) * speed * Time.deltaTime;

        if (Mathf.Abs(joystick.Horizontal) != 0 || Mathf.Abs(joystick.Vertical) != 0)
        {
            animator.SetInteger("State", (int)States.Walk);

            if (joystick.Horizontal > 0)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
        else
        {
            animator.SetInteger("State", (int)States.Idle);
        }
    }

    private void WeaponRotation()
    {
        if (weapon != null)
        {
            Vector2 input = new Vector2(joystick.Horizontal, joystick.Vertical);

            if (input.magnitude > 0.2f)
            {
                float angle = Mathf.Atan2(input.y, input.x) * Mathf.Rad2Deg;

                if (transform.localScale.x < 0f)
                {
                    angle += 180f;
                }
                weapon.transform.rotation = Quaternion.Euler(0f, 0f, angle);
            }
        }
    }

    public void Attack()
    {
        if (weapon != null)
        {
            weapon.Shoot();
        }
    }

    public void GetDamage(float damage)
    {
        health-= damage;
        healthBar.value = health / 10;
    }

    private enum States
    {
        Idle,
        Walk
    }
}
