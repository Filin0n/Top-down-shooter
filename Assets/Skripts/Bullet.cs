using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public float bulletSpeed;
    [HideInInspector] public int damage;
    [HideInInspector] public float timeToDestroy;

    [HideInInspector] public Transform shooter;

    private void Start()
    {
        StartCoroutine(DestroyBullet());
    }
    void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }

    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out Enemy enemy) && shooter.GetComponent<PlayerController>())
        {
            Debug.Log("Shot!!!");
            enemy.AplyDamage(damage);
            Destroy(gameObject);
        }
        
        if (collision.TryGetComponent(out PlayerController player) && shooter.GetComponent<Enemy>())
        {
            Debug.Log("Hit Player");
            Destroy(gameObject);
        }
       
    }

}

