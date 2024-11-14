using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonEffetSound : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip overSound;
    // Start is called before the first frame update
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(audioSource != null && overSound != null)
        {
            audioSource.PlayOneShot(overSound);
        }
        
    }
}
