using UnityEngine;
using Zenject;

public class SoundManager : MonoBehaviour, ISoundManager
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;  // Источник для фоновой музыки
    [SerializeField] private AudioSource sfxSource;    // Источник для звуковых эффектов (если нужно)

    // Воспроизводит звуковой эффект в указанной позиции. Можно использовать AudioSource.PlayClipAtPoint
    public void PlaySound(AudioClip clip, Vector3 position)
    {
        if (clip == null)
        {
            Debug.LogWarning("SoundManager: Попытка воспроизвести пустой AudioClip");
            return;
        }
        AudioSource.PlayClipAtPoint(clip, position);
    }

    // Воспроизводит фоновую музыку, устанавливая её в Loop
    public void PlayMusic(AudioClip clip)
    {
        if (musicSource == null)
        {
            Debug.LogError("SoundManager: MusicSource не назначен!");
            return;
        }
        if (clip == null)
        {
            Debug.LogWarning("SoundManager: Попытка воспроизвести пустой AudioClip для музыки");
            return;
        }
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    // Останавливает фоновую музыку
    public void StopMusic()
    {
        if (musicSource != null)
        {
            musicSource.Stop();
        }
    }
}
