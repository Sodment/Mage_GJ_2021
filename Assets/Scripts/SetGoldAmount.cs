using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetGoldAmount : MonoBehaviour
{
    public Text goldText;
    void Update()
    {
        goldText.text = Economy.instance.player_money.ToString();
    }
}
