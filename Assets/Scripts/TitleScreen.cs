using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public GameObject treble, bass, titleUI; 
    public FistScript trebleScript, bassScript;
    public Image fistBump;
    public Sprite preBump, postBump;
    public string SceneName = "SampleScene";
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        trebleScript = treble.GetComponent<FistScript>();
        bassScript = bass.GetComponent<FistScript>();
        trebleScript.isTitle = true;
        bassScript.isTitle = true;
        fistBump.sprite = preBump;
    }

    // Update is called once per frame
    void Update()
    {
	distance = Vector3.Distance(treble.transform.position, bass.transform.position);
	Debug.Log(distance);
        if (distance <=.2f && distance != 0){
            StartGame();
        }
    }
    public void StartGame(){
        fistBump.sprite = postBump;
        StartCoroutine(LoadLevel());
    }
    IEnumerator LoadLevel(){
        trebleScript.startGame = false;
        bassScript.startGame = false;
        yield return new WaitForSeconds(3);
        titleUI.SetActive(false);
        SceneManager.LoadScene(SceneName);
        
    }
}
