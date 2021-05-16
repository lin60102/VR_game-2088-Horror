using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : MonoBehaviour
{

    public ZombieHealth zombieHealth;

    void Update()
    {
        Debug.Log(zombieHealth.Health);

        if (zombieHealth.Health >= 100)
        {
            Debug.Log("Win");
            SceneManager.LoadScene("Menu 3D");
        }
    }
}
