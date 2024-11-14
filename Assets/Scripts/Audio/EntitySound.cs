using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EntitySound : ManagerSound
{
    [SerializeField] private AudioClip[] attackSound;
    [SerializeField] private AudioClip[] reloadSound;
    [SerializeField] private AudioClip[] takeDamageSound;

    [SerializeField] private AudioClip[] deadSound;
    // Start is called before the first frame update

    public void PlayAttackSound()
    {
        Debug.Log("Entra a Manager Sound");
        if(attackSound != null && attackSound.Length != 0)
        {
            audioSource.PlayOneShot(attackSound[Random.Range(0, attackSound.Length)]);
        }
    }

    public void PlayReloadSound()
    {
        if(reloadSound != null && reloadSound.Length != 0)
        {
            audioSource.PlayOneShot(reloadSound[Random.Range(0, reloadSound.Length)]);
        }
    }

    public void PlayTakeDamage()
    {
        if(takeDamageSound != null && takeDamageSound.Length != 0)
        {
            Debug.Log("Entro");
            audioSource.PlayOneShot(takeDamageSound[Random.Range(0, takeDamageSound.Length)]);
        }
    }

    public void PlayDeadSound(GameObject entity)
    {
        if(deadSound != null && deadSound.Length != 0)
        {
            AudioSource.PlayClipAtPoint(deadSound[Random.Range(0, deadSound.Length)], entity.transform.position, 1f);
        }
    }


}
