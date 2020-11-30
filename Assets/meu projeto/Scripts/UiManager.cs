using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UiManager : MonoBehaviour
{
    public Image healthBar;
    public Image healthBarPlayerInBoss;
    public Image healthBarBoss;

    public static UiManager instance;

    private void Awake()
    {
        instance = this;
    }
    public void UpdateHealthBar(float health)
    {
        healthBar.fillAmount = health / 10;
    }
    public void UpdateHealthBarPlayerInBoss(float health)
    {
        healthBarPlayerInBoss.fillAmount = health / 45;
    }


    public void UpdateHealthBarBoss(float health)
    {
        healthBarBoss.fillAmount = health/50;
    }
}
