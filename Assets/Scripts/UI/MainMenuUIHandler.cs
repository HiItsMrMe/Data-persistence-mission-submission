using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuUIHandler : MonoBehaviour
{
    [SerializeField]
    private InputField nameInput;
    [SerializeField]
    private Text highscoreText;
    [SerializeField]
    private GameObject resetMenu;

    public void Awake()
    {
        if (GameManager.Instance != null)
        {
            nameInput.text = GameManager.Instance.playerName;
            DisplayHighscore();
        }
    }

    private void DisplayHighscore()
    {
        if (GameManager.Instance.highscorePoints != 0)
        {
            highscoreText.text = GameManager.Instance.highscorePlayer + " with " + GameManager.Instance.highscorePoints + " points";
        }
        else
        {
            highscoreText.text = "none";
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void NameChanged()
    {
        GameManager.Instance.playerName = nameInput.text;
    }

    public void OpenResetMenu()
    {
        resetMenu.SetActive(true);
    }
    public void ResetHighscore()
    {
        GameManager.Instance.highscorePoints = 0;
        DisplayHighscore();
        CloseResetMenu();
    }

    public void CloseResetMenu()
    {
        resetMenu.SetActive(false);
    }

}
