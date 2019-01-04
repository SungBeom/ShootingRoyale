using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void Scenechange()
    {
        SceneManager.LoadScene("ShootingRoyale");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
