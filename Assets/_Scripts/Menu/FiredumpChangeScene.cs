using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FiredumpChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextScene() {
        // Use a coroutine to load the Scene in the background
        StartCoroutine(LoadFiredumpScene());
    }

    IEnumerator LoadFiredumpScene() {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("FireDump");
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone) {
            yield return null;
        }
    }
}
