using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDodgeTopLeft : MonoBehaviour
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
            enemyAnim.SetTrigger("dodgeTopLeft");
            Debug.Log("dodging top left");
        }
    }
    private void OnTriggerExit(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            enemyAnim.ResetTrigger("dodgeTopLeft");
            Debug.Log("finished top dodging left");
        }
    }
}
