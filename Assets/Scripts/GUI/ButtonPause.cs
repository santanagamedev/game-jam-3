using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPause : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] GameObject panelPause;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>(); ;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Pause()
    {
        Debug.Log(panelPause.activeSelf);
        if (panelPause.activeSelf != false)
        {
            Debug.Log("Resume + | Player canJump " + player.canJump);
            player.canJump = false;
            //panelPause.SetActive(false);
        }
    }

    public void Resume()
    {
        Debug.Log(panelPause.activeSelf);
        if (panelPause.activeSelf != true)
        {
            Debug.Log("Resume + | Player canJump " + player.canJump);
            player.canJump = true;
            //panelPause.SetActive(false);
        }
    }

}
