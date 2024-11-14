using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private int indexLevel = -1;

    public
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void NextLevel()
    {
        if(indexLevel >= 0)
        {
            SceneManager.LoadScene(indexLevel);
        }
        
    }


}
