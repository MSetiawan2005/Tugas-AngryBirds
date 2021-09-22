using System;
using System.Collections;
using UnityEngine;

public class BirdOwl : Bird
{
    public float blastRadius = 10f;
    public float blastForce = 10f;

    private CircleCollider2D _blastCollider;
    public GameObject explosionEffect;

    public override void OnTap()
    {
        StartCoroutine(Explode());
        Instantiate(explosionEffect, transform.position, transform.rotation);
    }

    public IEnumerator Explode()
    {
        _blastCollider = gameObject.AddComponent<CircleCollider2D>();
        _blastCollider.radius = blastRadius;
        _blastCollider.isTrigger = true;
        _blastCollider.enabled = true;

        yield return new WaitForSeconds(0.05f);
        Destroy(gameObject);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Enemy" && other.gameObject.tag != "Obstacle") return;

        Vector2 direction = other.gameObject.transform.position - transform.position;
        other.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * blastForce, ForceMode2D.Impulse);

    }

    private void OnDrawGizmos()
    {
        if (_blastCollider != null)
        {
            Gizmos.DrawWireSphere(transform.position, _blastCollider.radius);
        }
    }
}
