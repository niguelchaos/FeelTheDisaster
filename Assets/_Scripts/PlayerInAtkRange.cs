using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAtkRange : MonoBehaviour
{
    public GameObject targetEnemy;
    public EnemyController targetEnemyController;

    // Start is called before the first frame update
    void Start()
    {
        targetEnemy = GameObject.Find("Robot Kyle");
        targetEnemyController = targetEnemy.GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            targetEnemyController.playerInAtkRange = true;
        }
    }
    private void OnTriggerExit(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            targetEnemyController.playerInAtkRange = false;
            Debug.Log("Player out of range");
        }
    }
}
