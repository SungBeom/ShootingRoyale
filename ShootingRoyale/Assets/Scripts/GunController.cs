using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    //public GameObject[] guns;
    public Gun[] guns;

    // 테스트용 bullet, GunManager의 pool에서 가져오는 것으로 변경할 것
    //public GameObject bulletPrefab;

    MakePool makePool;

    [Range(0, 3)]               // 4 대신 (guns.Length - 1)을 넣는 것이 합당함
    public int selected;
    int temp;

    public void Change()
    {
        //guns[temp].SetActive(false);
        //guns[selected].SetActive(true);
        guns[temp].gunPrefab.SetActive(false);
        guns[selected].gunPrefab.SetActive(true);
        temp = selected;
    }

    public void Select(int num)
    {
        selected = num;
        Change();
    }

    // 총을 쏘는 함수- void(int)
    public void Shoot(int num)
    {
        // 아래의 코드는 현재 테스트 코드, pool을 사용하는 코드로 변경할 것
        // num은 어떤 총의 총알을 쏘느냐에 대한 정보
        //GameObject bullet = Instantiate(bulletPrefab, Camera.main.transform.position, Camera.main.transform.rotation);
        //bulletPrefab.transform.position = Camera.main.transform.position;
        //bulletPrefab.transform.rotation = Camera.main.transform.rotation;
        makePool = GameObject.Find("PoolManager").GetComponent<MakePool>();
        GameObject bullet = makePool.PoolList[num].Dequeue();
        bullet.transform.position = Camera.main.transform.position;
        bullet.transform.rotation = Camera.main.transform.rotation;
        bullet.SetActive(true);
        bullet.GetComponent<Renderer>().enabled = false;
        bullet.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 1000f);
        StartCoroutine(AppearBullet(bullet));
        bullet.GetComponent<Rigidbody>().velocity = Vector3.zero;
        makePool.PoolList[num].Enqueue(bullet);
        // Invoke("AppearBullet", 0.1f);
    }

    IEnumerator AppearBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(0.1f);
        bullet.GetComponent<Renderer>().enabled = true;
    }

    //void AppearBullet(GameObject bullet)
    //{
    //    bullet.SetActive(true);
    //    yield return new WaitForSeconds(0.1f);
    //}

    [System.Serializable]
    public class Gun
    {
        public GameObject gunPrefab;
        public Transform BulletPrefab;

        public float BulletSpped;
        public int BulletCount;
        public int BulletDamage;
    }
}
