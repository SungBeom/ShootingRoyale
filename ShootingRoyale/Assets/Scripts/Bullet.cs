using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public int damage;

    void OnTriggerEnter(Collider col)
    {
        var hit = col.gameObject;

        // 내 캐릭터면 쏘자마자 없어짐, 여기선 적 캐릭터를 의미함
        // 네트워크 코드로 조절해야 할 듯함
        if (hit.tag.Equals("Player"))
        {
            //hit.transform.Find("Player").Find("Canvas").Find("Health Slider").GetComponent<Slider>().value -= damage;
            hit.transform.Find("Player").Find("Canvas").Find("Health Slider").GetComponent<Hp>().GainDamage(damage);
            //gameObject.SetActive(false);
        }
        else if (hit.tag.Equals("GunBox"))
        {
            Debug.Log("GunBox Hit!");
            gameObject.SetActive(false);
        }
        else if (hit.tag.Equals("ExpendableBox"))
        {
            Debug.Log("ExpendableBox Hit!");
            gameObject.SetActive(false);
        }
        else if(hit.tag.Equals("Untagged"))
        {
            Debug.Log("기타 명중");
        }
    }
}
