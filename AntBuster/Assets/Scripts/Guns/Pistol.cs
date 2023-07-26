using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Pistol : Guns
{
    
    public void Start()
    {
        damage = 5;
        range = 3f;
        attackSpeed = 4f;
    }
}
