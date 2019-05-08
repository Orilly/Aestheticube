using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter()
    {
        gameManager.CompleteLevel();
        Debug.Log("Level Completed");
    }
}
