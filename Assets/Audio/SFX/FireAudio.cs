using UnityEngine;

public class FireAudio : MonoBehaviour
{
    public AudioClip FireSFX;
    public AudioSource audioSource;
    
    public void PlayFire()
    {
        audioSource.PlayOneShot(FireSFX);
    }
}
