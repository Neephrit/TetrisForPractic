using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Text textNameGame;
    [SerializeField] private Text textVersuonGame;

    [SerializeField] private GameObject RecordWindow;

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Records()
    {
        RecordWindow.SetActive(true); 
    }
    public void Exit()
    {
        Application.Quit();
        Debug.LogError("Quiting...");
    }

    public void CloseWindow()
    {
        RecordWindow?.SetActive(false);
    }
    private void FixedUpdate()
    {
        textNameGame.text = Application.productName;
        textVersuonGame.text = "v: " + Application.version;
    }
}
