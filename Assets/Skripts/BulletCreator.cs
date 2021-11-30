using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCreator : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private int _bulletDamage;
    [SerializeField] private int _timeToDestroyBullet;

    [SerializeField] [Header("Стрелок")] 
    private Transform _shooter;

    [SerializeField] [Header("Интервал между выстрелами")]
    private float _shootInterval;

    private bool _isShoting = true;

   

    public void Shot()
    {
        Bullet bullet;

        bullet = Instantiate(_bulletPrefab);
        bullet.shooter = _shooter;
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
        bullet.damage = _bulletDamage;
        bullet.bulletSpeed = _bulletSpeed;
        bullet.timeToDestroy = _timeToDestroyBullet;
    }

    public void LongShot()
    {        
        if(_isShoting) StartCoroutine(ContinuousShooting());
    
    }

    public IEnumerator ContinuousShooting()
    {
        Shot();
        _isShoting = false;
        yield return new WaitForSeconds(_shootInterval);
        _isShoting = true;
    }
}
