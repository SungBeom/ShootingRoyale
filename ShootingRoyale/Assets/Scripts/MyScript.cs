using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScript : MonoBehaviour
{

    protected Joystick joystick;
    protected FixedButton joybutton;

    protected bool jump;

    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<FixedButton>();
    }

    // Update is called once per frame
    void Update()
    {

        var rigidbody = GetComponent<Rigidbody>();

        rigidbody.velocity = new Vector3(joystick.Horizontal * 100f + Input.GetAxis("Horizontal"),
            rigidbody.velocity.y,
            joystick.Vertical * 100f + Input.GetAxis("Vertical"));

        if (!jump && (joybutton.Pressed || Input.GetButtonDown("Fire2")))
        {
            jump = true;
            rigidbody.velocity += Vector3.up * 20f;
        }

        if (jump && !joybutton.Pressed || Input.GetButtonDown("Fire2"))
        {
            jump = false;
        }
    }
}
