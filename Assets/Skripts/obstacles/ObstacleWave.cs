using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleWave : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float SpeedIncrease;
    void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime );
        _speed += SpeedIncrease * Time.deltaTime;
    }
}
