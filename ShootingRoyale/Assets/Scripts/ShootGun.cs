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

    void Start()
    {
        gunController = gunPos.GetComponent<GunController>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        selected = gunController.selected;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (shootPossible == true)
        {
            if (gunController.currentBullet == 0) return;
            else StartCoroutine(Shoot(gunController.guns[selected].shootDelay));
        }
    }

    public IEnumerator Shoot(float delayTime)
    {
        shootPossible = false;
        gunPos.transform.GetChild(selected).GetComponent<Animator>().SetTrigger("Shoot_t");
        gunController.Shoot(selected);
        StartCoroutine(ShootEffect());
        StartCoroutine(ShootSound());

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

    IEnumerator ShootSound()
    {
        AudioSource source = gunPos.transform.GetChild(selected).Find("Bullet Spawn").GetChild(1).GetComponent<AudioSource>();

        source.Play();

        yield return new WaitForSeconds(0.5f);
        source.Stop();
    }
}
