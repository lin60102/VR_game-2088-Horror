using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeLevelWin : MonoBehaviour
{
    public int antidote;
    void Start() {
       

    }
    
    private void OnTriggerEnter(Collider other)
    {
        antidote=PlayerPrefs.GetInt("antidote");
        if (other.name== "Player" && antidote ==1)
        {
            PlayerPrefs.SetInt("permission", 1);
            SceneManager.LoadScene("ElevatorScene");
            Debug.Log("win!!");
        }
    }
}
