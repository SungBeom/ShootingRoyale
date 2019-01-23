using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeSmokeShell : MonoBehaviour
{
    GameObject[] smoke;

    void Awake()
    {
        smoke = new GameObject[4];
    }

    void Start()
    {
        for (int i = 0; i < 4; i++)
            smoke[i] = transform.GetChild(i).gameObject;

        StartCoroutine("Explode");
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(2.0f);

        for (int i = 0; i < 4; i++)
            smoke[i].SetActive(true);
    }
}
