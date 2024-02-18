using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Effects_Player : MonoBehaviour
{ 
    public AudioSource src;
    public AudioClip sfx1, sfx2, sfx3, sfx4, sfx5;
    private void Start()
    {
        src = GetComponent<AudioSource>();
    }

    public void Walk()
    {
        src.clip = sfx1;
        src.loop = true;
        src.Play();
    }
    public void Jump()
    {
        src.clip = sfx2;
        src.loop = false;
        src.Play();

    }
    public void Checkpoint()
    {
        src.clip = sfx3;
        src.Play();

    }
    public void Death()
    {
        src.clip = sfx4;
        src.Play();
        src.loop = false;
    }
    public void Victory()
    {
        src.clip = sfx5;
        src.Play();
        src.loop = false;

    }
}