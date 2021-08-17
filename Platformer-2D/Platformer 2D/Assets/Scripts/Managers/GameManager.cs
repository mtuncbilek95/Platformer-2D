using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Animator sceneLoader;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject[] enemies;

    [SerializeField] private List<GameObject> aliveEnemies;
    [SerializeField] private List<GameObject> deadEnemies;

    public static bool GameIsPaused = false;

    private Scene currentScene;
    private int nextIndex;

    [field: SerializeField]
    private UnityEvent OnAllEnemiesDead;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        nextIndex = currentScene.buildIndex + 1;

        enemies = GameObject.FindGameObjectsWithTag("Enemy Pig");

        for (int i = 0; i < enemies.Length; i++)
        {
            aliveEnemies.Add(enemies[i]);
        }


        LockMouse();
    }

    private void Update()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            EnemyBaseScript enemyScript = enemies[i].GetComponent<EnemyBaseScript>();
            if (enemyScript.EnemyisDead)
            {
                if (!deadEnemies.Contains(enemies[i]))
                {
                    aliveEnemies.Remove(enemies[i]);
                    deadEnemies.Add(enemies[i]);
                }
            }
        }
        
        if(CompareLists(deadEnemies, enemies))
        {
            OnAllEnemiesDead?.Invoke();
            PlayerScript playerScript = player.GetComponent<PlayerScript>();

            if (!player.activeSelf && playerScript.enterTheDoor)
            {
                StartCoroutine(DelayNextScene());
            }
        }
        
    }

    public static bool CompareLists<T>(IEnumerable<T> list1, IEnumerable<T> list2)
    {
        var count = new Dictionary<T, int>();
        foreach (T s in list1)
        {
            if (count.ContainsKey(s))
            {
                count[s]++;
            }
            else
            {
                count.Add(s, 1);
            }
        }
        foreach (T s in list2)
        {
            if (count.ContainsKey(s))
            {
                count[s]--;
            }
            else
            {
                return false;
            }
        }
        return count.Values.All(c => c == 0);
    }

    public void OnPauseButton(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (GameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    #region Game Actions
    private void PauseGame()
    {
        SoundManagerScript.PlayLoop("menuSong");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
        UnlockMouse();
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
        StartCoroutine(DelayRestartGame());
        LockMouse();
    }

    public void ResumeGame()
    {
        SoundManagerScript.PlayLoop("gameSong1");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
        LockMouse();
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
        StartCoroutine(DelayMainMenu());
        UnlockMouse();
    }

    public void DeadRestartGame()
    {
        SoundManagerScript.PlaySound("dead");
        StartCoroutine(DelayRestartGame());
    }
    #endregion

    #region Mouse Actions
    private void LockMouse()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void UnlockMouse()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    #endregion

    #region Enumerators
    IEnumerator DelayMainMenu()
    {
        sceneLoader.SetTrigger("LoadScene");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Main Menu");
    }

    IEnumerator DelayNextScene()
    {
        sceneLoader.SetTrigger("LoadScene");
        yield return new WaitForSeconds(1f);
        

        if (currentScene.buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene("Main Menu");
        }
        
    }
    IEnumerator DelayRestartGame()
    {
        yield return new WaitForSeconds(0.2f);
        sceneLoader.SetTrigger("LoadScene");
        yield return new WaitForSeconds(1f);
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    #endregion
}