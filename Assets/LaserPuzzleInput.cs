using System.Collections;
using System.Collections.Generic;
using Valve.VR;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LaserPuzzleInput : MonoBehaviour
{
    int permission;
    int currentID;
    public GameObject Corpse;
    public GameObject title;
    public static GameObject currentObject;
    //public Animator newbtn_ani,quitbtn_ani;
    
    public SteamVR_Action_Boolean TriggerClick;
    private SteamVR_Input_Sources inputSource;
    // Start is called before the first frame update
    void Start()
    {
        currentID = 0; 
        currentObject = null;
    }
    private void OnEnable()
    {
        TriggerClick.AddOnStateDownListener(Press, inputSource);
    }

    private void OnDisable()
    {
        TriggerClick.RemoveOnStateDownListener(Press, inputSource);
    }

    private void Press(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, 100.0f);


        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            int id = hit.collider.gameObject.GetInstanceID();
            if (currentID != id)
            {
                currentID = id;
                currentObject = hit.collider.gameObject;

                //check name

                string name = currentObject.name;
          
                switch (name)
                {
                    case "BlueSuitFree01":
                        Corpse.SetActive(false);
                        break;
                    case "btn0":
                        btn0();
                        break;
                    case "btn1":
                        btn1();
                        break;
                    case "btn2":
                        btn2();
                        break;
                    case "btn3":
                        btn3();
                        break;
                    case "btn4":
                        btn4();
                        break;
                    case "btn5":
                        btn5();
                        break;
                    case "btn6":
                        btn6();
                        break;
                    case "btn7":
                        btn7();
                        break;
                    case "btn8":
                        btn8();
                        break;
                    case "btn9":
                        btn9();
                        break;
                    case "btnclear":
                        clear();
                        break;              
                    case "btnenter":
                        ok();
                        break;
                }
            }
        }       
        print("Success");
    }
    public void btn0()
    {
        clean();
        title.GetComponent<Text>().text = title.GetComponent<Text>().text + "0";
    }
    public void btn1()
    {
        clean();
        title.GetComponent<Text>().text = title.GetComponent<Text>().text + "1";
    }
    public void btn2()
    {
        clean();
        title.GetComponent<Text>().text = title.GetComponent<Text>().text + "2";
    }
    public void btn3()
    {
        clean();
        title.GetComponent<Text>().text = title.GetComponent<Text>().text + "3";
    }
    public void btn4()
    {
        clean();
        title.GetComponent<Text>().text = title.GetComponent<Text>().text + "4";
    }
    public void btn5()
    {
        clean();
        title.GetComponent<Text>().text = title.GetComponent<Text>().text + "5";
    }
    public void btn6()
    {
        clean();
        title.GetComponent<Text>().text = title.GetComponent<Text>().text + "6";
    }
    public void btn7()
    {
        clean();
        title.GetComponent<Text>().text = title.GetComponent<Text>().text + "7";
    }
    public void btn8()
    {
        clean();
        title.GetComponent<Text>().text = title.GetComponent<Text>().text + "8";
    }
    public void btn9()
    {
        clean();
        title.GetComponent<Text>().text = title.GetComponent<Text>().text + "9";
    }
    public void ok()
    {
        if (title.GetComponent<Text>().text == "0517") {
            PlayerPrefs.SetInt("permission",2   );
            SceneManager.LoadScene("ElevatorScene");
        }
        else
        {
            title.GetComponent<Text>().text = "error";
        }
    }
    public void clear()
    {
        title.GetComponent<Text>().text = "";

    }
    void clean()
    {
        if (title.GetComponent<Text>().text == "error") { title.GetComponent<Text>().text = ""; }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
