using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeExpendable : MonoBehaviour
{
    ExpendableControl expendableControl;

    delegate void UseFunction();
    UseFunction[] useFunction;

    void Start()
    {
        // 테스트를 위해 임의로 초기화
        transform.GetChild(0).GetComponent<Text>().text = "3";

        expendableControl = transform.parent.GetComponent<ExpendableControl>();

        useFunction = new UseFunction[]
        {
            new UseFunction(expendableControl.UseFirstAidKit),
            new UseFunction(expendableControl.UseAdrenaline),
            new UseFunction(expendableControl.UseSmokeShell)
        };
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
}
