using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozenBreath : Skill
{
    private void OnTriggerStay(Collider target)
    {
        if (target.tag == "Monster" && isAction)
        {
            target.GetComponent<MonsterCtrl>().CtrlHP(-damage);
            isAction = false;
        }
    }
}
