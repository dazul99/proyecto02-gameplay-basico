using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject mainmenu;
    [SerializeField] private GameObject gameover;

    [SerializeField] private Button resume;
    [SerializeField] private Button restart;

    [SerializeField] private Button normal;
    [SerializeField] private Button hell;

    [SerializeField] private TextMeshProUGUI score;

    [SerializeField] private TextMeshProUGUI scoreover;
    [SerializeField] private Button restartover;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        resume.onClick.AddListener(() => { gameManager.Resume(); });
        restart.onClick.AddListener(() => { gameManager.Restart(); });
        normal.onClick.AddListener(() => { gameManager.StartGame(); });
        hell.onClick.AddListener(() => { gameManager.Hell(); });
        restartover.onClick.AddListener(() => { gameManager.Restart(); });
    }

    public void Hidepanels()
    {
        pause.SetActive(false);
        gameover.SetActive(false);
        mainmenu.SetActive(true);
        score.text = "";
    }

    public void Hidemenu()
    {
        mainmenu.SetActive(false);
        score.text = "Animals Fed:\n 0";
    }

    public void Unpause()
    {
        pause.SetActive(false);
    }

    public void Pause() 
    {
        pause.SetActive(true);
    }

    public void UpdateScore(int x)
    {
        score.text = "Animals Fed:\n" + x;
    }

    public void Gameover(int x)
    {
        scoreover.text = "You Fed " + x + " Animals";
        gameover.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
