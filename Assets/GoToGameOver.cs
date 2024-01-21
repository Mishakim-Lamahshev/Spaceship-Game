using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoGameOverHpTrigger : MonoBehaviour {
    [SerializeField] string sceneName;


    // Reference to the DestroyOnTrigger2D script attached to the same GameObject
    private HpManager hpManager;

    private void Start()
    {
        // Try to get the HpManager component
        hpManager = GetComponent<HpManager>();

        // Check if the component is present
        if (hpManager == null)
        {
            Debug.LogError("HpManager component not found on the same GameObject.");
        }
    }

    private void Update() {
             // Check if DestroyOnTrigger2D component is present
            if (hpManager != null)
            {
                // Check if the player is alive before triggering game over
                if (hpManager.isDead)
                {
                    transform.position = Vector3.zero;
                    SceneManager.LoadScene(sceneName);    // Input can either be a serial number or a name; here we use name.
                }
            }
            else
            {
                Debug.LogError("HpManager component not found. Cannot check HP for game over.");
            }
            
        }
    }
