using UnityEngine;
using Zenject;

public class SoundManager : MonoBehaviour, ISoundManager
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;  // �������� ��� ������� ������
    [SerializeField] private AudioSource sfxSource;    // �������� ��� �������� �������� (���� �����)

    // ������������� �������� ������ � ��������� �������. ����� ������������ AudioSource.PlayClipAtPoint
    public void PlaySound(AudioClip clip, Vector3 position)
    {
        if (clip == null)
        {
            Debug.LogWarning("SoundManager: ������� ������������� ������ AudioClip");
            return;
        }
        AudioSource.PlayClipAtPoint(clip, position);
    }

    // ������������� ������� ������, ������������ � � Loop
    public void PlayMusic(AudioClip clip)
    {
        if (musicSource == null)
        {
            Debug.LogError("SoundManager: MusicSource �� ��������!");
            return;
        }
        if (clip == null)
        {
            Debug.LogWarning("SoundManager: ������� ������������� ������ AudioClip ��� ������");
            return;
        }
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    // ������������� ������� ������
    public void StopMusic()
    {
        if (musicSource != null)
        {
            musicSource.Stop();
        }
    }
}
