using UnityEngine;
using UnityEngine.UI;

public class UIMenager : MonoBehaviour
{
    public static UIMenager instance;
    public Image healthBar;
    private void Start()
    {
        instance = this;
    }

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

    public void UpdateHealthBar(float value)
    {
        healthBar.fillAmount = value;
    }

    public void RepairTower()
    {
        if (Economy.instance.player_money >= 50)
        {
            Economy.instance.player_money -= 50;
            TowerHP.instance.GetDMG(-20);
        }
    }

}

