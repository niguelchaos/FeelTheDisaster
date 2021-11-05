using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasticBinController : MonoBehaviour
{
    public GameObject parentController;
    public ContainerController parentControllerScript;
    public GameObject targetPlasticInBin;
    
    // Start is called before the first frame update
    void Start()
    {
        parentController = GameObject.Find("RecyclingContainers");
        parentControllerScript = parentController.GetComponent<ContainerController>();
        targetPlasticInBin = GameObject.Find("PlasticInBinTip");
        targetPlasticInBin.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.tag == "PlasticRecyclable") {

            Debug.Log("Plastic recycling o wow");
            targetPlasticInBin.SetActive(true);
            parentControllerScript.decreasePlasticsLeft();
            // if (collider.gameObject.GetComponent<WashRecyclable>().isWashed == true) {
                
            // }
            // if (collider.gameObject.GetComponent<WashRecyclable>().isWashed == false) {
            //     Debug.Log("You haven't washed the recyclable yet! ");
            // }
        }
        // if(GetComponent<Collider>().gameObject.tag != "PlasticRecyclable") {
        //     Debug.Log("Wow you just ruined everything ");
        // }
    }
}
