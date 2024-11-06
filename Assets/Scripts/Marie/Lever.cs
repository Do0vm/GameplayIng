using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private Sprite switchLeft;
    [SerializeField] private Sprite switchRight;
    private bool leverActive;
    private bool useLever;

   void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerInventory.Instance.IsInInventory("LEVERHANDLE"))        //Input to handle the interaction with the handle
        {
            useLever = true;
        }
        else { useLever = false; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        leverActive = false;
        Debug.Log("Trigger Zorking");
        if (useLever) // Enables lever
        {
            GetComponent<SpriteRenderer>().sprite = switchLeft;

            Debug.Log("This is working");
            leverActive = true;

        }
       
        
        if (leverActive && useLever) //After lever enabled you can use it
        {
            GetComponent<SpriteRenderer>().sprite = switchRight;
        }
        


    }


    private void OnTriggerExit2D(Collider2D collision) // so that you cant use it anyzhere on the map
    {
        leverActive= false;
    }







}
