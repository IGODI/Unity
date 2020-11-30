using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public bool isPaused;
    public GameObject PauseMenu;

    private void Update()
    {
        if (isPaused == true)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        if(isPaused == false)
        {       
            Time.timeScale = 1f;
            PauseMenu.SetActive(false);
        }
    }

    public void Pausar()
    {
        isPaused = !isPaused;       
    }
}
