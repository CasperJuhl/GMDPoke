﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterHouseScript : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
    }
}