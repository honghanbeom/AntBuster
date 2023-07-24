using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Guns
{ 
    public void Start()
    {
        damage = 12;
        range = 10f;
        attackSpeed = 5f;
    }
}
