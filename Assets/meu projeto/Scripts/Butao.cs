using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Butao : MonoBehaviour
{

    Button botao;
    
    void Start()
    {
        botao = GameObject.Find("Play").GetComponent<Button>();
    }

    private void Update()
    {
        botao.onClick.AddListener(Iniciodejogo);
    }

    public void Iniciodejogo()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
