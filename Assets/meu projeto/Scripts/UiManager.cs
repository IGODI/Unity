using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UiManager : MonoBehaviour
{

    public Image healthBar;

    public static UiManager instance;

    private void Awake()
    {
        instance = this;
    }
    public void UpdateHealthBar(float health)
    {
        healthBar.fillAmount = health / 10;
    }
}
