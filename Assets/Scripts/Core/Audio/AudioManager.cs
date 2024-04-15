using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource m_sfxSource;
    private AudioSource m_musicSource;

    public void PlaySFX(AudioClip clip)
    {
        m_sfxSource.PlayOneShot(clip);
    }
}
