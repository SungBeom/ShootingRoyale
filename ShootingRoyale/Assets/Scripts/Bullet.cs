using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public int damage;
    // 전부 pool에서 빼고 넣는 코드로 변경해야 함
    void OnTriggerEnter(Collider col)
    {
        var hit = col.gameObject;

        // 내 캐릭터면 쏘자마자 없어짐, 여기선 적 캐릭터를 의미함
        // 네트워크 코드로 조절해야 할 듯함
        if (hit.tag.Equals("Player"))
        {
            hit.transform.Find("Canvas").Find("Health Slider").GetComponent<Slider>().value -= damage;
            gameObject.SetActive(false);
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
