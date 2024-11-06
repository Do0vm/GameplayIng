using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    public TextMeshProUGUI interactionText;

    public static InteractionUI Instance;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;

    }

    // Update is called once per frame
    void showInteraction()
    {

    }


    void hideInteraction()
    {

    }
}
