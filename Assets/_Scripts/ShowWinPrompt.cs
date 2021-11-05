using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowWinPrompt : MonoBehaviour
{
    public GameObject winPrompt;
    public bool hasWon;

    public GameObject winSpeaker;

    // Start is called before the first frame update
    void Start()
    {
        winPrompt.SetActive(false);
        hasWon = false;
        winSpeaker.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (hasWon == true) {
            winPrompt.SetActive(true);
            winSpeaker.SetActive(true);
        }
        if (hasWon == false) {
            winPrompt.SetActive(false);
        }
    }

    // private void OnTriggerEnter(Collider collider) {
    //     // if (collider.gameObject.tag == "Player")
    //     // {
    //     //     print("Put it in the right container");
    //     // }
    //     if (collider.gameObject.tag == "PaperRecyclable")
    //     {
    //         winPrompt.SetActive(true);
    //     }
    // }
}
