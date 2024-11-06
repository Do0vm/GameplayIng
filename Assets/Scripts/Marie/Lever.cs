using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private Sprite switchLeft;
    [SerializeField] private Sprite switchRight;
    private bool leverActive;      // True when player is in range to use the lever
    private bool handlePlaced;     // True when the lever handle is placed
    private bool useLever;         // Tracks the lever's current state (on/off)
    public GameObject Bridge;
    void Update()
    {
        if ((leverActive && Input.GetKeyDown(KeyCode.E) && PlayerInventory.Instance.IsInInventory("LEVERHANDLE")) || (leverActive && Input.GetKeyDown(KeyCode.E) && handlePlaced))
        {
            if (!handlePlaced)
            {
                // Place the handle
                handlePlaced = true;
                GetComponent<SpriteRenderer>().sprite = switchLeft;
                InteractionUI.Instance.ShowInteraction("Lever handle placed. You can now use the lever.");
                PlayerInventory.Instance.RemoveItemFromInventory("LEVERHANDLE");
            }
            else
            {

                Bridge.GetComponent<Animator>().SetTrigger("Down");
                // Toggle lever state after handle is placed
                useLever = !useLever;
                GetComponent<SpriteRenderer>().sprite = useLever ? switchRight : switchLeft;
                InteractionUI.Instance.ShowInteraction("Lever toggled to " + (useLever ? "on" : "off"));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            leverActive = true; // Player is in range to use the lever
            InteractionUI.Instance.ShowInteraction("Press E to use the lever");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            leverActive = false; // Player left the lever area
            InteractionUI.Instance.HideInteraction();
        }
    }
}



//using System.Collections;
//using System.Collections.Generic;
//using System.Runtime.CompilerServices;
//using UnityEditor;
//using UnityEngine;

//public class Lever : MonoBehaviour
//{
//    [SerializeField] private Sprite switchLeft;
//    [SerializeField] private Sprite switchRight;
//    private bool leverActive;
//    private bool useLever;

//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.E) && PlayerInventory.Instance.IsInInventory("LEVERHANDLE"))        //Input to handle the interaction with the handle
//        {
//            useLever = true;
//        }
//        else { useLever = false; }
//    }

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        leverActive = false;
//        Debug.Log("Trigger Zorking");
//        if (useLever) // Enables lever
//        {
//            GetComponent<SpriteRenderer>().sprite = switchLeft;

//            Debug.Log("This is working");
//            leverActive = true;

//        }


//        if (leverActive && useLever) //After lever enabled you can use it
//        {
//            GetComponent<SpriteRenderer>().sprite = switchRight;
//        }



//    }


//    private void OnTriggerExit2D(Collider2D collision) // so that you cant use it anyzhere on the map
//    {
//        leverActive = false;
//    }




