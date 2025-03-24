using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public Transform planetTarget; 

    public void OnLevelSelected()
    {
        FindObjectOfType<CameraController>().MoveToLevel(planetTarget);
    }
}
