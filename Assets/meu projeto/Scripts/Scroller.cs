using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public Vector2 speed;

    
    void Update()
    {
        transform.Translate(speed * Time.deltaTime);   
    }
}
