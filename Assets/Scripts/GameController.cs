using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private bool isGame;
    public bool IsGame => isGame;

    [SerializeField]
    private GameObject losePanel;
    [SerializeField]
    private GameObject winPanel;
    [SerializeField]
    private GameObject startPanel;

    public static GameController Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            startPanel.SetActive(false);
            isGame = true;
        }
    }

    public void WinGame()
    {
        winPanel.SetActive(true);
        isGame = false;
    }

    public void LoseGame()
    {
        losePanel.SetActive(true);
        isGame = false;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
