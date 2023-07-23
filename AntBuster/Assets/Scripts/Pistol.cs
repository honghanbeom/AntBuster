using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Pistol : Guns
{
    private void Start()
    {
        damages = 5f;
        range = 4f;
        attackSpeed = 2f;
    }
}
