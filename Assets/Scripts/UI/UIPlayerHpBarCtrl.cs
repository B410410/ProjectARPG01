using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIPlayerHpBarCtrl : MonoBehaviour
{
    public Image hpBarImg;
    public TextMeshProUGUI hpText;

    // Start is called before the first frame update
    void Start()
    {
        DataSystem.SetPlayerHpBarCtrl(this);
    }

    public void UpdateUI()
    {
        hpBarImg.fillAmount = DataSystem.PlayerHpPrecent();
        hpText.text = DataSystem.PlayerHpString();
    }
}
