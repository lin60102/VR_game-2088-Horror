using System.Collections;
using System.Collections.Generic;
using Valve.VR;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class laserNameInput : MonoBehaviour
{
    public static GameObject currentObject;
    int currentID;
    //public Animator newbtn_ani,quitbtn_ani;
    public GameObject title;
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
           // if (currentID != id)
            //{
                currentID = id;
                currentObject = hit.collider.gameObject;

                //check name

                string name = currentObject.name;
                switch (name)
                {
                    case "LetterA":
                        btna();
                        
                        break;
                    case "LetterB":
                        btnb();
                        break;
                    case "LetterC":
                        btnc();
                        break;
                    case "LetterD":
                        btnd();
                        break;
                    case "LetterE":
                        btne();
                        break;
                    case "LetterF":
                        btnf();
                        break;
                    case "LetterG":
                        btng();
                        break;
                    case "LetterH":
                        btnh();
                        break;
                    case "LetterI":
                        btni();
                        break;
                    case "LetterJ":
                        btnj();
                        break;
                    case "LetterK":
                        btnk();
                        break;
                    case "LetterL":
                        btnl();
                        break;
                    case "LetterM":
                        btnm();
                        break;
                    case "LetterN":
                        btnn();
                        break;
                    case "LetterO":
                        btno();
                        break;
                    case "LetterP":
                        btnp();
                        break;
                    case "LetterQ":
                        btnq();
                        break;
                    case "LetterR":
                        btnr();
                        break;
                    case "LetterS":
                        btns();
                        break;
                    case "LetterT":
                        btnt();
                        break;
                    case "LetterU":
                        btnu();
                        break;
                    case "LetterW":
                        btnw();
                        break;
                    case "LetterX":
                        btnx();
                        break;
                    case "LetterY":
                        btny();
                        break;
                    case "LetterZ":
                        btnz();
                        break;
                    case "Cancel Button":
                        cancel();
                        break;
                    case "Clear Button":
                        clear();
                        break;
                    case "Delete Button":
                        delete();
                        break;
                    case "Ok Button":
                        ok();
                        break;

                }
           // }
        }
        //put your stuff here
        print("Success");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void btna()
    {
        clean();
        title.GetComponent<Text>().text = title.GetComponent<Text>().text + "a";
    }
    public void btnb()
    {
        clean();
        title.GetComponent<Text>().text = title.GetComponent<Text>().text + "b";
    }
    public void btnc()
    {
        clean();
        title.GetComponent<Text>().text = title.GetComponent<Text>().text + "c";
    }
    public void btnd()
    {
        clean();
        title.GetComponent<Text>().text = title.GetComponent<Text>().text + "d";
    }
    public void btne()
    {
        clean();
        title.GetComponent<Text>().text = title.GetComponent<Text>().text + "e";
    }
    public void btnf()
    {
        clean();
        title.GetComponent<Text>().text = title.GetComponent<Text>().text + "f";
    }
    public void btng()
    {
        clean();
        title.GetComponent<Text>().text = title.GetComponent<Text>().text + "g";
    }
    public void btnh()
    {
        clean();
        title.GetComponent<Text>().text = title.GetComponent<Text>().text + "h";
    }
    public void btni()
    {
        clean();
        title.GetComponent<Text>().text = title.GetComponent<Text>().text + "i";
    }
    public void btnj()
    {
        clean();
        title.GetComponent<Text>().text = title.GetComponent<Text>().text + "j";
    }
    public void btnk()
    {
        clean();
        title.GetComponent<Text>().text = title.GetComponent<Text>().text + "k";
    }
    public void btnl()
    {
        clean();
        title.GetComponent<Text>().text = title.GetComponent<Text>().text + "l";
    }
    public void btnm()
    {
        clean();
        title.GetComponent<Text>().text = title.GetComponent<Text>().text + "m";
    }
    public void btnn()
    {
        clean();
        title.GetComponent<Text>().text = title.GetComponent<Text>().text + "n";
    }
    public void btno()
    {
        clean();
        title.GetComponent<Text>().text = title.GetComponent<Text>().text + "o";
    }
    public void btnp()
    {
        clean();
        title.GetComponent<Text>().text = title.GetComponent<Text>().text + "p";
    }
    public void btnq()
    {
        clean();
        title.GetComponent<Text>().text = title.GetComponent<Text>().text + "q";
    }
    public void btnr()
    {
        clean();
        title.GetComponent<Text>().text = title.GetComponent<Text>().text + "r";
    }
    public void btns()
    {
        clean();
        title.GetComponent<Text>().text = title.GetComponent<Text>().text + "s";
    }
    public void btnt()
    {
        clean();
        title.GetComponent<Text>().text = title.GetComponent<Text>().text + "t";
    }
    public void btnu()
    {
        clean();
        title.GetComponent<Text>().text = title.GetComponent<Text>().text + "u";
    }
    public void btnv()
    {
        clean();
        title.GetComponent<Text>().text = title.GetComponent<Text>().text + "v";
    }
    public void btnw()
    {
        clean();
        title.GetComponent<Text>().text = title.GetComponent<Text>().text + "w";
    }
    public void btnx()
    {
        clean();
        title.GetComponent<Text>().text = title.GetComponent<Text>().text + "x";
    }
    public void btny()
    {
        clean();
        title.GetComponent<Text>().text = title.GetComponent<Text>().text + "y";
    }
    public void btnz()
    {
        clean();
        title.GetComponent<Text>().text = title.GetComponent<Text>().text + "z";
    }
    public void ok()
    {
        PlayerPrefs.SetString("heroname", title.GetComponent<Text>().text);
        SceneManager.LoadScene("ElevatorScene");


    }
    public void clear()
    {
        title.GetComponent<Text>().text = "";

    }
    public void cancel()
    {
        SceneManager.LoadScene("Menu 3D");
    }
    public void delete()
    {
        string namestr= title.GetComponent<Text>().text;
        namestr = namestr.Substring(0, namestr.Length - 1);
        title.GetComponent<Text>().text = namestr;


    }
    void clean()
    {
        if (title.GetComponent<Text>().text == "Grid") { title.GetComponent<Text>().text = ""; }
    }
}
