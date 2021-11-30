using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _hp;
    [SerializeField] private int _damage;

    public float agroRadius;
    public EnemyHead enemyHead;

    [HideInInspector] public Transform player;
    [HideInInspector] public float distanceToPlayer = Mathf.Infinity;
    public void AplyDamage(int damage)
    {
        _hp -= damage;
        if (_hp <= 0)
        {
            _hp = 0;
            Dead();
        }
    }

    private void Dead()
    {
        Destroy(gameObject);
    }

    public void Attack()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (agroRadius < distanceToPlayer)
        {
            enemyHead.enabled = false;
        }
        else
        {
            enemyHead.enabled = true;
        }
    }

}
