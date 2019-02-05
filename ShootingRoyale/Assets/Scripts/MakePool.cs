using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePool : MonoBehaviour
{
    public GameObject[] bulletPrefab;
    public GameObject gunPos;

    public Queue<GameObject>[] poolList;
    public Queue<GameObject> bulletPool;

    public int[] bulletCount;

    //public string[] gunName;


    void Start()
    {
        /*poolList = new Queue<GameObject>[gunPos.GetComponent<GunController>().guns.Length];
        gunName = new string[gunPos.GetComponent<GunController>().guns.Length];*/

        /*Debug.Log(poolList.Length);
        poolList = new Queue<GameObject>[poolList.Length];
        gunName = new string[poolList.Length];*/

        /*for (int i = 0; i < poolList.Length; i++)
        {
            poolList[i] = new Queue<GameObject>(SetBullet(bulletPrefab[i], bulletCount[i], gunPos.GetComponent<GunController>().guns[i].bulletDamage, gunName[i]));
        }*/
        poolList = new Queue<GameObject>[4];

        poolList[0] = new Queue<GameObject>(SetBullet(bulletPrefab[0], bulletCount[0], gunPos.GetComponent<GunController>().guns[0].bulletDamage, "Ak-47"));
        poolList[1] = new Queue<GameObject>(SetBullet(bulletPrefab[1], bulletCount[1], gunPos.GetComponent<GunController>().guns[1].bulletDamage, "M4A1"));
        poolList[2] = new Queue<GameObject>(SetBullet(bulletPrefab[2], bulletCount[2], gunPos.GetComponent<GunController>().guns[2].bulletDamage, "Skorpion"));
        poolList[3] = new Queue<GameObject>(SetBullet(bulletPrefab[3], bulletCount[3], gunPos.GetComponent<GunController>().guns[3].bulletDamage, "UMP-45"));
    }

    Queue<GameObject> SetBullet(GameObject _Bullet, int _BulletCount, int _BulletDamage, string _name)
    {
        bulletPool = new Queue<GameObject>();
        GameObject Magazine = new GameObject(_name);

        for (int i = 0; i < _BulletCount; i++)
        {
            _Bullet.GetComponent<Bullet>().damage = _BulletDamage;
            GameObject Bullet = Instantiate(_Bullet) as GameObject;
            Bullet.SetActive(false);
            Bullet.transform.parent = Magazine.transform;
            bulletPool.Enqueue(Bullet);
        }

        return bulletPool;
    }
}
