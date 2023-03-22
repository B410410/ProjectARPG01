using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBGMSliderCtrl : MonoBehaviour
{
    public void BGMSlider(float vol)
    {
        DataSystem.SetBGMVol(vol);
    }
}
