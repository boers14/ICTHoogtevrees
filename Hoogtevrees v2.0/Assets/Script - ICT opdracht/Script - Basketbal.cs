using System.Collections;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    // Store the original position of the object
    private Vector3 originalPosition;

    // Threshold distance to reset position
    public float resetDistance = 10.0f;

    // Delay before resetting the object (optional)
    public float resetDelay = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Save the object's original position
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Check the distance between current position and original position
        if (Vector3.Distance(transform.position, originalPosition) > resetDistance)
        {
            // Start coroutine to reset position after a delay
            StartCoroutine(ResetObjectPosition());
        }
    }

    // Coroutine to reset the object to its original position after a delay
    IEnumerator ResetObjectPosition()
    {
        // Optional delay before resetting
        yield return new WaitForSeconds(resetDelay);

        // Reset the object's position to the original position
        transform.position = originalPosition;

        // Optionally, reset the object's velocity (if it's using physics)
        if (TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
