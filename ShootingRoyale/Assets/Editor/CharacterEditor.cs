using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor (typeof (ChangeGun))]
public class CharacterEditor : Editor {

    public override void OnInspectorGUI()
    {
        GunController gunController = target as GunController;

        if (DrawDefaultInspector())
        {
            gunController.Change();
        }

        if (GUILayout.Button("Change Gun"))
        {
            gunController.Change();
        }
    }
}