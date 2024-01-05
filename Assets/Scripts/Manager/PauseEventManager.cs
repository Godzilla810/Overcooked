using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseEventManager : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject HelpPanel;
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void Help()
    {
        PausePanel.SetActive(false);
        HelpPanel.SetActive(true);
    }
    public void Back()
    {
        HelpPanel.SetActive(false);
        PausePanel.SetActive(true);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
