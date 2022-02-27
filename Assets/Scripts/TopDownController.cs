using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class TopDownController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    [SerializeField]
    private GameObject anchor;
    public Camera cam;

    public float visionWidth = 60;
    [Range(0f, 1f)]
    public float visionRange = 0f;
    [Range(0f, 5f)]
    public float interactionRange = 2.5f;

    public TMPro.TextMeshProUGUI interactionText;

    Vector2 movement;
    Vector2 mousePos;
    Light2D visionLight;

    private void Awake()
    {
        anchor = GameObject.Find("Anchor");
        visionLight = transform.Find("VisionLight").GetComponent<Light2D>();

        // Weirdly this adds 1.47 to whatever interactionRange is, but hohum, it works
        Vector3 p = anchor.transform.position;
        p.y = interactionRange;
        anchor.transform.position = p;
    }

    void HandleInteraction(Interactable interactable)
    {
        KeyCode key = KeyCode.E;
        switch (interactable.interactionType)
        {
            case Interactable.InteractionType.Click:
                if (Input.GetKeyDown(key))
                {
                    interactable.Interact();
                }
                break;
            case Interactable.InteractionType.Read:
                if (Input.GetKey(key))
                {
                    interactable.Interact();
                }
                break;
            case Interactable.InteractionType.Collect:
                // Menu Inventory system here
                break;
            default:
                throw new System.Exception("Unsupported interaction type");
        }
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        // Draw a line from the player to the mouse position?
        Vector2 origin = new Vector2(transform.position.x, transform.position.y);
        Vector2 direction = (anchor.transform.position - transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, interactionRange);
        

        bool successfulHit = false;

        // If it hits something w a 2d collider:
        if (hit.collider != null)
        {
            // If the object is interactable, handle it.
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if(interactable != null)
            {
                HandleInteraction(interactable);
                interactionText.text = interactable.GetDescription();
                successfulHit = true;
            }
        }

        if (!successfulHit) interactionText.text = "";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move the Player
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        // Modify the angle size of the vision cone.
        visionLight.pointLightInnerAngle = visionWidth;
        visionLight.pointLightOuterAngle = visionWidth;

        // Modify how far out the player sees.
        // Warning - fresh installs of Unity will rebuke this, as falloff intensity is read-only - you'll
        // have to change this in Unity itself. 
        visionLight.falloffIntensity = visionRange;
        // File is Light2D found in Runtime/2D
        // public float falloffIntensity { get => m_FalloffIntensity; set => m_FalloffIntensity = value; }


        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;


        Debug.DrawLine(transform.position, anchor.transform.position, Color.red);
    }
}
