using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class TopDownController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;

    public float visionWidth = 60;
    [Range(0f, 1f)]
    public float visionRange = 0f;

    Vector2 movement;
    Vector2 mousePos;
    Light2D visionLight;

    private void Awake()
    {;
        visionLight = transform.Find("VisionLight").GetComponent<Light2D>();
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
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
        visionLight.falloffIntensity = visionRange;
        

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
