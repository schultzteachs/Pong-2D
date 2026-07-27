using UnityEngine;
using UnityEngine.EventSystems;

public class ForceMenuControl : MonoBehaviour
{
    [SerializeField] private GameObject firstSelectedButton;

    void Start()
    {
        // This runs the exact moment the Main Menu scene finishes loading
        if (firstSelectedButton != null)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(firstSelectedButton);
        }
    }

    void Update()
    {
        // Fixes the mouse click drop issue safely without breaking scrolling
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            if (horizontal != 0 || vertical != 0)
            {
                EventSystem.current.SetSelectedGameObject(firstSelectedButton);
            }
        }
    }
}
