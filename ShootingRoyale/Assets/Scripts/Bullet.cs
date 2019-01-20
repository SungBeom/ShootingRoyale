using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 전부 pool에서 빼고 넣는 코드로 변경해야 함
    void OnTriggerEnter(Collider col)
    {
        var hit = col.gameObject;

        // 내 캐릭터면 쏘자마자 없어짐, 여기선 적 캐릭터를 의미함
        // 네트워크 코드로 조절해야 할 듯함
        if (hit.tag.Equals("Character"))
        {
            Debug.Log("Character Hit!");
            Destroy(gameObject);
        }
        else if (hit.tag.Equals("GunBox"))
        {
            Debug.Log("GunBox Hit!");
            Destroy(gameObject);
        }
        else if(hit.tag.Equals("ExpendableBox"))
        {
            Debug.Log("ExpendableBox Hit!");
            Destroy(gameObject);
        }

        Destroy(gameObject, 2.0f);
    }
}
