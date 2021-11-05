using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashRecyclable : MonoBehaviour
{
    public GameObject targetWashedPrompt;
    public bool isWashed;
    // Start is called before the first frame update
    void Start()
    {
        // targetWashedPrompt = GameObject.Find("WashedPrompt");
        isWashed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWashed == true) {
            targetWashedPrompt.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Water") {
            isWashed = true;
        }
    }
}
