using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image joystickBG;
    private Image joystick;
    private Vector2 inputVector;

    [HideInInspector]public bool onPointerDown;

    private void Start()
    {
        joystickBG = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
        onPointerDown = true;
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        // Возврат джостика в центр
        inputVector = Vector2.zero;
        joystick.rectTransform.anchoredPosition = Vector2.zero;
        onPointerDown = false;
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        onPointerDown = true;

        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBG.rectTransform,ped.position,ped.pressEventCamera,out pos))
        {
            // Получение координат позиции касания на джостик
            pos.x = (pos.x /joystickBG.rectTransform.sizeDelta.x);
            pos.y = (pos.y /joystickBG.rectTransform.sizeDelta.x);

            // Установка точных координат косания
            inputVector = new Vector2(pos.x *2,pos.y *2);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            joystick.rectTransform.anchoredPosition = new Vector2(inputVector.x * (joystickBG.rectTransform.sizeDelta.x/2), inputVector.y * (joystickBG.rectTransform.sizeDelta.y / 2));
        }
    }

    public float Horizontal()
    {
        if (inputVector.x != 0)
        {
            return inputVector.x;
        }
        else return Input.GetAxis("Horizontal");
    }

    public float Vertical()
    {
        if (inputVector.y != 0)
        {
            return inputVector.y;
        }
        else return Input.GetAxis("Vertical");
    }
}
