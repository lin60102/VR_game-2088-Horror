using System.Collections;
using System.Collections.Generic;
using Valve.VR;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserElevatorInput1 : MonoBehaviour
{
    int permission;
    int currentID;
    public static GameObject currentObject;
    public GameObject button1f;
    //public Animator newbtn_ani,quitbtn_ani;

    public SteamVR_Action_Boolean TriggerClick;
    private SteamVR_Input_Sources inputSource;
    // Start is called before the first frame update
    void Start()
    {
        
        currentID = 0;
        currentObject = null;
        permission = PlayerPrefs.GetInt("permission");
        if (permission == 1)
        {
            button1f.SetActive(false);
        }else if (permission == 2)
        {
            button1f.SetActive(true);
        }
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
                if (name == "B1btn")
                {
                    Debug.Log("Hit B1");
                  
                    onbtnB1();



                }
                if (name == "1Fbtn")
                {
                        Debug.Log("1F");
                        onbtn1f();              
                }
              
            }
        }
        //put your stuff here
        print("Success");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void onbtnB1()
    {
        if (permission == 1)
        {
            SceneManager.LoadScene("PuzzleScene");
        }      

    }
    void onbtn1f()
    {

        SceneManager.LoadScene("ShoottingLevelScene");
    }
}
