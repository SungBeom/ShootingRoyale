using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeExpendable : MonoBehaviour
{
    // enum State { GET, USE }
    //int count = 1;
    //public Button btn;
    //public GameObject go;
    public delegate void UseFunction();
    UseFunction[] useFunction;

    void Start()
    {
        // GetComponent<Text>().text = "" + count;
        transform.GetChild(0).GetComponent<Text>().text = "3";
        useFunction = new UseFunction[]
        {
            new UseFunction(UseFirstAidKit),
            new UseFunction(UseAdrenaline),
            new UseFunction(UseSmokeShell)
        };
    }

    void Update()
    {
        //if (count > 0)
        //{
        //    btn.interactable = true;
        //}
        //else
        //{
        //    btn.interactable = false;
        //}
    }

    public void GetExpendable()
    {
        int count;
        Text text = transform.GetChild(0).GetComponent<Text>();

        if (int.TryParse(text.text, out count))
        {
            text.text = (count + 1).ToString();
            gameObject.GetComponent<Button>().interactable = true;
        }
    }

    public void UseExpendable(int index)
    {
        int count;
        Text text = transform.GetChild(0).GetComponent<Text>();

        if (int.TryParse(text.text, out count))
        {
            useFunction[index]();

            text.text = (count - 1).ToString();
            if (count - 1 == 0)
                gameObject.GetComponent<Button>().interactable = false;
        }
    }

    //public void ChangeExpendableState(int index, int state)
    //{
    //    int count;
    //    Text text = transform.GetChild(0).GetComponent<Text>();

    //    if (state == 0)
    //    {
    //        if (int.TryParse(text.text, out count))
    //        {
    //            text.text = (count + 1).ToString();
    //            gameObject.GetComponent<Button>().interactable = true;
    //        }
    //    }

    //    else if (state == 1)
    //    {
    //        if (int.TryParse(transform.GetChild(0).GetComponent<Text>().text, out count))
    //        {
    //            // 각 소모품(index)에 맞는 사용 효과를 넣기

    //            text.text = (count - 1).ToString();
    //            if (count - 1 == 0)
    //                gameObject.GetComponent<Button>().interactable = false;
    //        }
    //    }
    //}

    void UseFirstAidKit()
    {

    }

    void UseAdrenaline()
    {

    }

    void UseSmokeShell()
    {

    }

    /*public void UsePotion()
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
    }*/

    /*public void UseAdrenaline()
    {
        GetComponent<Text>
    }*/

    /*public void ThrowGrenade()
    {

    }*/
}
