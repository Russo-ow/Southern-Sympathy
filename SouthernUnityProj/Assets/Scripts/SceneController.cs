using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
    public float timer;
    public GameObject transition;

    public void LoadScene() {
        if(timer == 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        else
            StartCoroutine(LoadSceneCoroutine(SceneManager.GetActiveScene().buildIndex));
    }

    public void LoadScene(int index) {
        if(timer == 0)
            SceneManager.LoadScene(index);
        else
            StartCoroutine(LoadSceneCoroutine(index));
    }

    public void LoadNext() {
        if(timer == 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            StartCoroutine(LoadSceneCoroutine(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadSceneCoroutine(int index) {
        transition.SetActive(true);
        yield return new WaitForSecondsRealtime(timer);
        SceneManager.LoadScene(index);
    }
}