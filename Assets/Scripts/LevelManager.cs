using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            NextLevel();
        }
    }

    public void NextLevel()
    {
        if(indexLevel >= 0)
        {
            SceneManager.LoadScene(indexLevel);
        }
        
    }


}
