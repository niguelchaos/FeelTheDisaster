using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerController : MonoBehaviour
{
    public float plasticsLeft;
    public float papersLeft;
    public float firesLeft;
    public float wrongBinCount;

    public GameObject targetPaperContainer;
    public GameObject targetPlasticContainer;
    public GameObject targetFireContainer;
    public ShowWinPrompt targetShowWinPrompt;
    public ShowLosePrompt targetShowLosePrompt;

    // public WashRecyclable targetWashedRecyclable;
    // Start is called before the first frame update
    void Start()
    {
        targetPaperContainer = GameObject.Find("PaperContainer");
        targetPlasticContainer = GameObject.Find("PlasticContainer");
        targetFireContainer = GameObject.Find("FireContainer");
        targetShowWinPrompt = this.GetComponent<ShowWinPrompt>();
        targetShowLosePrompt = this.GetComponent<ShowLosePrompt>();

        plasticsLeft = 1;
        papersLeft = 1;
        wrongBinCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (plasticsLeft <= 0 && papersLeft <= 0) {
            targetShowWinPrompt.hasWon = true;
        }
        if (wrongBinCount >= 1) {
            targetShowLosePrompt.hasLost = true;
        }
    }
    // private void OnTriggerEnter(Collider collider) {
    //     // if (collider.gameObject.tag == "Player")
    //     // {
    //     //     print("Put it in the right container");
    //     // }
    //     if (targetPaperContainer.GetComponent<Collider>().gameObject.tag == "PaperRecyclable") {
    //         if (collider.gameObject.GetComponent<WashRecyclable>().isWashed == true) {
    //             recyclablesLeft--;
    //         }
    //         if (collider.gameObject.GetComponent<WashRecyclable>().isWashed == false) {
    //             Debug.Log("You haven't washed the recyclable yet! ");
    //         }
    //     }
    // }

    public void decreasePlasticsLeft() {
        plasticsLeft--;
    }
    public void decreasePapersLeft() {
        papersLeft--;
    }
    public void increaseWrongBinCount() {
        wrongBinCount++;
    }
}
