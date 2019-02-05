using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShootGun : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public GameObject gunPos;
    GunController gunController;
    public bool shootPossible;
    int selected;

    public void OnPointerDown(PointerEventData eventData)
    {
        selected = gunPos.GetComponent<GunController>().selected;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (shootPossible == true)
        {
            StartCoroutine(Shoot(gunPos.GetComponent<GunController>().guns[selected].shootDelay));
        }
    }

    public IEnumerator Shoot(float delayTime)
    {
        shootPossible = false;
        gunPos.transform.GetChild(selected).GetComponent<Animator>().SetTrigger("Shoot_t");
        gunPos.GetComponent<GunController>().Shoot(selected);
        StartCoroutine(ShootEffect());

        yield return new WaitForSeconds(delayTime);
        shootPossible = true;
    }

    IEnumerator ShootEffect()
    {
        ParticleSystem ps = gunPos.transform.GetChild(selected).Find("Bullet Spawn").GetChild(0).GetComponent<ParticleSystem>();

        ps.Clear();
        ps.Play();

        yield return new WaitForSeconds(0.1f);
        ps.Stop();
    }
}
