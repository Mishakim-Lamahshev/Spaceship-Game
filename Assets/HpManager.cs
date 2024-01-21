using UnityEngine;
using TMPro;

public class HpManager : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the damage to this object")]
    [SerializeField] string triggeringTag;

    [Tooltip("Health points of the object until it is destroyed")]
    [SerializeField] public int HP = 3;

    public bool isDead = false;

    [SerializeField] private TextMeshPro hpText;  // Serialized field for TextMeshPro - Text

    private void Start()
    {
        // Check if the TextMeshPro - Text component is present
        if (hpText != null)
        {
            // Update the UI text with the initial HP value
            UpdateHPText();
        }
        else
        {
            Debug.LogError("TextMeshPro - Text component not assigned in the Inspector.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggeringTag && enabled)
        {
            if (HP > 1)
            {
                HP--;
                Debug.Log("Current HP: " + HP);

                // Update the UI text with the new HP value
                UpdateHPText();

                return;
            }
            else
            {
                isDead = true;
            }
        }
    }

    private void UpdateHPText()
    {
        if (hpText != null)
        {
            hpText.text = "HP: " + HP;
        }
    }

    private void Update()
    {
        /* Just to show the enabled checkbox in Editor */
    }
}
