using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class Reload : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public GameObject GunPos;
    public Text text;
    public ShootGun shootGun;

    GunController gunController;
    int selected;
    int maxBullet;

    public void OnPointerDown(PointerEventData eventData)
    {
        selected = GunPos.GetComponent<GunController>().selected;
        maxBullet = GunPos.GetComponent<GunController>().guns[selected].bulletCount;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StartCoroutine(gunController.ReloadBullet(GunPos.GetComponent<GunController>().guns[selected].reloadDelay));
    }
}
