using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    // 전부 pool에서 빼고 넣는 코드로 변경해야 함
    void OnTriggerEnter(Collider col)
    {
        var hit = col.gameObject;

        // 내 캐릭터면 쏘자마자 없어짐, 여기선 적 캐릭터를 의미함
        // 네트워크 코드로 조절해야 할 듯함
        if (hit.tag.Equals("Player"))
        {
            hit.transform.Find("Canvas").Find("Health Slider").GetComponent<Slider>().value -= 10;  // 건 컨트룰러의 총알 데미지에 접근해야하는데 접근 할 수가 없음 -> 총알마다 다른 프리팹일 경우 프리팹안에 값을 미리 넣어둘수 있을듯
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
        else
        {
            Debug.Log("기타 명중");
        }
    }
}
