using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private Transform enemyTransform;

        [SerializeField] private float moveSpeed;

        private Transform target;

        private void Start()
        {
            if (FindObjectOfType<Player>() != null)
                target = FindObjectOfType<Player>().GetComponent<Transform>();
        } 

        private void FixedUpdate()
        {
            if (target != null)
            {
                enemyTransform.LookAt(target);
                enemyTransform.position = Vector3.MoveTowards(enemyTransform.position, target.position, moveSpeed);
            }
        }
    }
}