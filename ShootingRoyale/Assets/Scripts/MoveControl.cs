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
        // 소모품이 각각 얻어질 시 해당 소모품에 맞는 태그로 비교
        // 만약 소모품 중 랜덤하게 얻어진다면 소모품 태그로 변경 후,
        // 내부에서 Btn 배열의 크기에 맞는 index 값을 랜덤하게 추출 -> 해당하는 소모품의 수를 늘려줌
        // (근데 소모품을 얻고난 뒤에 버튼 UI를 기억과 비교해서 무엇을 얻었는지 보는 것이 맞는가...?)
        // (해당 방식을 유지하기 위해서는 알림창을 띄워주는 것이 합당 -> 전투 중에는 방해일 수도 있음)
        // (상자를 부숴서 얻는 방식도 고려 -> 총알의 소모가 있다는 시스템적인 변화가 생김)
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
