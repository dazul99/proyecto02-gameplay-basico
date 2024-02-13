using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    private UIManager uimanager;
    private SpawnManager spawnmanager;
    private Player_control playercontrol;

    private bool paused = false;
    private int score = 0;

    private int lives = 2;

    // Start is called before the first frame update
    void Start()
    {
        uimanager = FindObjectOfType<UIManager>();
        spawnmanager = FindObjectOfType<SpawnManager>();
        playercontrol = FindObjectOfType<Player_control>();
        uimanager.Hidepanels();
        uimanager.UpdateScore(score);
    }

    public void Resume()
    {
        uimanager.Unpause();
        Time.timeScale = 1f;
        paused = !paused;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        uimanager.Hidemenu();
        spawnmanager.Spawn(1.5f);
        playercontrol.GameStart(1);
    }

    public void Hell()
    {
        uimanager.Hidemenu();
        spawnmanager.Spawn(0.25f);
        playercontrol.GameStart(3);
    }

    public void Pause()
    {
        uimanager.Pause();
        Time.timeScale = 0f;
        paused = !paused;
    }

    public void AnimalFed()
    {
        score++;
        uimanager.UpdateScore(score);
    }

    public void Gameover()
    {
        if(lives <= 0)
        {
            uimanager.Gameover(score);
            Time.timeScale = 0f;
        }
        else
        {
            lives--;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused) Pause();
            else Resume();
        }
    }
}
