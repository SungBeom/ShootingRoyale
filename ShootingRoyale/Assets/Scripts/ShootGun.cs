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
        // GunPos.transform.FindChild(ChangeGun.selected).GetComponent<Animator>().SetTrigger("Shoot_t");
        selected = GunPos.GetComponent<ChangeGun>().selected;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // GunPos.transform.FindChild(ChangeGun.GetSelect()).GetComponent<Animator>().SetTrigger("Shoot_t");
        // 현재 첫 번째 총으로 실험 중, 들고 있는 총으로 바꿔주어야 함
        GunPos.transform.GetChild(selected).GetComponent<Animator>().SetTrigger("Shoot_t");
        StartCoroutine(ShootEffect());
    }

    IEnumerator ShootEffect()
    {
        // Transform bs = GunPos.transform.GetChild(selected).Find("Bullet Spawn").GetChild(0);
        ParticleSystem ps = GunPos.transform.GetChild(selected).Find("Bullet Spawn").GetChild(0).transform.GetComponent<ParticleSystem>();

        ps.Clear();
        ps.Play();
        yield return new WaitForSeconds(0.1f);
        ps.Stop();
    }
}
