using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDodgeLeft : MonoBehaviour
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
        if (collider.gameObject.tag == "PlayerLeftHand" || collider.gameObject.tag == "PlayerRightHand") {
            targetEnemyController.playerAttackingRight = true;
            Debug.Log("dodging left");
        }
    }
    private void OnTriggerExit(Collider collider) {
        if (collider.gameObject.tag == "PlayerLeftHand" || collider.gameObject.tag == "PlayerRightHand") {
            targetEnemyController.playerAttackingRight = false;
            Debug.Log("finished dodging");
        }
    }
}
