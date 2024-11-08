using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerInventory.Instance.IsInInventory("REDGEM") && collision.CompareTag("Player"))

        {

            Death();

        }

        else
        {
            InteractionUI.Instance.ShowInteraction("You gotta go back and get then Diamond ....");


        }

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            InteractionUI.Instance.HideInteraction();
        }
    }



    public void Death()
    {
        SceneManager.LoadScene("YouDied");

    }

    //PlayerInventory.Instance.IsInInventory("LEVERHANDLE")
}
