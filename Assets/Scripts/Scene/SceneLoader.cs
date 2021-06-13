using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] GameObject fadeScreen = null;

    void Update()
    {
        if (Input.GetButtonDown("Restart"))
            Restart(1.5f);
        if (Input.GetButtonDown("Title"))
            LoadMenu(2f);
    }

    public void Startgame()
    {
        StartCoroutine(WaitToLoad(2f, "Level 1"));
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(WaitToLoad(2f, sceneName));
    }

    public void Restart(float delay)
    {
        StartCoroutine(WaitToLoad(delay, SceneManager.GetActiveScene().name));
    }

    public void LoadMenu(float delay)
    {
        StartCoroutine(WaitToLoad(delay, "Title"));
    }

    IEnumerator WaitToLoad(float delay, string scene)
    {
        Instantiate(
            fadeScreen,
            Camera.main.transform.position + Vector3.forward,
            Quaternion.identity
        );
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
