using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    [SerializeField] private JoystickController _mobileController;
    [SerializeField] private float _minDistanceToObstacle;

    private Vector3 _moveVector;
    private Vector3 _direction;

    private void Update()
    {
        _moveVector.x = _mobileController.Horizontal();
        _moveVector.z = _mobileController.Vertical();

        if (IsObstacleAhead() == false) {
            PlayerMove();
        }
        Rotate();
    }

    private void PlayerMove()
    {
        transform.Translate(_moveVector * _speedMove * Time.deltaTime,Space.World);
    }
    private void Rotate()
    {
        if (_moveVector.x != 0 || _moveVector.z != 0)
        {
            _direction = new Vector2(_moveVector.x, _moveVector.z);

            var angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(angle-90, Vector3.down);
        }
    }

    private bool IsObstacleAhead()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, _direction.normalized);

        Physics.SphereCast(ray, 0.5f, out hit);
        Wall wall = hit.transform?.GetComponent<Wall>();

        if (wall == null)
        { 
            return false;
        }
        else
        {
            return true;
        }
    }
}
