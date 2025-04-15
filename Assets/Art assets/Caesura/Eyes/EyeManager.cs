using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EyeManager : MonoBehaviour
{
    [Header("Setup Settings")]
    public GameObject EyeLED;
    public GameObject[,] LeftEye = new GameObject[8, 8];
    public GameObject[,] RightEye = new GameObject[8, 8];
    public Vector3 leftEyePosition;
    public Vector3 rightEyePosition;
    public int eyeSize = 8;
    public Vector3 spacing = new Vector3(0f, 0f, 0f);
    public float eyeElementScale = 0.5f;
    public Color LeftEyeColor = Color.cyan;
    public Color RightEyeColor = Color.magenta;
    public bool shouldColorEyes = false;

    [Header("Animation Settings")]
    public Texture2D[] spriteSheets;
    public int frameIndex = 0;
    public int currentAnimation = 0;
    public float animationSpeed = 12;
    public bool isPlaying = false;
    private float frameTimer = 0f;

    [Header("Play Animation From Inspector")]
    public bool inspectorToggle = false;
    public int toggleAnimation = 1;
    
    void InstantiateEyes()
    {
        for (int x = 0; x < eyeSize; x++)
        {
            for (int y = 0; y < eyeSize; y++)
            {
                LeftEye[x, y] = Instantiate(EyeLED);
                LeftEye[x, y].transform.SetParent(transform);
                LeftEye[x, y].transform.localScale = new Vector3(eyeElementScale, eyeElementScale, eyeElementScale);
                RightEye[x, y] = Instantiate(EyeLED);
                RightEye[x, y].transform.SetParent(transform);
                RightEye[x, y].transform.localScale = new Vector3(eyeElementScale, eyeElementScale, eyeElementScale);
            }
        }
        SpaceEyes();
    }

    void SpaceEyes()
    {
        for (int x = 0; x < eyeSize; x++)
        {
            for (int y = 0; y < eyeSize; y++)
            {
                LeftEye[x, y].transform.localPosition = leftEyePosition + new Vector3(x * spacing.x / 100f, y * spacing.y / 100f, 0f);
                RightEye[x, y].transform.localPosition = rightEyePosition + new Vector3(x * spacing.x / 100f, y * spacing.y / 100f, 0f);
            }
        }
    }

    public void ColorEyes()
    {
        for (int x = 0; x < eyeSize; x++)
        {
            for (int y = 0; y < eyeSize; y++)
            {
                LeftEye[x, y].gameObject.GetComponent<EyeElement>().SetColor(LeftEyeColor);
                RightEye[x, y].gameObject.GetComponent<EyeElement>().SetColor(RightEyeColor);
            }
        }
    }

    public void SetEyeColor(Color left, Color right)
    {
        LeftEyeColor = left;
        RightEyeColor = right;
        shouldColorEyes = true;
    }
    
    void SetFrame(int frame, GameObject[,] eye, bool reflect = false)
    {
        Texture2D currAnim = spriteSheets[currentAnimation];
        for (int y = 0; y < eyeSize; y++)
        {
            for (int x = 0; x < eyeSize; x++)
            {
                int reflectedX = reflect ? (eyeSize - 1) - x : x;
                int pixelX = frameIndex * 8 + x;
                int pixelY = 7-y;
                bool isOn = currAnim.GetPixel(pixelX, pixelY).grayscale > 0.5f;
                eye[reflectedX, y].GetComponent<EyeElement>().SetActive(isOn);
            }
        }
    }

    void StopPlaying()
    {
        isPlaying = false;
    }
    public void PlayAnimation(int animation)
    {
        currentAnimation = animation;
        frameTimer = 0f;
        frameIndex = 0;
        isPlaying = true;
    }

    void Start()
    {
        InstantiateEyes();
        StartCoroutine(DelayedStart(0.1f));
    }

    IEnumerator DelayedStart(float delay)
    {
        yield return null;
        StopPlaying();
        PlayAnimation(0);
        shouldColorEyes = true;
    }

    // Update is called once per frame
    void Update()
    {
        frameTimer = isPlaying ? frameTimer + Time.deltaTime : frameTimer;
        if (frameTimer >= 1.0/animationSpeed)
        {
            frameTimer = 0f;
            int numFrames = Mathf.FloorToInt(spriteSheets[currentAnimation].width / eyeSize);
            if (frameIndex + 1 < numFrames)
            {
                frameIndex++;
            }
            else
            {
                StopPlaying();
            }
            SetFrame(frameIndex, LeftEye, true);
            SetFrame(frameIndex, RightEye, false);
        }

        if (inspectorToggle)
        {
            inspectorToggle = false;
            PlayAnimation(toggleAnimation);
        }

        if (shouldColorEyes)
        {
            shouldColorEyes = false;
            ColorEyes();
        }
    }

    void OnDrawGizmos()
    {
        if (Application.isPlaying) return;
        for (int x = 0; x < eyeSize; x++)
        {
            for (int y = 0; y < eyeSize; y++)
            {
                Gizmos.color = Color.cyan;
                Gizmos.DrawSphere(transform.position + leftEyePosition + new Vector3(x * spacing.x / 100f, y * spacing.y / 100f, 0f), 0.5f * (eyeElementScale / eyeSize));
                Gizmos.color = new Color(147 / 255.0f, 112 / 255.0f, 219 / 255.0f, 1);
                Gizmos.DrawSphere(transform.position + rightEyePosition + new Vector3(x * spacing.x / 100f, y * spacing.y / 100f, 0f), 0.5f * (eyeElementScale / eyeSize));
            }
        }

    }
}
