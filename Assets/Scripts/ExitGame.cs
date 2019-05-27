using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.Quit();
        print("The game has been 'quit'. But you are using the editor so the text is here instead.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
