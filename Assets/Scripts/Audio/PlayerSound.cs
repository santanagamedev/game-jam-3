using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] private EntitySound managerSound;
    [SerializeField] private bool attack;
    [SerializeField] private bool reload;
    [SerializeField] private bool takeDamage;
    // Start is called before the first frame update
    void Start()
    {
        managerSound = GetComponent<EntitySound>();
    }

    // Update is called once per frame
    void Update()
    {
        if(attack)
        {
            attack = false;
            managerSound.PlayAttackSound();
        }

        if(reload)
        {
            reload = false;
            managerSound.PlayReloadSound();
        }

        if(takeDamage)
        {
            takeDamage = false;
            managerSound.PlayTakeDamage();
        }


    }
}
