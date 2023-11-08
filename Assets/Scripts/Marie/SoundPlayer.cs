using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    private AudioSource _audioSource;

    [SerializeField] private AudioClip jumpSfx, walkSfx, hitSfx, hurtSfx;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio(SoundFX sound)
    {
        switch (sound)
        {
            case SoundFX.Jump:
                _audioSource.PlayOneShot(jumpSfx);
                break;
            case SoundFX.Walk:
                _audioSource.PlayOneShot(walkSfx);
                break;
            case SoundFX.Hit:
                _audioSource.PlayOneShot(hitSfx);
                break;
            case SoundFX.Hurt:
                _audioSource.PlayOneShot(hurtSfx);
                break;
        }
    }

}

public enum SoundFX
{
    Jump,
    Walk,
    Hit,
    Hurt
}