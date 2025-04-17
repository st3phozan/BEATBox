using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class introUI : MonoBehaviour
{
    public GameObject introUIGO, calibUI, treble, bass;
    public float distance;
    public Image fistBump;
    public Sprite preBump, postBump;    // Start is called before the first frame update
    void Start()
    {
        fistBump.sprite = preBump;
    }


    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(treble.transform.position, bass.transform.position);

            if (distance <=.2f && distance!=0){
                RunCalib();
            
        }
}

    
    public void RunCalib(){
fistBump.sprite = postBump;
StartCoroutine(ActivateCalib());
	
}
IEnumerator ActivateCalib(){
yield return new WaitForSeconds(3);
introUIGO.SetActive(false);
	calibUI.SetActive(true);
}
}
