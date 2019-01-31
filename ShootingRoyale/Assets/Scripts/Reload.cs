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
    int selected;
    int maxBullet;
    public ShootGun shootGun ;

    public void OnPointerDown(PointerEventData eventData)
    {
        selected = GunPos.GetComponent<GunController>().selected;
        maxBullet = GunPos.GetComponent<GunController>().guns[selected].bulletCount;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StartCoroutine(ReloadBullet(GunPos.GetComponent<GunController>().guns[selected].reloadDelay));
    }

    IEnumerator ReloadBullet(float time)
    {
        shootGun.shootPossible = false;
        yield return new WaitForSeconds(time);
        GunPos.GetComponent<GunController>().currentBullet = maxBullet;
        text.text = maxBullet + "/" + maxBullet;
        shootGun.shootPossible = true;

    }
}
