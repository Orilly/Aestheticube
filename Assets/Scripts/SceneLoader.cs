using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public float loadDelay = 1f;
    public int id = 1;

    void Start()
    {
        Invoke("loadScene", loadDelay);
    }

    void loadScene()
    {
        SceneManager.LoadScene(id);
    }
}

