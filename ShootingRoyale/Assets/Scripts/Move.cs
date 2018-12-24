using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Move : MonoBehaviour,IDragHandler,IPointerUpHandler,IPointerDownHandler {

    Vector3 FirstPos;   // 첫 번째 누른곳
    Vector3 MovePos;        // 이동 된 곳
    private Vector3 Vec;
    public GameObject Player;
    public float MoveSpeed = 5.0f;

    void Update()
    {
        if (Input.GetTouch(0).position.x < Screen.width / 2)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
                FirstPos = Input.GetTouch(0).position;
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                MovePos = Input.GetTouch(0).position;
                Vec = (MovePos - FirstPos).normalized;
                Player.transform.Translate(new Vector3(-Vec.y, 0, Vec.x) * Time.deltaTime * MoveSpeed);
            }
        }
        else
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
                FirstPos = Input.GetTouch(0).position;
            if(Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                MovePos = Input.GetTouch(0).position;
                Vec = (MovePos - FirstPos).normalized;
                Player.transform.Rotate(0,Vec.x,0);
            }
        }
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {

    }

    public virtual void OnPointerUp(PointerEventData ped)
    {

    }

    public virtual void OnDrag(PointerEventData ped)
    {

    }
}
