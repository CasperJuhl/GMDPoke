using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterHouseScript : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.W) == true || Input.GetKey(KeyCode.W) == true)
        {
            SceneManager.LoadScene("OaksLab");
        }
    }
}
