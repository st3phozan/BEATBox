using UnityEngine;

public class FloatingBackgroundObject : MonoBehaviour
{
    [Header("Float")]
    public float floatAmplitude = 0.5f; 
    public float floatFrequency = 1f;  

    [Header("Rotation")]
    public bool rotateSlightly = false;
    public float rotationSpeed = 10f;

    public bool pulseScale = false;
    public float scaleAmplitude = 0.05f;
    public float scaleFrequency = 1.5f;

    private Vector3 startPos;
    private Vector3 originalScale;
    private Vector3 rotationAxis;

    void Start()
    {
        startPos = transform.position;
        originalScale = transform.localScale;

      
        if (rotateSlightly)
        {
            rotationAxis = new Vector3(
                Random.Range(-1f, 1f),
                Random.Range(-1f, 1f),
                Random.Range(-1f, 1f)
            ).normalized;
        }
    }

    void Update()
    {
      
        float yOffset = Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = startPos + new Vector3(0f, yOffset, 0f);

        
        if (rotateSlightly)
        {
            transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
        }

        if (pulseScale)
        {
            float scaleOffset = Mathf.Sin(Time.time * scaleFrequency) * scaleAmplitude;
            transform.localScale = originalScale + Vector3.one * scaleOffset;
        }
    }
}
