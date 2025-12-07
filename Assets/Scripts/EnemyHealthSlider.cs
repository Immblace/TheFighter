using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthSlider : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private Enemy enemy;


    private void OnEnable()
    {
        enemy.onEnemyGetDamage += RefreshHealthBar;
    }

    private void OnDisable()
    {
        enemy.onEnemyGetDamage -= RefreshHealthBar;
    }

    private void RefreshHealthBar(float EnemyHealth)
    {
        healthBar.value = EnemyHealth / 10;
    }
}
