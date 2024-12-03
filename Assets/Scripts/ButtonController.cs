using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float interactionDistance = 2f;
    [SerializeField] private string requiredItemID = "GEM";
    [SerializeField] private PlatformController platformController;

    [Header("Sprites")]
    [SerializeField] private Sprite buttonDefault;
    [SerializeField] private Sprite buttonPressedDown;

    private bool buttonActive = false;
    private bool isPressed = false;

    private Transform player;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = buttonDefault;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, player.position) <= interactionDistance && !isPressed)
        {
            if (!buttonActive)
            {
                buttonActive = true;
                InteractionUI.Instance.ShowInteraction("Press E to activate with GEM");
            }

            if (buttonActive && Input.GetKeyDown(KeyCode.E) && PlayerInventory.Instance.IsInInventory(requiredItemID))
            {
                Item gemItem = PlayerInventory.Instance.GetInventory().Find(item => item.uniqueID == requiredItemID);
                PlayerInventory.Instance.RemoveItemFromInventory("GEM");


                InteractionUI.Instance.ShowInteraction("Button activated with GEM!");
                platformController.EnablePlatformInteraction();

                spriteRenderer.sprite = buttonPressedDown;
                isPressed = true;
                buttonActive = false;
            }
        }
        else
        {
            if (buttonActive && !isPressed)
            {
                buttonActive = false;
                InteractionUI.Instance.HideInteraction();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, interactionDistance);
    }
}
