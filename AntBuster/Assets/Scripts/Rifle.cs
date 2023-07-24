using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Guns
{
    public void Start()
    {
        damage = 7;
        range = 4f;
        attackSpeed = 3f;
    }
}
