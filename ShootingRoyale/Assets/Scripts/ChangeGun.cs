using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGun : MonoBehaviour
{
    public GameObject[] guns;
    [Range(0, 3)]               // 4 대신 (guns.Length - 1)을 넣는 것이 합당함
    public int selected;

    GameObject gun;
    int temp;

    public void Change()
    {
        guns[temp].SetActive(false);
        guns[selected].SetActive(true);
        temp = selected;
    }
}
