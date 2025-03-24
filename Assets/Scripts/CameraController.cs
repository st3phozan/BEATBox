using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public Transform levelSelectionPoint; 
    private Transform targetPosition; 
    public float transitionSpeed = 2f; 
    private bool isTransitioning = false;

    void Start()
    {
        transform.position = levelSelectionPoint.position;
        transform.rotation = levelSelectionPoint.rotation;
    }

    public void MoveToLevel(Transform planetTarget)
    {
        if (!isTransitioning)
        {
            targetPosition = planetTarget;
            StartCoroutine(TransitionToTarget());
        }
    }

    IEnumerator TransitionToTarget()
    {
        isTransitioning = true;

        while (Vector3.Distance(transform.position, targetPosition.position) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition.position, Time.deltaTime * transitionSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetPosition.rotation, Time.deltaTime * transitionSpeed);
            yield return null;
        }

        transform.position = targetPosition.position;
        transform.rotation = targetPosition.rotation;

        isTransitioning = false;

    }
}
