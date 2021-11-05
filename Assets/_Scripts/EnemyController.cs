using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // speed of enemy
    public float speed = 0.3f;
    // target bin position that enemy will move towards
    // offset just for idk maybe some randomness later 
    public Vector3 targetBinPositionOffset = new Vector3(0, 1.0f, 0);
    private Transform targetBinPosition;
    private GameObject targetBin;

    public GameObject targetRecyclingContainers;
    public ShowLosePrompt targetShowLosePrompt;

    public float firingAngle = 45.0f;
    public float gravity = 9.8f;
 
    public Transform projectile;      
    private Transform throwingHand;

    private GameObject enemy;
    private EnemyAttachRecyclable selfAttachRecyclable;

    public Animator enemyAnim;

    public bool playerSeen;
    public GameObject player;
    public Transform playerPosition;
    public bool playerInArena;
    public bool playerStandingTooClose;

    public bool playerAttackingRight;
    public bool playerAttackingLeft;

    public bool isGrounded;
    private Rigidbody enemyRb;
    public float distToGround;
    public Vector3 closestPointLocation;

    public float fireBinDist;

    public Transform leftWallPos;
    public Transform rightWallPos;
    public Transform topWallPos;
    public Transform botWallPos;
    public float leftWallDist;
    public float rightWallDist;
    public float topWallDist;
    public float botWallDist;

    public float robotHeightLimit;

    public float timer;
    public float timeLimitBeforeAdvance;
    public bool playerInAtkRange;
    public bool attacking;
    // public bool punchLeft;
    // public bool punchRight;





    // Start is called before the first frame update
    void Start()
    {
        // find the position of the firebin
        targetBin = GameObject.Find("FireContainer");
        targetBinPosition = GameObject.Find("FireContainer").transform;
        throwingHand = GameObject.Find("Right_Middle_Finger_Joint_01a").transform;
        // script is attached to this enemy
        enemy = this.transform.gameObject;
        // get reference to attachrecyclable on this enemy
        selfAttachRecyclable = enemy.GetComponent<EnemyAttachRecyclable>();
        // get reference to animation controller
        enemyAnim = GetComponent<Animator>();
        // get position of player
        playerPosition = player.transform;
        playerSeen = false;
        playerInArena = false;

        playerStandingTooClose = false;
        playerAttackingRight = false;
        playerAttackingLeft = false;
        playerInAtkRange = false;

        isGrounded = false;
        robotHeightLimit = 0.19f;
        distToGround = GetComponent<Collider>().bounds.extents.y;

        timer = 0.0f;
        timeLimitBeforeAdvance = 4;
        attacking = false;

        targetRecyclingContainers = GameObject.Find("RecyclingContainers");
        targetShowLosePrompt = targetRecyclingContainers.GetComponent<ShowLosePrompt>();

        
    }

    // Update is called once per frame
    void Update()
    {
        // Move our position a step closer to the target.
        float step = speed * Time.deltaTime; // calculate distance to move
        // range that the enemy can throw trash
        float burnRecyclableRange = 1.5f;

        if (playerSeen == false) {
            // tell animator controller same thing
            enemyAnim.SetBool("playerSeen", false);
            // take a step towards the target if enemy is too far from bin
            if (Vector3.Distance(transform.position, targetBinPosition.position) > burnRecyclableRange 
                && selfAttachRecyclable.isLeftAttached == true) {

                enemy.transform.LookAt(targetBinPosition);
                enemyAnim.SetBool("isInFirebinRange", false);
                // transform.position = Vector3.MoveTowards(transform.position, targetBinPosition.position, step);
            }
            
            // Check if the position of the cube and sphere are approximately equal.
            if (Vector3.Distance(transform.position, targetBinPosition.position) < burnRecyclableRange 
                && selfAttachRecyclable.isLeftAttached == true) {

                // stop walking
                enemyAnim.SetBool("isInFirebinRange", true);
                // detach trash
                selfAttachRecyclable.isLeftAttached = false;
                
                StartCoroutine(SimulateProjectile());
            }

            if (selfAttachRecyclable.isLeftAttached == false) {
                enemyAnim.SetBool("isLeftAttached", false);
            }
        }
        if (playerSeen == true) {
            enemyAnim.SetBool("playerSeen", true);
            // find coordinates to look at player on the y axis only
            Vector3 difference = playerPosition.position - transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            float rotationX = Mathf.Atan2(difference.z, difference.y) * Mathf.Rad2Deg;
            float rotYOffset = 16f;
            float rotationY = Mathf.Atan2(difference.x, difference.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, rotationY, 0.0f);

            // time before enemy advances
            int seconds = 0;
            timer += Time.deltaTime;
            seconds = (int)timer % 60;
            Debug.Log("seconds: " + seconds);
            
            
            // enemy.transform.LookAt(playerPosition);

            if (playerStandingTooClose == true) {
                enemyAnim.SetBool("playerStandingTooClose", true);
                enemyAnim.SetBool("advance", false);
                attacking = false;
            }
            if (playerStandingTooClose == false) {
                enemyAnim.SetBool("playerStandingTooClose", false);
            }

            if (playerAttackingRight == true) {
                enemyAnim.SetTrigger("dodgeLeft");
            }
            if (playerAttackingRight == false) {
                enemyAnim.ResetTrigger("dodgeLeft");
            }

            if (seconds >= timeLimitBeforeAdvance) {
                if (attacking == false) {
                    enemyAnim.SetBool("advance", true);
                    Debug.Log("advancing");
                }
                if (playerInAtkRange == true) {
                    enemyAnim.SetTrigger("punchRight");
                    if (playerStandingTooClose == true) {
                        enemyAnim.SetBool("advance", false);
                        attacking = true;
                        seconds = 0;
                        timer = 0;
                        Debug.Log("punched right");
                    }
                    
                    if (playerStandingTooClose == false) {
                        enemyAnim.SetBool("advance", true);
                        enemyAnim.SetTrigger("punchLeft");
                        attacking = true;
                        seconds = 0;
                        timer = 0;
                        Debug.Log("punched left");
                        // enemyAnim.SetBool("advance", false);
                    }
                    
                }
                if (playerInAtkRange == false) {
                    enemyAnim.ResetTrigger("punchRight");
                    enemyAnim.ResetTrigger("punchLeft");

                }
            }
            if (seconds <= timeLimitBeforeAdvance) {
                enemyAnim.SetBool("advance", false);
                attacking = false;
            }
        }

        if (playerInArena == false) {
            enemyAnim.SetBool("playerInArena", false);
        }
        if (playerInArena == true) {
            enemyAnim.SetBool("playerInArena", true);
        }

        // if (isGrounded == false) {
        distToGround = GetComponent<Collider>().bounds.extents.y;
        Debug.Log("Dist to ground: " + distToGround);
        
        Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
        // transform.position = distToGround;
        Vector3 closestPoint = GetComponent<Collider>().ClosestPoint(closestPointLocation);

        if (distToGround < 0.0875 || distToGround >= 0.088) {
            //put robot back on ground
            transform.position = new Vector3(transform.position.x,robotHeightLimit,transform.position.z);
        }

        if (targetShowLosePrompt.hasLost == true) {
            enemyAnim.SetBool("hasLost", true);
        }
        // }

        

    }

    void LateUpdate() {
        
        // if (playerSeen == true) {
        //     enemyAnim.SetBool("playerSeen", true);
        //     // find coordinates to look at player on the y axis only
        //     Vector3 difference = playerPosition.position - transform.position;
        //     float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //     float rotationX = Mathf.Atan2(difference.z, difference.y) * Mathf.Rad2Deg;
        //     float rotYOffset = 16f;
        //     float rotationY = Mathf.Atan2(difference.x, difference.z) * Mathf.Rad2Deg;
        //     transform.rotation = Quaternion.Euler(0.0f, rotationY, 0.0f);
            
        //     // enemy.transform.LookAt(playerPosition);
        // }
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Ground") {
            isGrounded = true;
            Debug.Log("On Ground");
        }
    }

    private void OnTriggerExit(Collider collider) {
        if (collider.gameObject.tag == "Ground") {
            isGrounded = false;
        }
    }
    
    IEnumerator SimulateProjectile()
    {
        // Short delay added before Projectile is thrown
        // yield return new WaitForSeconds(1.5f);

        // put the trash in the hand to prepare throw
        projectile = selfAttachRecyclable.leftShoulderAttachment.transform;
        Debug.Log("projectile:  " + projectile);

        // Move projectile to the position of throwing object + add some offset if needed.
        projectile.position = throwingHand.position + new Vector3(0, 0.0f, 0);
        Debug.Log("projectile:  " + projectile.position);
       
        // Calculate distance to target
        float distanceAdjustmentOffset = 1f;
        float target_Distance = Vector3.Distance(projectile.position, targetBinPosition.position) + distanceAdjustmentOffset;
 
        // Calculate the velocity needed to throw the object to the target at specified angle.
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);
 
        // Extract the X  Y componenent of the velocity
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);
 
        // Calculate flight time.
        float flightDuration = target_Distance / Vx;
   
        // Rotate projectile to face the target.
        projectile.rotation = Quaternion.LookRotation(targetBinPosition.position - projectile.position);
       
        float elapse_time = 0;
        while (elapse_time < flightDuration)
        {
            projectile.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);
            elapse_time += Time.deltaTime;
            yield return null;
        }
    }
 
}
