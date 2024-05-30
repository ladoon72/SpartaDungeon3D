using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    public float chackRate = 0.05f;
    private float lastCheckTime;
    public float maxCheckDistance;
    public LayerMask layerMask;

    public GameObject curInteracGameObject;
    private IIneractable curInteractable;

    public TextMeshProUGUI promptText;
    private Camera camera;


    void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {
        if (Time.time - lastCheckTime > chackRate)
        {
            lastCheckTime = Time.time;

            Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxCheckDistance, layerMask))
            {
                if (hit.collider.gameObject != curInteracGameObject)
                {
                    curInteracGameObject = hit.collider.gameObject;
                    curInteractable = hit.collider.GetComponent<IIneractable>();
                    SetPromptText();
                }
            }
            else
            {
                curInteracGameObject = null;
                curInteractable = null;
                promptText.gameObject.SetActive(false);
            }
        }
    }

    private void SetPromptText()
    {
        promptText.gameObject.SetActive(true);
        promptText.text = curInteractable.GetIneractPrompt();
    }

    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && curInteractable != null)
        {
            curInteractable.OnIteract();
            curInteracGameObject = null;
            curInteractable = null;
            promptText.gameObject.SetActive(false);
        }
    }
}
