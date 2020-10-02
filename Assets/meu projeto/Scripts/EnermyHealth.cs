using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Demageable
{
    public override void Death()
    {
        Destroy(gameObject);
    }
}
