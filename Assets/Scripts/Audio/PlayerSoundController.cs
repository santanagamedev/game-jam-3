using UnityEngine;

public class PlayerSoundController : EntitySound
{
    [SerializeField] private AudioClip[] jumpSound;

    public void PlayJumpSound()
    {
        Debug.Log("Entra a Manager Sound");
        if (jumpSound != null && jumpSound.Length != 0)
        {
            audioSource.PlayOneShot(jumpSound[Random.Range(0, jumpSound.Length)]);
        }
    }

}
