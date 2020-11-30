using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public Vector2 speed;

    private void Start()
    {
        StartCoroutine("WaitForSec");
    }
    void Update()
    {
        transform.Translate(speed * Time.deltaTime);   
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
