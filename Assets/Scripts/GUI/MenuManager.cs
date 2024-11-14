using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPrincipal;
    [SerializeField] private GameObject menuCreditos;
    // Start is called before the first frame update
    void Start()
    {
        MenuPrincipal();
    }

    // Update is called once per frame

    public void MenuPrincipal()
    {
        if (menuPrincipal != null)
        {
            menuPrincipal.SetActive(true);
        }
        if (menuCreditos != null)
        {
            menuCreditos.SetActive(false);
        }

    }

    public void MenuCreditos()
    {
        if (menuPrincipal != null)
        {
            menuPrincipal.SetActive(false);
        }
        if (menuCreditos != null)
        {
            menuCreditos.SetActive(true);
        }
    } 
}
