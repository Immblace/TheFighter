using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSlider : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private Player player;

    private void Update()
    {
        transform.parent.position = player.transform.position;
    }


    private void OnEnable()
    {
        player.onGetDamage += RefreshHealthBar;
    }

    private void OnDisable()
    {
        player.onGetDamage -= RefreshHealthBar;
    }

    private void RefreshHealthBar(float PlayerHealth)
    {
        healthBar.value = PlayerHealth / 10;
    }
}
