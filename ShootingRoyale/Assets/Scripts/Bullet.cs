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
            StartCoroutine(BulletInvisible(gameObject, 0.1f));
        }
        else if (hit.tag.Equals("GunBox"))
        {
            Debug.Log("GunBox Hit!");
            StartCoroutine(BulletInvisible(gameObject, 0.1f));
        }
        else if (hit.tag.Equals("ExpendableBox"))
        {
            Debug.Log("ExpendableBox Hit!");
            StartCoroutine(BulletInvisible(gameObject, 0.1f));
        }
        else if (hit.tag.Equals("Untagged"))
        {
            Debug.Log("기타 명중");
            StartCoroutine(BulletInvisible(gameObject, 0.1f));
        }
        else
        {
            StartCoroutine(BulletInvisible(gameObject, 2.0f));
        }
    }

    IEnumerator BulletInvisible(GameObject _obj, float _time)
    {
        yield return new WaitForSeconds(_time);
        _obj.SetActive(false);
    }
}
