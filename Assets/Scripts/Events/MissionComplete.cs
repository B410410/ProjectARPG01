using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionComplete : MonoBehaviour
{
    public void EndEvent()
    {
        //遊戲結束的操作面板
        DataSystem.ShowUpGameOverPanel(true, "~ MISSION COMPLETE ~");
    }
}
