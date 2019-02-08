using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    public Gun[] guns;

    public MakePool poolManager;
    public ShootGun shootGun;

    [Range(0, 3)]                   // 4 대신 (guns.Length - 1)을 넣는 것이 합당함
    public int selected;
    public Text text;
    [HideInInspector]
    public int currentBullet;
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
        Renderer[] bulletRenderers = bullet.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < bulletRenderers.Length; i++)
            bulletRenderers[i].enabled = false;
        bullet.GetComponent<Collider>().enabled = false;

        bullet.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * guns[selected].bulletSpeed);

        StartCoroutine(AppearBullet(bullet));
        StartCoroutine(DisappearBullet(bullet, guns[selected].bulletDuration, num));

        if (currentBullet == 0)
            StartCoroutine(ReloadBullet(guns[selected].reloadDelay));
    }

    IEnumerator AppearBullet(GameObject bullet)
    {
        // 0.5초 뒤에 보임
        // 이것을 거리로 환산하고 싶음, 대략 1의 거리 뒤에 보이게 하고 싶음
        // 1초에 speed를 간다고 가정하면 1을 가고 싶을 때, 1초 / 스피드는 = 거리 1
        yield return new WaitForSeconds(75f / guns[selected].bulletSpeed);
        Renderer[] bulletRenderers = bullet.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < bulletRenderers.Length; i++)
            bulletRenderers[i].enabled = true;
        bullet.GetComponent<Collider>().enabled = true;
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
        shootGun.shootPossible = false;
        yield return new WaitForSeconds(reloadTime);
        int.TryParse(maxBullet, out currentBullet);
        text.text = currentBullet + "/" + maxBullet;
        shootGun.shootPossible = true;
    }

    [System.Serializable]
    public class Gun
    {
        public GameObject gunPrefab;

        public float bulletDamage;
        public int bulletCount;

        public float bulletSpeed;
        public float bulletDuration;

        public float shootDelay;
        public float reloadDelay;
    }
}
