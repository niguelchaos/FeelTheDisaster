using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnContainers : MonoBehaviour
{
    public GameObject plasticContainer;
    public GameObject paperContainer;
    public GameObject paperFire;
    public GameObject plasticFire;

    public float plasticBurnCount;
    public float paperBurnCount;

    public GameObject winCanvas;
    public GameObject creditsCanvas;
    public GameObject winSpeaker;

    public float destroyTime;
    // Start is called before the first frame update
    void Start()
    {
        plasticContainer = GameObject.Find("InteractablePlasticContainer");
        paperContainer = GameObject.Find("InteractablePaperContainer");
        // winCanvas = GameObject.Find("WinCanvas");
        destroyTime = 3;
        // paperFire = GameObject.Find("PaperFire");
        // plasticFire = GameObject.Find("PlasticFire");

        // paperFire.SetActive(false);
        // plasticFire.SetActive(false);
        paperBurnCount = 1;
        plasticBurnCount = 1;

        winSpeaker.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (paperBurnCount <= 0 && plasticBurnCount <= 0) {
            winCanvas.SetActive(true);
            creditsCanvas.SetActive(true);
            winSpeaker.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Plastic") {
            plasticFire.SetActive(true);
            Destroy(plasticContainer, destroyTime);
            plasticBurnCount--;
        }
        if (collider.gameObject.tag == "Paper") {
            paperFire.SetActive(true);
            Destroy(paperContainer, destroyTime);
            paperBurnCount--;
        }
    }

    // IEnumerator BurnContainer() {
    //     //Print the time of when the function is first called.
    //     Debug.Log("Started Coroutine at timestamp : " + Time.time);

    //     //yield on a new YieldInstruction that waits for 5 seconds.
    //     yield return new WaitForSeconds(5);

    //     //After we have waited 5 seconds print the time again.
    //     Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    // }
}
