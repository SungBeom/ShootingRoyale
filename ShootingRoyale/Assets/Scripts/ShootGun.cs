using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShootGun : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public GameObject GunPos;
    public bool shootPossible = false;
    int selected;

    public void OnPointerDown(PointerEventData eventData)
    {
        selected = GunPos.GetComponent<GunController>().selected;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (shootPossible == true)
        {
            /*GunPos.transform.GetChild(selected).GetComponent<Animator>().SetTrigger("Shoot_t");
            GunPos.GetComponent<GunController>().Shoot(selected);
            StartCoroutine(ShootEffect());*/
            StartCoroutine(ShootDelay(GunPos.GetComponent<GunController>().guns[selected].shootDelay));
        }
        else { return; }
    }

    IEnumerator ShootDelay(float time)
    {
        //Debug.Log("진입");
        GunPos.transform.GetChild(selected).GetComponent<Animator>().SetTrigger("Shoot_t");
        GunPos.GetComponent<GunController>().Shoot(selected);
        StartCoroutine(ShootEffect());
        shootPossible = false;
        yield return new WaitForSeconds(time);
        shootPossible = true;
    }

    IEnumerator ShootEffect()
    {
        ParticleSystem ps = GunPos.transform.GetChild(selected).Find("Bullet Spawn").GetChild(0).GetComponent<ParticleSystem>();

        ps.Clear();
        ps.Play();
        yield return new WaitForSeconds(0.1f);
        ps.Stop();
    }
}
