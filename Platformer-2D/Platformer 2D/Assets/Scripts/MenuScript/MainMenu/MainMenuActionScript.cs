using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuActionScript : MonoBehaviour
{
    [SerializeField] private Animator sceneLoader;
    [SerializeField] private GameObject howToPlayPanel;
    public Animator PanelAnimator { get; private set; }

    public void Start()
    {
        PanelAnimator = howToPlayPanel.GetComponent<Animator>();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    #region Event Functions
    public void StartGame()
    {
        StartCoroutine(DelayedActionStartGame());
    }
    public void ExitGame()
    {
        StartCoroutine(DelayActionExit());
    }
    public void OpenHTPPanel()
    {
        StartCoroutine(DelayedActionOpenPanel());
    }
    public void CloseHTPPanel()
    {
        StartCoroutine(DelayedActionClosePanel());
    }
    #endregion

    #region Delay Actions
    IEnumerator DelayedActionStartGame()
    {
        sceneLoader.SetTrigger("LoadScene");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Level 1");
    }
    IEnumerator DelayActionExit()
    {
        sceneLoader.SetTrigger("LoadScene");
        yield return new WaitForSeconds(1f);
        Application.Quit();
    }

    IEnumerator DelayedActionOpenPanel()
    {
        yield return new WaitForSeconds(0.5f);
        howToPlayPanel.SetActive(true);
    }
    IEnumerator DelayedActionClosePanel()
    {
        yield return new WaitForSeconds(0.5f);
        PanelAnimator.SetTrigger("ClosePanel");
        yield return new WaitForSeconds(0.2f);
        howToPlayPanel.SetActive(false);
    }
    #endregion
}
