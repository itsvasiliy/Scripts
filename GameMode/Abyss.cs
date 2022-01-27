using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abyss : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Enemy>(out Enemy _enemy))
        {
            _enemy.Death();
        }

        if(other.TryGetComponent<Player>(out Player _player))
        {
            _player.Death();
        }
    }
}