using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    public GameObject restartButton;
    public GameObject targetLosePrompt;
    public ShowLosePrompt targetShowLosePrompt;
    public GameObject targetRecyclingContainers;
    public ContainerController targetContainerController;

    // Start is called before the first frame update
    void Start()
    {
        // restartButton = GameObject.Find("RestartButton");
        // targetLosePrompt = GameObject.Find("LoseCanvas");
        
        targetRecyclingContainers = GameObject.Find("RecyclingContainers");
        targetShowLosePrompt = targetRecyclingContainers.GetComponent<ShowLosePrompt>();
        targetContainerController = targetRecyclingContainers.GetComponent<ContainerController>();

        restartButton.SetActive(false);
        Debug.Log("Restart inactive");
    }

    // Update is called once per frame
    void Update()
    {
        if (targetShowLosePrompt.hasLost == true) {
            // Debug.Log("Restart active");
            restartButton.SetActive(true);
        }
    }

    public void RestartLevel() {
        // Use a coroutine to load the Scene in the background
        StartCoroutine(ReloadScene());
    }

    IEnumerator ReloadScene() {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name); // reloads current scene
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone) {
            yield return null;
        }
    }
}
