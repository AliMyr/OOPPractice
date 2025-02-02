using UnityEngine;

public interface ISoundManager
{
    void PlaySound(AudioClip clip, Vector3 position);
    void PlayMusic(AudioClip clip);
    void StopMusic();
}
