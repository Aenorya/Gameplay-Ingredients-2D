using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private int _life = 3;
    private Animator _animator;
    private SoundPlayer _audioPlayer;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioPlayer = GetComponent<SoundPlayer>();
    }

    public void Hurt(int damage)
    {
        _life -= damage;
        _animator.SetTrigger("Hurt");
        _audioPlayer.PlayAudio(SoundFX.Hurt);
    }

    public void Heal(int heal)
    {
        _life += heal;
    }
}
