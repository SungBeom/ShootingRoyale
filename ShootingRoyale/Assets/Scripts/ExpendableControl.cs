﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ExpendableControl : MonoBehaviour
{
    public Slider health;
    // 현재 사람의 속도를 증가시키나 총 속도를 증가시키는 쪽으로 변경 예정
    public RigidbodyFirstPersonController controller;

    struct MovementSettings
    {
        public float ForwardSpeed;
        public float BackwardSpeed;
        public float StrafeSpeed;
        public float JumpForce;
    }
    MovementSettings movementSettings;

    [Range(0, 100)]
    public float healingAmount;
    public float accelerationTime;
    [Range(1, 10)]
    public float accelerationRate;

    bool isBuffed;

    public void UseFirstAidKit()
    {
        Debug.Log(health.maxValue);
        Debug.Log("UseFirstAidKit - " + healingAmount + " heal");

        if (health.value >= health.maxValue - healingAmount) health.value = health.maxValue;
        else health.value += healingAmount;
    }

    public void UseAdrenaline()
    {
        if (isBuffed == false)
        {
            Debug.Log("UseAdrenaline - (" + accelerationTime + ", " + accelerationRate + ")");
            isBuffed = true;

            movementSettings.ForwardSpeed = controller.movementSettings.ForwardSpeed;
            movementSettings.BackwardSpeed = controller.movementSettings.BackwardSpeed;
            movementSettings.StrafeSpeed = controller.movementSettings.StrafeSpeed;
            movementSettings.JumpForce = controller.movementSettings.JumpForce;

            controller.movementSettings.ForwardSpeed *= accelerationRate;
            controller.movementSettings.BackwardSpeed *= accelerationRate;
            controller.movementSettings.StrafeSpeed *= accelerationRate;
            controller.movementSettings.JumpForce *= accelerationRate;

            Invoke("CalmDown", accelerationTime);
        }
    }

    public void UseSmokeShell()
    {

    }

    void CalmDown()
    {
        Debug.Log("CalmDown...");

        controller.movementSettings.ForwardSpeed = movementSettings.ForwardSpeed;
        controller.movementSettings.BackwardSpeed = movementSettings.BackwardSpeed;
        controller.movementSettings.StrafeSpeed = movementSettings.StrafeSpeed;
        controller.movementSettings.JumpForce = movementSettings.JumpForce;

        isBuffed = false;
    }
}
