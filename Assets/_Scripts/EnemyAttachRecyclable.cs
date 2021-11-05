using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttachRecyclable : MonoBehaviour
{
    public GameObject leftShoulderAttachment;
    public Rigidbody LAttachmentRb;
    public bool isLeftAttached = true;
    // not sure what this is for
    private GameObject attachmentSlot1;
    // Start is called before the first frame update
    void Start()
    {
        if (isLeftAttached == true) {
            // Attach the milk to the desired bone or submesh make sure its a child to the player object
            leftShoulderAttachment.transform.parent = GameObject.Find("Left_Shoulder_Joint_01").transform;
            // position
            leftShoulderAttachment.transform.localPosition = new Vector3(0f,0f,0);
            // rotation
            leftShoulderAttachment.transform.localEulerAngles = new Vector3(7f,0f,0f);
            // turn off physics for milk
            // get rb for milk
            LAttachmentRb = leftShoulderAttachment.GetComponent<Rigidbody>();
            LAttachmentRb.isKinematic = true;

            Debug.Log("Milk's enemy parent: " + leftShoulderAttachment.transform.parent.parent.parent.parent.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isLeftAttached == true) {
            // Attach the milk to the desired bone or submesh make sure its a child to the player object
            leftShoulderAttachment.transform.parent = GameObject.Find("Left_Shoulder_Joint_01").transform;
            // position
            leftShoulderAttachment.transform.localPosition = new Vector3(0f,0f,0);
            // rotation
            leftShoulderAttachment.transform.localEulerAngles = new Vector3(7f,0f,0f);
            // turn off physics for milk
            // get rb for milk
            LAttachmentRb = leftShoulderAttachment.GetComponent<Rigidbody>();
            LAttachmentRb.isKinematic = true;
        }

        if (isLeftAttached == false) {
            // Reapply physics
            LAttachmentRb = leftShoulderAttachment.GetComponent<Rigidbody>();
            LAttachmentRb.isKinematic = false;

            // remove milk from enemy
            leftShoulderAttachment.transform.SetParent(null);

        }
    }
}
