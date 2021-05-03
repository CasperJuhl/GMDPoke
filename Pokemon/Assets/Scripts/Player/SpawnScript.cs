using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public static Vector3 playerPosition { get; set; }
    public static bool encounter { get; set; }

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    void Update()
    {

    }
}
