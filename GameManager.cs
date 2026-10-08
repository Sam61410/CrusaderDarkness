using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject backGround;
    [SerializeField] GameObject start;
    [SerializeField] GameObject restart;
    [SerializeField] public Slider playerHealthBar;

    public bool gameStarted;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // playerHealthBar.gameObject.SetActive(false);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        gameStarted = false;
        playerHealthBar.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else return;
    }

    public void GameStart()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gameStarted = true;
        Time.timeScale = 1;
        backGround.SetActive(false);
        playerHealthBar.gameObject.SetActive(true);
    }

    public void EndGame()
    {
        restart.gameObject.SetActive(true);
        start.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        backGround.SetActive(true);
        playerHealthBar.gameObject.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}