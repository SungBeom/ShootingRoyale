using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShootGun : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public GameObject GunPos;

    public void OnPointerDown(PointerEventData eventData)
    {
        // GunPos.transform.FindChild(ChangeGun.selected).GetComponent<Animator>().SetTrigger("Shoot_t");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // GunPos.transform.FindChild(ChangeGun.GetSelect()).GetComponent<Animator>().SetTrigger("Shoot_t");
        GunPos.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Shoot_t");

    }
}
