using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI statField;

    public GameObject endPanel;
    public GameObject gamePanel;

    public static GameManager instance;
    public static GameManager Instance 
    {
        get
        {
            if (instance == null) Debug.LogWarning("GameManager is a empty");
            return instance;
        }
    }
    private void Start() {
        instance = this;
        EventsController.Instance.LoadTime(System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy   HH:mm"));
        gamePanel.SetActive(true);
        endPanel.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void RestartGame() 
    {
        SceneManager.LoadScene(0);
    }
    public void EndGame() 
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;
        gamePanel.SetActive(false);
        endPanel.SetActive(true);
        EventsController.Instance.LoadTime(System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy   HH:mm"));
        GetComponent<SaveManager>().Save();
        title.text = EventsController.Instance.finalText;
        LoadStat(EventsController.Instance);
    }
    void LoadStat(EventsController stat) 
    {
        string lineStart = "Start a game in " + stat.startGame;
        string lineFinished = "End in " + stat.endGame;
        string line1 = stat.attackEvents.getNameCategory();
        string count1 = stat.attackEvents.getCount().ToString();
        string line2 = stat.missEvents.getNameCategory();
        string count2 = stat.missEvents.getCount().ToString();
        string line3 = stat.killEvents.getNameCategory();
        string count3 = stat.killEvents.getCount().ToString();
        string FinalText  = lineStart + "\n" + lineFinished + "\n" +
                            line1 + ": " + count1 + "\n" +
                            line2 + ": " + count2 + "\n" +
                            line3 + ": " + count3 + "\n";
        statField.text = FinalText;
    }
}
