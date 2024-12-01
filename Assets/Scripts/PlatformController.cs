using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [Header("Platform Settings")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float maxHeight = 5f;

    private bool isInteractable = false;
    private bool isMoving = false;
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (isInteractable && Input.GetKeyDown(KeyCode.E))
        {
            isMoving = true;
        }

        if (isMoving)
        {
            MovePlatformUpwards();
        }
    }

    private void MovePlatformUpwards()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;

        if (transform.position.y >= initialPosition.y + maxHeight)
        {
            isMoving = false;
        }
    }

    public void EnablePlatformInteraction()
    {
        isInteractable = true;
        InteractionUI.Instance.ShowInteraction("Press E to move platform");
    }
}
