using UnityEngine;

public class TileShakeAndDestroy : MonoBehaviour
{
    public float shakeDuration = 1f;
    public float shakeIntensity = 0.1f;

    private Vector3 originalPosition;
    private bool isShaking = false;

    private void Start()
    {
        originalPosition = transform.localPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            StartCoroutine(ShakeAndDestroy());
        }
    }

    private System.Collections.IEnumerator ShakeAndDestroy()
    {
        isShaking = true;
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            transform.localPosition = originalPosition + (Vector3)Random.insideUnitCircle * shakeIntensity;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPosition;
        Destroy(gameObject);
    }
}
