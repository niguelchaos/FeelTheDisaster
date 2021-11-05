using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkCapDetach : MonoBehaviour
{
    public GameObject milk;
    public MilkCapAttach targetMilkCapAttach;
    bool handInRange;
    // Start is called before the first frame update
    void Start()
    {
        milk = GameObject.Find("InteractableMilk");
        targetMilkCapAttach = milk.GetComponent<MilkCapAttach>();
        handInRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            handInRange = true;
        }
        
    }
    private void OnTriggerExit(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            handInRange = false;
        }
    }

    public void triggerDetach(bool newIsScrewedOn) {
        if (handInRange == true) {
            targetMilkCapAttach.isScrewedOn = false;
        }
    }

    public void debugTriggerDetach() {
        targetMilkCapAttach.isScrewedOn = false;
    }
}
