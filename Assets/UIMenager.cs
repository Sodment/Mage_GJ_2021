using UnityEngine;

public class UIMenager : MonoBehaviour
{
    public void HideObject(GameObject objectToHide)
    {
        objectToHide.SetActive(false);
    }

    public void ShowObject(GameObject objectToShow)
    {
        objectToShow.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Continue()
    {
        Time.timeScale = 1;
    }
}

