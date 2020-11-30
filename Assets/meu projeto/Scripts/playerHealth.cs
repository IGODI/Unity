using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHealth : Demageable
{

    private int defaulfLayer;


    new void Start()
    {
        base.Start();
        defaulfLayer = gameObject.layer;
    }
    private void Update()
    {
        UiManager.instance.UpdateHealthBarPlayerInBoss(currentHealth);
    }
    public override void Death()
    {

        if (LevelManager.instance.checkPoint)
        {
            Debug.Log("Checkpoint");
            LevelManager.instance.Restart();
            Respawn();
        }
        else
        {
          
            Invoke("ReloadScene", 0.1f);
        }


    }
    public void SetInvencible(bool state)
    {
        if (state)
        {
            gameObject.layer = defaulfLayer;
            
        }
        else
        {
            UiManager.instance.UpdateHealthBar(currentHealth);           
            gameObject.layer = 11; //camada de invencibilidade
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}


