using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearAttack : Skill
{
    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {
            HitEffect(target.transform, Vector3.up);
            PlayerCtrl player = target.GetComponent<PlayerCtrl>();
            player.CtrlHP(-damage + Random.Range(0, (int)damage));
        }
    }
}
