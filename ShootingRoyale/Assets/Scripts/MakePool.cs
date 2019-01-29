using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePool : MonoBehaviour
{
    public GameObject[] bulletPrefab;
    public Queue<GameObject>[] poolList;
    public Queue<GameObject> bulletPool;

    public int[] bulletCount;

    void Start()
    {
        poolList = new Queue<GameObject>[4];

        poolList[0] = new Queue<GameObject>(SetBullet(bulletPrefab[0], bulletCount[0], "Ak-47"));
        poolList[1] = new Queue<GameObject>(SetBullet(bulletPrefab[1], bulletCount[1], "M4A1"));
        poolList[2] = new Queue<GameObject>(SetBullet(bulletPrefab[2], bulletCount[2], "Skorpion"));
        poolList[3] = new Queue<GameObject>(SetBullet(bulletPrefab[3], bulletCount[3], "UMP-45"));
    }

    Queue<GameObject> SetBullet(GameObject _Bullet, int _BulletCount, string _name)
    {
        bulletPool = new Queue<GameObject>();
        GameObject Magazine = new GameObject(_name);

        for (int i = 0; i < _BulletCount; i++)
        {
            GameObject Bullet = Instantiate(_Bullet) as GameObject;
            Bullet.SetActive(false);
            Bullet.transform.parent = Magazine.transform;
            bulletPool.Enqueue(Bullet);
        }

        return bulletPool;
    }
}
