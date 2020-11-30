using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Butao : MonoBehaviour
{
    public void Gameplay()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Iniciodejogo()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
