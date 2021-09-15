using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuActionScript : MonoBehaviour
{
    [SerializeField] private Animator sceneLoader;
    public Animator PanelAnimator { get; private set; }

    public void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    #region Event Functions
    public void StartGame()
    {

    }
    public void OptionsMenu()
    {

    }
    public void ExitGame()
    {

    }

    #endregion
}
