using UnityEngine;

public class DoorController : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] private Sprite door_openMid;
    [SerializeField] private Sprite door_closedMid;
    [SerializeField] private Sprite top_open;
    [SerializeField] private Sprite top_closed;

    [Header("Settings")]
    [SerializeField] private float interactionDistance = 2f;

    [Header("References")]
    [SerializeField] private GameObject topPiece;

    private bool doorActive = false;
    private Transform player;
    private SpriteRenderer spriteRenderer;
    private Collider2D doorCollider;
    private SpriteRenderer topPieceSpriteRenderer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        doorCollider = GetComponent<Collider2D>();

        if (topPiece != null)
        {
            topPieceSpriteRenderer = topPiece.GetComponent<SpriteRenderer>();
            topPieceSpriteRenderer.sprite = top_closed;
        }

        spriteRenderer.sprite = door_closedMid;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, player.position) <= interactionDistance)
        {
            if (!doorActive)
            {
                doorActive = true;
                InteractionUI.Instance.ShowInteraction("Press E to use Gate Key");
            }

            if (doorActive && Input.GetKeyDown(KeyCode.E) && PlayerInventory.Instance.IsInInventory("GATEKEY"))
            {
                spriteRenderer.sprite = door_openMid;

                if (topPieceSpriteRenderer != null)
                {
                    topPieceSpriteRenderer.sprite = top_open;
                }

                PlayerInventory.Instance.RemoveItemFromInventory("GATEKEY");

                doorCollider.enabled = false;

                InteractionUI.Instance.ShowInteraction("Door unlocked with gate key.");

                doorActive = false;
            }
        }
        else
        {
            if (doorActive)
            {
                doorActive = false;
                InteractionUI.Instance.HideInteraction();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionDistance);
    }
}
