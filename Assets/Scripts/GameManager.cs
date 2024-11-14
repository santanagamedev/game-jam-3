using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI jumpCounterText;
    public TextMeshProUGUI gameOverText;
    public int jumpsCounter;
    int playerJumpsCounter;
    public GameObject panelGameOver;
    public GameObject panelTutorial;
    void Start()
    {
        playerJumpsCounter = GameObject.Find("Player").GetComponent<PlayerController>().remainingJumps; 
        
        jumpCounterText.text = "Saltos Disponibles: " + playerJumpsCounter;   

        panelGameOver.SetActive(false);
    }
    
    public void UpdateJumps(int playerJumpsCounter)
    {
        jumpsCounter = playerJumpsCounter;
        jumpCounterText.text = "Saltos Disponibles: " + playerJumpsCounter;
    }    

    public void ChangetoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public IEnumerator RestarLevel(string tag)
    {
        panelGameOver.SetActive(true);
        if (tag == "Obstacle")
            gameOverText.text = "EVITA LOS OBSTACULSO PUNTUDOS.";
        else 
            gameOverText.text = "TE HAS QUEDADO SIN SALTOS DISPONIBLES.";

        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void DisablePanelTutorial()
    {
        panelTutorial.SetActive(false);
    }
}