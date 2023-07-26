using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Guns
{
    public void Start()
    {
        damage = 10;
        range = 10f;
        attackSpeed = 3f;
    }
}
