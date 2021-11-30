using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BulletCreator))] 

public class HeadController : MonoBehaviour
{
    [SerializeField] private JoystickController _headJoystickController;

    private  Vector2 _moveVector;
    private BulletCreator bulletCreator;

    void Start()
    {
        bulletCreator = GetComponent<BulletCreator>();
    }

    void Update()
    {
        if (_headJoystickController.onPointerDown)
        {
            bulletCreator.LongShot();
        }
        Rotate();
    }

    private void Rotate()
    {
        _moveVector.x = _headJoystickController.Horizontal();
        _moveVector.y = _headJoystickController.Vertical();

        if (_moveVector.x != 0 || _moveVector.y != 0)
        {
            Vector2 direction = new Vector2(_moveVector.x, _moveVector.y);
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(angle-90, Vector3.down);
        }
    }
}
