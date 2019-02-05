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

    public MakePool poolManager;    // poolManager 넣는 장소
    public ShootGun shootGun;

    [Range(0, 3)]                   // 4 대신 (guns.Length - 1)을 넣는 것이 합당함
    public int selected;
    public Text text;
    int currentBullet;
    string maxBullet;
    int temp;

    public void Change()
    {
        guns[temp].gunPrefab.SetActive(false);
        guns[selected].gunPrefab.SetActive(true);
        temp = selected;

        shootGun.shootPossible = true;
        currentBullet = guns[selected].bulletCount;
        maxBullet = currentBullet.ToString();
        text.text = maxBullet + "/" + maxBullet;
    }

    public void Select(int num)
    {
        selected = num;
        Change();
    }

    public void Shoot(int num)
    {
        text.text = (--currentBullet).ToString() + "/" + maxBullet;

        GameObject bullet = poolManager.poolList[num].Dequeue();
        bullet.transform.position = Camera.main.transform.position;
        bullet.transform.rotation = Camera.main.transform.rotation;

        bullet.SetActive(true);
        bullet.GetComponent<Renderer>().enabled = false;

        bullet.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * guns[selected].bulletSpeed);

        StartCoroutine(AppearBullet(bullet));
        StartCoroutine(DisappearBullet(bullet, guns[selected].bulletDuration, num));

        if (currentBullet == 0)
        {
            // Shoot을 멈추고(shootPosible이 true가 되는 것을 방지), reload를 실행
            StopCoroutine(shootGun.Shoot(shootGun.gunPos.GetComponent<GunController>().guns[selected].shootDelay));
            StartCoroutine(ReloadBullet(guns[selected].reloadDelay));
        }
    }

    IEnumerator AppearBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(0.2f);
        bullet.GetComponent<Renderer>().enabled = true;
    }

    IEnumerator DisappearBullet(GameObject bullet, float durationTime, int num)
    {
        yield return new WaitForSeconds(durationTime);
        bullet.GetComponent<Rigidbody>().velocity = Vector3.zero;
        bullet.SetActive(false);
        poolManager.poolList[num].Enqueue(bullet);
    }

    public IEnumerator ReloadBullet(float reloadTime)
    {
        // 코드 변경 필요
        shootGun.shootPossible = false;
        Debug.Log(currentBullet);

        yield return new WaitForSeconds(reloadTime);
        if (currentBullet != 0) shootGun.shootPossible = true;
        int.TryParse(maxBullet, out currentBullet);
        text.text = currentBullet + "/" + maxBullet;
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
