﻿using UnityEngine;
using System.Collections;

public class PlayerMissle : Projectile
{
    float shotSpeed = 2;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector3(0, Time.deltaTime * shotSpeed, 0));
    }
}
