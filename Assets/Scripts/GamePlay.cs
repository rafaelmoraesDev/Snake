using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlay : MonoBehaviour
{
    public GameObject PanelGameOver;

    private void Start()
    {
        Time.timeScale = 1;
    }
    public void GameOver()
    {
        ShowGameOverPanel();
        Time.timeScale = 0;
    }
    public void ShowGameOverPanel()
    {
        this.PanelGameOver.SetActive(true);
    }
    public void Replay()
    {
        SceneManager.LoadScene("Main");
    }
}
