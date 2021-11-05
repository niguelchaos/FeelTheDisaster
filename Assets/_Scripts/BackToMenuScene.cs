using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenuScene : MonoBehaviour
{
    public GameObject b2menuButton;
    // public GameObject targetLosePrompt;
    // public ShowLosePrompt targetShowLosePrompt;
    // public GameObject targetRecyclingContainers;
    // public ContainerController targetContainerController;

    // Start is called before the first frame update
    void Start()
    {
        b2menuButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToMenuScene() {
        // Use a coroutine to load the Scene in the background
        StartCoroutine(LoadMenuScene());
    }
    
    IEnumerator LoadMenuScene() {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainMenu");
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone) {
            yield return null;
        }
    }
}
