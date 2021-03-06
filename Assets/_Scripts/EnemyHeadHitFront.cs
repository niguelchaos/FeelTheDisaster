using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeadHitFront : MonoBehaviour
{
    public GameObject enemy;
    public Animator enemyAnim;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find("Robot Kyle");
        enemyAnim = enemy.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            enemyAnim.SetTrigger("hitHeadFront");
            Debug.Log("Front head hit");
        }
    }
    private void OnTriggerExit(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            enemyAnim.ResetTrigger("hitHeadFront");
            Debug.Log("Front head left");
        }
    }
}
