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
        if (col.gameObject.tag.Equals("Potion"))
        {
            ExpendableBtn[0].GetComponent<ChangeExpendable>().GetExpendable();
            Destroy(col.gameObject);
        }
    }
}
