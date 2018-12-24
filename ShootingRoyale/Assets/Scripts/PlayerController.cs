using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    Vector2 firstPos;
    Vector2 movePos;
    Vector2 direction;

    public float moveSpeed;

    public GameObject bulletPrefab;

    public Transform bulletSpawn;

    // Update is called once per frame
    void Update() {

        if (!isLocalPlayer)
        {
            return;
        }

        // 이동 부분(수정)
        //var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        //var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        //transform.Rotate(0, x, 0);
        //transform.Translate(0, 0, z);

        for (int i = 0; i < Input.touchCount; i++)
        {
            if (TouchSide(Input.GetTouch(i).position))
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                    firstPos = Input.GetTouch(i).position;
                if (Input.GetTouch(i).phase == TouchPhase.Moved)
                {
                    movePos = Input.GetTouch(i).position;
                    direction = (movePos - firstPos).normalized;
                    transform.Translate(new Vector3(-direction.y, 0, direction.x) * Time.deltaTime * moveSpeed);
                }
            }
            else
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                    firstPos = Input.GetTouch(i).position;
                if (Input.GetTouch(i).phase == TouchPhase.Moved)
                {
                    movePos = Input.GetTouch(i).position;
                    direction = (movePos - firstPos).normalized;
                    transform.Rotate(0, direction.x, 0);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
        }
	}

    [Command]
    void CmdFire()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

        NetworkServer.Spawn(bullet);

        Destroy(bullet, 2.0f);
    }

    bool TouchSide(Vector2 touchPos)
    {
        if (touchPos.x < Screen.width / 2)
            return true;
        else
            return false;
    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}
