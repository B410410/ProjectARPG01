using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionComplete : MonoBehaviour
{
    public void EndEvent()
    {
        //�C���������ާ@���O
        DataSystem.ShowUpGameOverPanel(true, "~ MISSION COMPLETE ~");
    }
}
