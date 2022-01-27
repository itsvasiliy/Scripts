using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void Death()
    {
        print("Enemy died");
        Destroy(gameObject);
    }
}
