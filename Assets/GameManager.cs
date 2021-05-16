using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SpeechLib;


public class GameManager : MonoBehaviour
{
    public GameObject textbox;
    string name;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("permission", 0);
        name = PlayerPrefs.GetString("heroname","Hero");
        
        StartCoroutine(Thesequence());

    }

    // Update is called once per frame
   IEnumerator Thesequence()
    {
        SpVoice voice;
        voice = new SpVoice();
        Debug.Log("1");
        yield return new WaitForSeconds(1);
        textbox.GetComponent<Text>().text = "???: " + name + " Hurry! We don't have time!";
        voice.Speak(name + "Hurry!We don't have time!");
        yield return new WaitForSeconds(1);
        textbox.GetComponent<Text>().text = "???: You are the last hope of human!";
        voice.Speak("You are the last hope of human!");
        yield return new WaitForSeconds(1);
        textbox.GetComponent<Text>().text = "???: This is Mike, WSBA will support you!";
        voice.Speak("This is Mike, WSBA will support you!");
        yield return new WaitForSeconds(1);
        textbox.GetComponent<Text>().text = "Mike: Move to 1F, we will cover you!";
        voice.Speak("Mike: Move to 1F, we will cover you!");
        Debug.Log("end");

    }
}
