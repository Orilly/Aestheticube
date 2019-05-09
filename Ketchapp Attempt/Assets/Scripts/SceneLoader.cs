using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int id = 1;

    void Start()
    {
        SceneManager.LoadScene(id);
    }
}

