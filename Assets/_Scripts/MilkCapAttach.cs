using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkCapAttach : MonoBehaviour
{
    public GameObject milkcap;
    public Rigidbody milkcapRb;
    public bool isScrewedOn = true;
    // Start is called before the first frame update
    void Start()
    {
        if (isScrewedOn == true) {
            // Attach the milkcap to the desired bone or submesh make sure its a child to the player object
            milkcap.transform.parent = GameObject.Find("InteractableMilk").transform;
            // position
            milkcap.transform.localPosition = new Vector3(0f,0.2f,0.015f);
            // rotation
            milkcap.transform.localEulerAngles = new Vector3(50f,0f,0f);
            // turn off physics for milkcap
            // get rb for milkcap
            milkcapRb = milkcap.GetComponent<Rigidbody>();
            milkcapRb.isKinematic = true;

            Debug.Log("Milkcap's milk: " + milkcap.transform.parent.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isScrewedOn == true) {
            // Attach the milkcap to the desired bone or submesh make sure its a child to the player object
            milkcap.transform.parent = GameObject.Find("InteractableMilk").transform;
            // position
            milkcap.transform.localPosition = new Vector3(0f,0.2f,0.015f);
            // rotation
            milkcap.transform.localEulerAngles = new Vector3(50f,0f,0f);
            // turn off physics for milkcap
            // get rb for milkcap
            milkcapRb = milkcap.GetComponent<Rigidbody>();
            milkcapRb.isKinematic = true;
        }

        if (isScrewedOn == false) {
            // Reapply physics
            milkcapRb = milkcap.GetComponent<Rigidbody>();
            milkcapRb.isKinematic = false;

            // remove milkcap from milk carton
            milkcap.transform.SetParent(GameObject.Find("InteractableRecyclables").transform);

        }
    }

    // public void setIsScrewedOnToFalse(bool newIsScrewedOn) {
    //     isScrewedOn = false;
    // }
}
