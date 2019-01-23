using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePool : MonoBehaviour
{
    public GameObject[] BulletPrefab;
    public Queue<GameObject>[] PoolList;    // 최초 사이즈 조절을 못하나?
    public Queue<GameObject> BulletPool;    // 현재 기준 4개 생성해서 PoolList에 집어넣어야 함

    public int[] BulletCount;

    void Start()                            //  시작과 동시에 생성해서 PoolLIst에 집어 넣어준다
    {
        PoolList = new Queue<GameObject>[4];
        PoolList[0] = new Queue<GameObject>(SetBullet(BulletPrefab[0], 10, "Ak-47"));
        PoolList[1] = new Queue<GameObject>(SetBullet(BulletPrefab[1], 8, "M4A1"));
        PoolList[2] = new Queue<GameObject>(SetBullet(BulletPrefab[2], 6, "Skorpion"));
        PoolList[3] = new Queue<GameObject>(SetBullet(BulletPrefab[3], 4, "UMP-45"));
    }

    Queue<GameObject> SetBullet(GameObject _Bullet, int _BulletCount, string _name)
    {
        BulletPool = new Queue<GameObject>();
        GameObject Magazine = new GameObject(_name);

        for (int i = 0; i < _BulletCount; i++)
        {
            GameObject Bullet = Instantiate(_Bullet) as GameObject;
            Bullet.SetActive(false);
            Bullet.transform.parent = Magazine.transform;
            BulletPool.Enqueue(Bullet);
        }
        return BulletPool;
    }
}
