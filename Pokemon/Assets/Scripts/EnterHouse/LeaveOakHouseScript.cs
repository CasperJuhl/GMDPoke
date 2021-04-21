using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveOakHouseScript : MonoBehaviour
{
    public bool isTriggered;
    public IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        isTriggered = true;
        while (isTriggered)
        {
            if (Input.GetKeyDown(KeyCode.S) == true || Input.GetKey(KeyCode.S) == true)
            {
                SceneManager.LoadScene("SampleScene");
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
