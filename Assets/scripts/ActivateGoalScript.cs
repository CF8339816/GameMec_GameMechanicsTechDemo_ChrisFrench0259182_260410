using TMPro;
using UnityEngine;

public class ActivateGoalScript : MonoBehaviour
{
    [Header("Settings")]
    public GameObject ExitGoal;
    
    public string interactKey = "E";

    [Header("UI Reference")]
    public GameObject popupUI;
    public TextMeshProUGUI popupText;

    private bool isPlayerNear = false;

    void Start()
    {
        if (popupUI != null) popupUI.SetActive(false);
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    void Interact()
    {



       ExitGoal.SetActive(true);
        popupUI.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            if (popupUI != null)
            {
                popupText.text = "Press [" + interactKey + "] to Interact";
                popupUI.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            if (popupUI != null) popupUI.SetActive(false);
        }
    }
}