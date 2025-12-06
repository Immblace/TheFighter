using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject GameOverMenu;
    [SerializeField] private GameObject[] SceneObjects;

    private void Start()
    {
        GameOverMenu.SetActive(false);
    }


    private void OnEnable()
    {
        player.onDead += GameOver;
    }

    private void OnDisable()
    {
        player.onDead -= GameOver;
    }

    public void GameOver()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        foreach (var enemy in enemies)
        {
            Destroy(enemy.transform.parent.gameObject);
        }
        

        foreach (var obj in SceneObjects)
        {
            obj.SetActive(false);
        }

        GameOverMenu.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
