using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBinController : MonoBehaviour
{
    public GameObject parentController;
    public ContainerController parentControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        parentController = GameObject.Find("RecyclingContainers");
        parentControllerScript = parentController.GetComponent<ContainerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.tag == "PlasticRecyclable" || collider.gameObject.tag == "PaperRecyclable") {
            parentControllerScript.increaseWrongBinCount();
            Debug.Log("Wrong Bin");
        }
    }
}
