using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class TopDownController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    // the anchor is a simple child of the player sprite, letting us ensure
    // the player is facing the right direction when rotating.
    private GameObject anchor;
    public Camera cam;

    public float visionWidth = 60;
    [Range(0f, 1f)]
    public float visionRange = 0f;
    [Range(0f, 5f)]
    public float interactionRange = 2.5f;

    public TMPro.TextMeshProUGUI interactionText;
    public GameObject read_Panel;
    public bool reading = false;

    Vector2 movement;
    Vector2 mousePos;
    Light2D visionLight;

    private void Awake()
    {
        anchor = GameObject.Find("Anchor");
        visionLight = transform.Find("VisionLight").GetComponent<Light2D>();

        // Weirdly this adds 1.47 to whatever interactionRange is, but hohum, it works
        // UPDATE - It's taking the worldspace position, so if player wakes at y8 it'll add that
        Vector3 p = anchor.transform.localPosition;
        //Debug.Log(p);
        p.y = interactionRange;
        anchor.transform.localPosition = p;
    }

    void HandleInteraction(Interactable interactable)
    {
        KeyCode key = KeyCode.E;
        KeyCode altKey = KeyCode.R;
        switch (interactable.interactionType)
        {
            case Interactable.InteractionType.Click:
                if (Input.GetKeyDown(key))
                {
                    interactable.Interact();
                }
                else if (Input.GetKeyDown(altKey))
                {
                    interactable.Interact(true);
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
        // Set the camera to follow the player, centred on them at all times.
        Vector3 camPos = transform.position;
        camPos.z = -10f;
        cam.transform.position = camPos;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        // Draw a line from the player to the mouse position - visible in scene
        Vector2 origin = new Vector2(transform.position.x, transform.position.y);
        Vector2 direction = (anchor.transform.position - transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, interactionRange);
        Debug.DrawRay(origin, direction, Color.green);
        bool successfulHit = false;

        // If it hits something w a 2d collider:
        if (hit.collider != null && hit.collider.tag != "Player")
        {
            //Debug.Log("HIT!: "+hit.collider.tag);
            // If the object is interactable, handle it.
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if(interactable != null)
            {
                HandleInteraction(interactable);
                //Debug.Log(interactable.GetDescription());
                interactionText.text = interactable.GetDescription();
                successfulHit = true;
            }
        }

        if (!successfulHit) interactionText.text = "";
        read_Panel.SetActive(reading);
        reading = false;
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

        // Draw a line betwixt the anchor and the player - this is in red so we can see both the 
        // line determining where the player is looking and the line checking for collisions.
        Debug.DrawLine(transform.position, anchor.transform.position, Color.red);
    }
}
