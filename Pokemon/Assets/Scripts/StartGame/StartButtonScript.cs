using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonScript : MonoBehaviour
{
    private AudioManager audio;
    public float fadeout;
    // Start is called before the first frame update
    void Start()
    {
        audio = FindObjectOfType(typeof(AudioManager)) as AudioManager;
    }
        // Update is called once per frame
    void Update()
    {
        audio.sounds[0].volume = audio.sounds[0].volume - fadeout;
    }

    public void fadeOut()
    {
        while (audio.sounds[0].source.volume != 0)
        {
            audio.sounds[0].source.volume = audio.sounds[0].volume - fadeout;
        }
        return;
    }
}
