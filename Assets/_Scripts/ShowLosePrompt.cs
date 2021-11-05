using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLosePrompt : MonoBehaviour
{
    public GameObject losePrompt;
    public bool hasLost;
    public GameObject arenaLoseSpeaker;
    // public AudioSource arenaLoseSpeaker;

    // Start is called before the first frame update
    void Start()
    {
        losePrompt.SetActive(false);
        hasLost = false;
        arenaLoseSpeaker.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (hasLost == false) {
            losePrompt.SetActive(false);
        }
        if (hasLost == true) {
            losePrompt.SetActive(true);
            arenaLoseSpeaker.SetActive(true);
        }
    }

    // private void OnTriggerEnter(Collider collider) {
    //     if (collider.gameObject.tag == "PaperRecyclable")
    //     {
    //         losePrompt.SetActive(true);
    //     }
    //     if (collider.gameObject.tag == "PlasticRecyclable")
    //     {
    //         losePrompt.SetActive(true);
    //     }
    // }
}
