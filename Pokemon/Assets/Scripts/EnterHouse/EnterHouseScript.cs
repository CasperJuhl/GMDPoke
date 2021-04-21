using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterHouseScript : MonoBehaviour
{
    public bool isTriggered;
    public IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        isTriggered = true;
        while (isTriggered)
        {
            if (Input.GetKeyDown(KeyCode.W) == true || Input.GetKey(KeyCode.W) == true)
            {
                SceneManager.LoadScene("OaksLab");
            }
            yield return new WaitForSeconds(0);
        }
        yield break;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTriggered = false;
    }
}

