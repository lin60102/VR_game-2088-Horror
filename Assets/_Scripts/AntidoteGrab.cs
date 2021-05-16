using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
public class AntidoteGrab : MonoBehaviour
{
    private Interactable interactable;
    public GameObject Player;
    private bool attach;
    // Start is called before the first frame update
    void Start()
    {
        attach = false;
        PlayerPrefs.SetInt("antidote", 0);
    }
    private void Update()
    {
        if (attach==true)
        {
            gameObject.transform.parent = Player.transform;
            gameObject.transform.position = Player.transform.position;
            PlayerPrefs.SetInt("antidote", 1);
        }
    }

    private void OnHandHoverBegin(Hand hand)
    {
        hand.ShowGrabHint();
    }

    private void OnHandHoverEnd(Hand hand)
    {
        hand.HideGrabHint();
    }

    private void OnHandHoverUpdate(Hand hand)
    {
        GrabTypes grabTypes = hand.GetGrabStarting();
        bool isGrabEnding = hand.IsGrabEnding(gameObject);
        attach = true;
        
        if (interactable.attachedToHand == null && grabTypes != GrabTypes.None)
        {
          
            hand.AttachObject(gameObject, grabTypes);
            hand.HoverLock(interactable);
            hand.HideGrabHint();
            gameObject.transform.parent = Player.transform;
            attach = true;
            
            //Debug.Log("attach");
        }
        else if (isGrabEnding)
        {
            hand.DetachObject(gameObject);
            hand.HoverUnlock(interactable);

        }
    }
    public void onAttach()
    {
        PlayerPrefs.SetInt("antidote", 1);
        attach = true;
    }
}
