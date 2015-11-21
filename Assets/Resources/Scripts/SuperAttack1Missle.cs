using UnityEngine;
using System.Collections;

public class SuperAttack1Missle : Projectile {

    public override void EnemyHit()
    {
        Debug.Log("sdgfsedfg");
        GameObject SuperAttackRadius = Instantiate(Resources.Load("Prefab/Player/SuperAttack/1e"), transform.position, Quaternion.identity) as GameObject;
        base.EnemyHit();
    }
}
