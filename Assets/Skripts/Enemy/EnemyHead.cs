using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BulletCreator))]
public class EnemyHead : MonoBehaviour
{
    [HideInInspector] public Transform player;

    private BulletCreator _bulletCreator;

    private void Start()
    {
        _bulletCreator = GetComponent<BulletCreator>();
    }

    private void Update()
    {
        transform.LookAt(player);
        _bulletCreator.LongShot();
    }
}
