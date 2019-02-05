using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    //public GameObject[] guns;
    public Gun[] guns;

    // 테스트용 bullet, GunManager의 pool에서 가져오는 것으로 변경할 것
    //public GameObject bulletPrefab;

    public MakePool makePool;  // poolManager 넣는 장소
    public ShootGun shootGun;

    [Range(0, 3)]               // 4 대신 (guns.Length - 1)을 넣는 것이 합당함
    public int selected;
    public int currentBullet;
    public string maxBullet;
    public Text text;
    int temp;

    public void Change()
    {
        //guns[temp].SetActive(false);
        //guns[selected].SetActive(true);
        guns[temp].gunPrefab.SetActive(false);
        guns[selected].gunPrefab.SetActive(true);
        temp = selected;
        shootGun.shootPossible = true;
        currentBullet = guns[selected].bulletCount;
        maxBullet = guns[selected].bulletCount.ToString();
        text.text = maxBullet + "/" + maxBullet;
    }

    public void Select(int num)
    {
        selected = num;
        Change();
    }

    // 총을 쏘는 함수- void(int)
    public void Shoot(int num)      // shootGun 에서 호출 됨
    {
        // 아래의 코드는 현재 테스트 코드, pool을 사용하는 코드로 변경할 것
        // num은 어떤 총의 총알을 쏘느냐에 대한 정보
        //GameObject bullet = Instantiate(bulletPrefab, Camera.main.transform.position, Camera.main.transform.rotation);
        //bulletPrefab.transform.position = Camera.main.transform.position;
        //bulletPrefab.transform.rotation = Camera.main.transform.rotation;
        currentBullet--;
        text.text = currentBullet.ToString() + "/" + maxBullet;

        GameObject bullet = makePool.poolList[num].Dequeue();
        bullet.transform.position = Camera.main.transform.position;
        bullet.transform.rotation = Camera.main.transform.rotation;

        bullet.SetActive(true);
        bullet.GetComponent<Renderer>().enabled = false;

        bullet.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * guns[selected].bulletSpeed);

        StartCoroutine(AppearBullet(bullet));
        StartCoroutine(BulletInvisibleDelay(bullet, guns[selected].bulletDuration, num));

        if (currentBullet == 0) { StartCoroutine(ReloadBullet(guns[selected].reloadDelay)); }
    }

    IEnumerator AppearBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(0.2f);
        //bullet.SetActive(true);
        bullet.GetComponent<Renderer>().enabled = true;
    }

    IEnumerator BulletInvisibleDelay(GameObject bullet, float time, int num)
    {
        yield return new WaitForSeconds(time);
        bullet.GetComponent<Rigidbody>().velocity = Vector3.zero;
        bullet.SetActive(false);
        makePool.poolList[num].Enqueue(bullet);
    }

    public IEnumerator ReloadBullet(float time)
    {
        shootGun.shootPossible = false;
        yield return new WaitForSeconds(time);
        currentBullet = int.Parse(maxBullet);
        text.text = maxBullet + "/" + maxBullet;
        if (currentBullet != 0) shootGun.shootPossible = true;
    }

    [System.Serializable]
    public class Gun
    {
        public GameObject gunPrefab;

        public float bulletSpeed;
        public float bulletDuration;
        public float shootDelay;
        public float reloadDelay;

        public int bulletCount;
        public int bulletDamage;
    }
}
