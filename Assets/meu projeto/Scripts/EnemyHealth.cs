using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : Demageable
{
    public override void Death()
    {
        Destroy(gameObject);
    }

    public void Win()
    {
        SceneManager.LoadScene("Win");
    }
    public void UpdatedeVida()
    {     
        UiManager.instance.UpdateHealthBarBoss(currentHealth);
    }
}
