using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Transform bulletTransform;

    [SerializeField] private Rigidbody bulletRigidbody;

    [SerializeField] private float explosionForce;
    [SerializeField] private float explosionRadius;
    [SerializeField] private float upwardsModifier;
    [SerializeField] private float lifeTime;

    private void Awake() => Invoke(nameof(Destruction), lifeTime);

    private void OnTriggerEnter(Collider other)
    {
        ExplosiveForce();
        Destruction();
    }

    private void ExplosiveForce()
    {
        Vector3 explosionPosition = bulletTransform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, explosionRadius);

        foreach (Collider hit in colliders)
        {
            if (hit.TryGetComponent(out Rigidbody _rigidbody))
            {
                if (_rigidbody != null)
                    _rigidbody.AddExplosionForce(explosionForce, explosionPosition, explosionRadius, upwardsModifier);
            }
        }
    }

    private void Destruction()
    {
        Destroy(gameObject);
    }
}