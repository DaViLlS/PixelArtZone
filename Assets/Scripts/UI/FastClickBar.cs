using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastClickBar : MonoBehaviour
{
    private FastClickMiniGame _fastClickMiniGame;
    [SerializeField] public Image _fastClickBorder;
    private Image _fastClickBar;

    private void Awake()
    {
        _fastClickBar = GetComponent<Image>();
        gameObject.SetActive(false);
    }

    public void SetFasClick(FastClickMiniGame fastClickMiniGame)
    {
        _fastClickMiniGame = fastClickMiniGame;
        SetMiniGame();
    }

    private void SetMiniGame()
    {
        _fastClickMiniGame._fastClickUi = this;
    }

    public void UpdateBar()
    {
        _fastClickBar.fillAmount = _fastClickMiniGame._currentClicks / _fastClickMiniGame.maxClicks;
    }
}
