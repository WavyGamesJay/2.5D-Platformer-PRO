using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _moneyDisplayText;
    [SerializeField] private Text _controlsDisplayText;

    public void UpdateMoneyDisplay(int money) {
        _moneyDisplayText.text = "Money: $" + money;
    }

    public void ShowControls() {
        _controlsDisplayText.gameObject.SetActive(true);
    }

    public void HideControls() {
        _controlsDisplayText.gameObject.SetActive(false);
    }
}
