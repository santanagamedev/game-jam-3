using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamplePlayer : MonoBehaviour
{
    [SerializeField] private float healt;
    [SerializeField] private DamageTransition damageEffect;
    [SerializeField] private PlayerLowFuelEffect lowFuelEffect;
    public bool lowFuel = false;
    public float durationEffect = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        healt = 100f;
        damageEffect = transform.GetComponent<DamageTransition>();
    }

    // Update is called once per frame
    void Update()
    {
        if(lowFuel == true){
            LowFuel();
            lowFuel = false;
        }
    }

    public void LowFuel()
    {
        lowFuelEffect.ActivateLowFuelEffect();
    }

    public void Damage(float daño)
    {
        Debug.Log($"Recibio daño de {daño}");
        damageEffect.Damaged(daño);
        healt = healt <= daño ? 0 : healt - daño;
    }


}
