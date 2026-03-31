using UnityEngine;
using TMPro; // Required for the popup text

public class InteractableObject : MonoBehaviour
{
    [Header("Settings")]
    public GameObject prefabToSpawn;
    public Transform spawnLocation;
    public string interactKey = "E"; 

    [Header("UI Reference")]
    public GameObject popupUI; 
    public TextMeshProUGUI popupText;

    private bool isPlayerNearby = false;

    void Start()
    {
        if (popupUI != null) popupUI.SetActive(false);
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E)) 
        {
            Interact();
        }
    }

    void Interact()
    {
        
        Instantiate(prefabToSpawn, spawnLocation.position, spawnLocation.rotation);

        
        popupUI.SetActive(false);
        Destroy(gameObject); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
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
            isPlayerNearby = false;
            if (popupUI != null) popupUI.SetActive(false);
        }
    }
}