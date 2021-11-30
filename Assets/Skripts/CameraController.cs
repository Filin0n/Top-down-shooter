using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField][Header("Скольжение")]
    private float _dumping;
    [SerializeField][Header("Смещение относительно персонажа")]
    private Vector2 _offset = new Vector2();

    [SerializeField] private JoystickController _moveJoystick;
    [SerializeField] private JoystickController _gunJoystick;
    [SerializeField] private Transform _player;

    private void Update()
    {
        if(_moveJoystick.Horizontal() ==0 && _moveJoystick.Vertical() == 0  ){
           CameraMove(_gunJoystick);
        }
        else CameraMove(_moveJoystick);
    }
    private void CameraMove(JoystickController joystick)
    {
        Vector2 cameraAdvance = new Vector2(joystick.Horizontal() * _offset.x,joystick.Vertical() * _offset.y);

        Vector3 targetCameraPosition = new Vector3(_player.position.x + cameraAdvance.x,0,_player.position.z + cameraAdvance.y);

        Vector3 currentPosition = Vector3.Lerp(transform.position, targetCameraPosition, _dumping * Time.deltaTime);

        transform.position = new Vector3(currentPosition.x,transform.position.y , currentPosition.z);
    }

}
