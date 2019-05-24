using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameObject completeLevelUI;

    private void OnTriggerEnter()
    {
        completeLevelUI.SetActive(true);
        Debug.Log("Level Completed");
    }
}
