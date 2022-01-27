using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Shooting
{
    public class ShootingSystem : MonoBehaviour
    {
        [SerializeField] private Transform bodyTransform;
        [SerializeField] private Transform bulletStartTransform;

        [SerializeField] private Rigidbody bullet;

        [SerializeField] private float bulletSpeed;
        [SerializeField] private float fireRate;

        private bool isButtonPreesed;

        public void Shoot(bool press)
        {
            isButtonPreesed = press;
            StartCoroutine(Shooting());
        }

        public IEnumerator Shooting()
        {
            while (isButtonPreesed)
            {
                Rigidbody bulletClone;
                bulletClone = (Rigidbody)Instantiate(bullet, bulletStartTransform.position, bodyTransform.rotation);
                bulletClone.velocity = bodyTransform.forward * bulletSpeed;

                yield return new WaitForSeconds(fireRate);
            }
        }
    }
}