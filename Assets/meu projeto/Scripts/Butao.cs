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
        botao.onClick.AddListener(Iniciodejogo);
    }

    private void Update()
    {
        
    }

    public void Iniciodejogo()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
