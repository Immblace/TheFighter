using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private Enemy enemy;


    private void OnEnable()
    {
        enemy.EnemyGetDamage += RefreshHealthBar;
    }

    private void OnDisable()
    {
        enemy.EnemyGetDamage -= RefreshHealthBar;
    }

    private void RefreshHealthBar()
    {
        float currentHP = enemy.EnemyHPInfo();
        healthBar.value = currentHP / 10;
    }
}
