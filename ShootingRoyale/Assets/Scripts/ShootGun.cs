using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShootGun : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public GameObject GunPos;
    int selected;

    public void OnPointerDown(PointerEventData eventData)
    {
        selected = GunPos.GetComponent<GunController>().selected;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GunPos.transform.GetChild(selected).GetComponent<Animator>().SetTrigger("Shoot_t");
        GunPos.GetComponent<GunController>().Shoot(selected);
        StartCoroutine(ShootEffect());
    }

    IEnumerator ShootEffect()
    {
        ParticleSystem ps = GunPos.transform.GetChild(selected).Find("Bullet Spawn").GetChild(0).transform.GetComponent<ParticleSystem>();

        ps.Clear();
        ps.Play();
        yield return new WaitForSeconds(0.1f);
        ps.Stop();
    }
}
