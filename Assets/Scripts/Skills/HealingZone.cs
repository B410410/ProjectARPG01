using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingZone : Skill
{
    private void OnTriggerStay(Collider target)
    {
        if (target.tag == "Player" && isAction)
        {
            HitEffect(target.transform, Vector3.up * 1.5f);
            target.GetComponent<PlayerCtrl>().CtrlHP(health);
            isAction = false;
        }
    }

}
