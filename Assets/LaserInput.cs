using System.Collections;
using System.Collections.Generic;
using Valve.VR;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LaserInput : MonoBehaviour
{
    public static GameObject currentObject;
    int currentID;
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

       
        for(int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            int id = hit.collider.gameObject.GetInstanceID();
            if(currentID != id)
            {
                currentID = id;
                currentObject = hit.collider.gameObject;

                //check name
                
                string name = currentObject.name;
                if(name== "Newgame")
                {
                    Debug.Log("Hit New game");
                    /*
                    newbtn_ani.SetBool("Normal", false);
                    quitbtn_ani.SetBool("Highlighted", false);
                    quitbtn_ani.SetBool("Normal", true);
                    newbtn_ani.SetBool("Highlighted", true);
                    */
                        onbtnstart();
                    
                   

                }
                if (name == "Quit")
                {
                    Debug.Log("Hit Quit");
                    /*
                    newbtn_ani.SetBool("Normal", true);
                    quitbtn_ani.SetBool("Normal", false);
                    quitbtn_ani.SetBool("Highlighted", true);
                    newbtn_ani.SetBool("Highlighted", false);
                    */
                        onbtnquit();
                    

                }
                //check tag
                /*
                string tag = currentObject.tag;
                if (tag == "button")
                {
                    Debug.Log("Hit tag button");
                }
                */
            }
        }
        //put your stuff here
        print("Success");
    }
    // Update is called once per frame
    void Update()
    {
       
        
    }
    public void onbtnquit()
    {
        
    }
    public void onbtnstart()
    {
        SceneManager.LoadScene("Name");
    }
}
