using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class MoveControl : MonoBehaviour
{
    public FixedJoystick MoveJoystick;
    public FixedButton JumpButton;
    public FixedTouchField TouchField;

    public Button[] ExpendableBtn;
    public Button[] GunBtn;

    delegate void GetBox();
    GetBox[] getBox;

    void Start()
    {
        for (int i = 0; i < GunBtn.Length; i++)
            GunBtn[i].interactable = false;

        getBox = new GetBox[]
        {
            new GetBox(GetExpendable),
            new GetBox(GetGun)
        };
    }

    void Update()
    {
        var fps = GetComponent<RigidbodyFirstPersonController>();

        fps.RunAxis = MoveJoystick.Direction;
        fps.JumpAxis = JumpButton.Pressed;
        fps.mouseLook.LookAxis = TouchField.TouchDist;
    }

    void OnCollisionEnter(Collision col)
    {
        int index = -1;
        if (col.gameObject.tag.Equals("ExpendableBox")) index = 0;
        else if (col.gameObject.tag.Equals("GunBox")) index = 1;

        if (index > -1)
        {
            Destroy(col.gameObject.GetComponent<Collider>());
            col.transform.parent.LookAt(transform);
            col.transform.parent.eulerAngles = new Vector3(0f, col.transform.parent.eulerAngles.y + 90f, 0f);

            col.gameObject.GetComponent<Animator>().SetTrigger("Get_t");
            getBox[index]();
            Destroy(col.transform.parent.gameObject, 1f);
        }
    }

    void GetExpendable()
    {
        int index = Random.Range(0, ExpendableBtn.Length);
        Debug.Log(index);
        ExpendableBtn[index].GetComponent<ChangeExpendable>().GetExpendable();
    }

    void GetGun()
    {
        int index = Random.Range(0, GunBtn.Length);
        Debug.Log(index);
        GunBtn[index].interactable = true;
    }
}
