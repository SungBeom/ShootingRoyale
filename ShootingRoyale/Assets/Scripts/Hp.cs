using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp : MonoBehaviour
{
    public float hitPoint = 100;
    public Transform slider;

    void Start()
    {
        GetComponent<Slider>().value = hitPoint;
    }

    public void GainDamage(float Damage)
    {
        hitPoint -= Damage;
        GetComponent<Slider>().value = hitPoint;
    }

    public void Recovery(float hp)
    {
        hitPoint += hp;
        GetComponent<Slider>().value = hitPoint;
    }
}
