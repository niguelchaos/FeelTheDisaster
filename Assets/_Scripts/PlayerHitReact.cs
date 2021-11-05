using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitReact : MonoBehaviour
{
    public GameObject targetSelfLightObject;
    public GameObject targetDirectionalLightObject;
    public GameObject targetOrangeLightObject;
    public GameObject targetGreenLightObject;
    public GameObject targetBlueLightObject;

    public Light targetSelfLight;
    public Light targetDirectionalLight;
    public Light targetOrangeLight;
    public Light targetGreenLight;
    public Light targetBlueLight;
    public float recoverTimer;
    public int recoverSeconds;
    public int currentHurtSeconds;
    public bool isHurt;
    public int hitpoints;

    
    // Start is called before the first frame update
    void Start()
    {
        targetSelfLightObject = GameObject.Find("SelfLight");
        targetDirectionalLightObject = GameObject.Find("Directional Light");
        targetOrangeLightObject = GameObject.Find("OrangeLight");
        targetGreenLightObject = GameObject.Find("GreenLight");
        targetBlueLightObject = GameObject.Find("BlueLight");

        targetSelfLight = targetSelfLightObject.GetComponent<Light>();
        targetDirectionalLight = targetDirectionalLightObject.GetComponent<Light>();
        targetOrangeLight = targetOrangeLightObject.GetComponent<Light>();
        targetGreenLight = targetGreenLightObject.GetComponent<Light>();
        targetBlueLight = targetBlueLightObject.GetComponent<Light>();

        currentHurtSeconds = 0;
        isHurt = false;
        recoverSeconds = 4;
        hitpoints = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHurt == true) {
            recoverTimer += Time.deltaTime;
            currentHurtSeconds = (int)recoverTimer % 60;
            if (currentHurtSeconds >= recoverSeconds) {
                hurtTimeReset();
                isHurt = false;
            }
        }
        if (isHurt == false) {
            hurtTimeReset();
        }
        
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "EnemyArm") {
                if (isHurt == false) {
                    if (hitpoints == 3) {
                    targetDirectionalLightObject.SetActive(false);
                    targetSelfLight.intensity = 0.7f;
                    hitpoints--;
                }
                else if (hitpoints == 2) {
                    targetOrangeLightObject.SetActive(false);
                    targetSelfLight.intensity = 0.4f;
                    hitpoints--;
                }
                else if (hitpoints == 1) {
                    targetGreenLightObject.SetActive(false);
                    targetSelfLight.intensity = 0.2f;
                    hitpoints--;
                }
            isHurt = true;
            hurtTimeReset();
            }
        }
    }

    public void hurtTimeReset() {
        recoverTimer = 0;
        currentHurtSeconds = 0;
    }
}
