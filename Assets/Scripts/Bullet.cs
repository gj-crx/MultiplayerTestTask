using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : NetworkBehaviour
{
    public float Damage { private get; set; } = 20;
    public float FlightSpeed { private get; set; } = 10;
    public Vector3 Direction { private get; set; } = Vector3.up;

    [SerializeField] private new Rigidbody2D rigidbody;

    private const float bulletLifeTime = 2.5f;

    private void Start() => StartCoroutine(LifetimeCoroutine());
    public override void FixedUpdateNetwork()
    {
        rigidbody.velocity = Direction * FlightSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent != null && collision.transform.parent.GetComponent<IDamageable>() != null) //check for a proper target
        {
            collision.transform.parent.GetComponent<IDamageable>().TakeDamage(Damage);
            Destroy(gameObject);
        }
    }
    private IEnumerator LifetimeCoroutine()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }
}
