using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public void Death()
    {
        print("Player died");
        Destroy(gameObject);
    }
}
