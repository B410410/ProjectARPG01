using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArrow : Skill
{
    private void OnTriggerEnter(Collider target)
    {
        if(target.tag == "Monster")
        {
            HitEffect(target.transform, Vector3.up);
            MonsterCtrl monster = target.GetComponent<MonsterCtrl>();
            monster.CtrlHP(-damage);
        }
    }
}
