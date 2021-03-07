using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoopMenager : MonoBehaviour
{
    Camera cam;
    public static GameLoopMenager instance;
    private void Awake()
    {
        if (instance != null) Destroy(instance);
        instance = this;
        cam = Camera.main;
        cam.nearClipPlane = 100.0f;
        cam.farClipPlane = 100.0f;
        StartCoroutine("Show");
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
        StartCoroutine("Hide");
    }

    IEnumerator Show()
    {
        while (cam.nearClipPlane > 0.05f)
        {
            cam.nearClipPlane -= 20.0f * Time.deltaTime;
            yield return null;
        }
        cam.nearClipPlane = 0.01f;
    }

    IEnumerator Hide()
    {
        while (cam.farClipPlane > 0.05f)
        {
            cam.farClipPlane -= 10.0f * Time.deltaTime;
            yield return null;
        }
        yield return null;
        SceneManager.LoadScene(1);
    }
}
