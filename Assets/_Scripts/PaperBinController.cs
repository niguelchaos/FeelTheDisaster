using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperBinController : MonoBehaviour
{
    public GameObject parentController;
    public ContainerController parentControllerScript;

    public GameObject targetUnwashedTip;
    public GameObject targetPaperInBin;
    public GameObject targetUnscrewedCapTip;

    // Start is called before the first frame update
    void Start()
    {
        parentController = GameObject.Find("RecyclingContainers");
        parentControllerScript = parentController.GetComponent<ContainerController>();
        targetUnwashedTip = GameObject.Find("UnwashedTip");
        targetUnscrewedCapTip = GameObject.Find("UnscrewedCapTip");
        targetUnwashedTip.SetActive(false);
        targetUnscrewedCapTip.SetActive(false);

        targetPaperInBin = GameObject.Find("PaperInBinTip");
        targetPaperInBin.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.tag == "PaperRecyclable") {
            if (collider.gameObject.GetComponent<WashRecyclable>().isWashed == true) {
                Debug.Log("Paper Recycled");
                targetUnwashedTip.SetActive(false);
                targetPaperInBin.SetActive(true);
                parentControllerScript.decreasePapersLeft();
            }
            if (collider.gameObject.GetComponent<WashRecyclable>().isWashed == false) {
                Debug.Log("You haven't washed the recyclable yet! ");
                targetUnwashedTip.SetActive(true);
            }
            if (collider.gameObject.GetComponent<MilkCapAttach>().isScrewedOn == true) {
                targetUnscrewedCapTip.SetActive(true);
            }
        }
        // if(collider.gameObject.tag != "PaperRecyclable") {
        //     Debug.Log("Wow you just ruined everything ");
        // }
    }
    private void OnTriggerStay(Collider collider) {
        if(collider.gameObject.tag == "PaperRecyclable") {
            if (collider.gameObject.GetComponent<MilkCapAttach>().isScrewedOn == false) {
                targetUnscrewedCapTip.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider collider) {
        if(collider.gameObject.tag == "PaperRecyclable") {
            targetUnwashedTip.SetActive(false);
        }
        if(collider.gameObject.tag == "PlasticRecyclable") {
            targetUnscrewedCapTip.SetActive(false);
        }
        
    }

}
