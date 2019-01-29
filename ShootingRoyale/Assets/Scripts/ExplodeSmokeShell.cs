using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeSmokeShell : MonoBehaviour
{
    GameObject[] smoke;

    void Awake()
    {
        smoke = new GameObject[8];
    }

    void Start()
    {
        for (int i = 0; i < 8; i++)
            smoke[i] = transform.GetChild(i).gameObject;

        StartCoroutine("Explode");
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(2.0f);
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<Renderer>().enabled = false;

        for (int i = 0; i < 8; i++)
            smoke[i].SetActive(true);

        yield return new WaitForSeconds(7.0f);
        Destroy(gameObject);
    }
}
