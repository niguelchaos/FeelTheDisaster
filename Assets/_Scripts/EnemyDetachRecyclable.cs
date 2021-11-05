using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetachRecyclable : MonoBehaviour
{
    public GameObject enemy;
    public EnemyAttachRecyclable targetAttachRecyclable;
    // public bool isLeftAttached;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Player")
        {
            enemy = GameObject.Find("Robot Kyle");
            Debug.Log("name: " + this);
            Debug.Log("Milk's enemy parent: " + enemy.name);

            targetAttachRecyclable = enemy.GetComponent<EnemyAttachRecyclable>();
            targetAttachRecyclable.isLeftAttached = false;
            print("Put it in the right container");
        }
        if (collider.gameObject.tag == "Enemy")
        {

        }
    }
}
