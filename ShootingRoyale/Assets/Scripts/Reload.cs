using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class Reload : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public GameObject gunPos;
    public Text text;
    public ShootGun shootGun;

    GunController gunController;
    int selected;

    public void OnPointerDown(PointerEventData eventData)
    {
        gunController = gunPos.GetComponent<GunController>();
        selected = gunPos.GetComponent<GunController>().selected;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StartCoroutine(gunController.ReloadBullet(gunController.guns[selected].reloadDelay));
    }
}
