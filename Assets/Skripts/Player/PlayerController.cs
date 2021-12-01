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
            _direction = new Vector3(_moveVector.x, _moveVector.y, _moveVector.z);

            var angle = Mathf.Atan2(_direction.z, _direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(angle-90, Vector3.down);
        }
    }

    private bool IsObstacleAhead()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, _direction.normalized);

        Physics.SphereCast(ray, 0.5f, out hit,0.2f);

        //Physics.SphereCast(transform.position, 0.5f, _direction.normalized, out hit);
        //Physics.Raycast(transform.position, _direction.normalized, out hit);

        Debug.DrawRay(transform.position, _direction.normalized,Color.red);

        Wall wall = hit.transform?.GetComponent<Wall>();

        if (wall == null)
        {
            Debug.Log("Null Wall");
            return false;
        }
        else
        {
            Debug.Log("Wall");
            return true;
        }
    }
}
