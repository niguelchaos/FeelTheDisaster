using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecycleNextScene : MonoBehaviour
{
    public GameObject nextSceneButton;
    public GameObject targetWinPrompt;
    public ShowWinPrompt targetShowWinPrompt;
    public GameObject targetRecyclingContainers;
    public ContainerController targetContainerController;

    // Start is called before the first frame update
    void Start()
    {
        targetRecyclingContainers = GameObject.Find("RecyclingContainers");
        targetShowWinPrompt = targetRecyclingContainers.GetComponent<ShowWinPrompt>();
        targetContainerController = targetRecyclingContainers.GetComponent<ContainerController>();

        nextSceneButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (targetShowWinPrompt.hasWon == true) {
            // Debug.Log("Restart active");
            nextSceneButton.SetActive(true);
        }
    }

    public void NextScene() {
        // Use a coroutine to load the Scene in the background
        StartCoroutine(LoadFiredumpScene());
    }

    IEnumerator LoadFiredumpScene() {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Firedump");
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone) {
            yield return null;
        }
    }
}
