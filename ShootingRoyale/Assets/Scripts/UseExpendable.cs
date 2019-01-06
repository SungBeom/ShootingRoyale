using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseExpendable : MonoBehaviour
{
    int count = 1;
    public Button btn;
    public GameObject go;

    void Start()
    {
        GetComponent<Text>().text = "" + count;
    }

    void Update()
    {
        if (count > 0)
        {
            btn.interactable = true;
        }
        else
        {
            btn.interactable = false;
        }
    }

    public void UsePortion()
    {
        count--;
        GetComponent<Text>().text = "" + count;
        if (go.GetComponent<Slider>().value > 30)
        {
            go.GetComponent<Slider>().value = 100;
        }
        else
        {
            go.GetComponent<Slider>().value += 70;
        }
    }

    /*public void UseAdrenaline()
    {
        GetComponent<Text>
    }*/

    /*public void ThrowGrenade()
    {

    }*/
}
