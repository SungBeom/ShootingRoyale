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

    public void Change()        // 수류탄과 연막탄은 어차피 던질때 바꿔 들어야 하는데 여기에 쓰는게 낫지않을까?
    {
        guns[temp].SetActive(false);
        guns[selected].SetActive(true);
        temp = selected;
    }

    public void Select(int num)
    {
        selected = num;
        Change();
    }

    public int GetSelect()
    {
        return selected;
    }
}
