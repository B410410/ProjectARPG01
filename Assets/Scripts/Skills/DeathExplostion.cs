using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathExplostion : Skill
{
    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Monster")
        {
            HitEffect(target.transform, Vector3.up);
            MonsterCtrl monster = target.GetComponent<MonsterCtrl>();
            monster.CtrlHP(-damage);
        }
    }
    private void OnTriggerStay(Collider target)
    {
        if (target.tag == "Player" && isAction)
        {
            target.GetComponent<PlayerCtrl>().CtrlHP(health);
            isAction = false;
        }
    }
}
