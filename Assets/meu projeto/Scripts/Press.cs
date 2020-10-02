using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Press : MonoBehaviour
{
    public Vector2 interval;
    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }
   IEnumerator Start()
    {
        yield return new WaitForSeconds(Random.Range(interval.x, interval.y));

        animator.enabled = true;
    }

    
}
