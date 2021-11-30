using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRail : Enemy
{
    [SerializeField] private bool _wayIsLoop;
    [SerializeField] private float _minDistanceToPoint;
    [SerializeField] private Transform[] _targetPoints;

    private NavMeshAgent _navMeshAgent;
    private int _numberOfPoint = 0;
    private bool _iSgoingBack = false;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
       enemyHead.player = player;
       _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        ChangeActivePoint();
        _navMeshAgent.SetDestination(_targetPoints[_numberOfPoint].position);
        Attack();
    }

    private void ChangeActivePoint()
    {
        float currentPointDistsnce = Vector3.Distance(transform.position, _targetPoints[_numberOfPoint].position);

        if (currentPointDistsnce < _minDistanceToPoint)
        {
            if (_wayIsLoop)
            {
                _numberOfPoint += 1;

                if (_numberOfPoint >= _targetPoints.Length)
                {
                    _numberOfPoint = 0;
                }
            }
            else
            {
                if (_numberOfPoint+1 >= _targetPoints.Length)
                {
                    _iSgoingBack = true;
                }
                else if (_numberOfPoint-1 < 0)
                {
                    _iSgoingBack = false;
                }
              
                if (_iSgoingBack)
                {
                    _numberOfPoint -= 1;
                }
                else
                {
                    _numberOfPoint += 1;
                }
            }
        }
    }


}
