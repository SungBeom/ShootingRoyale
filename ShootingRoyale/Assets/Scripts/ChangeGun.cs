using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGun : MonoBehaviour
{
    //public GameObject[] guns;
    public Gun[] guns;

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
