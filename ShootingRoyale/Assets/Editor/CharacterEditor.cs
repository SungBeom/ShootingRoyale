using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor (typeof (ChangeGun))]
public class CharacterEditor : Editor {

    public override void OnInspectorGUI()
    {
        ChangeGun gun = target as ChangeGun;

        if (DrawDefaultInspector())
        {
            gun.Change();
        }

        if (GUILayout.Button("Change Gun"))
        {
            gun.Change();
        }
    }
}