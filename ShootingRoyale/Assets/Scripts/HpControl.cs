using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpControl : MonoBehaviour
{
    public float hp;
    Slider myHp;
    public Slider hpUI;

    void Start()
    {
        myHp = GetComponent<Slider>();
    }

    public void GainDamage(float damage)
    {
        hp -= damage;

        myHp.value = hp;
        hpUI.value = hp;
    }
}
