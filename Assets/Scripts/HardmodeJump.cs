using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class HardmodeJump : MonoBehaviour {
    public KeyCode key;
    public int jumpForce;
    public int directionalForce;
    public HardmodeJump lastBodyPartForward;
    public float cooldownInWater;
    public float cooldownOnGround;
    public AudioClip movementSoundLand;
    public AudioClip movementSoundWater;

    public Vector3 originalPos;

    public enum MovementState
    {
        Ground,
        Water
    }

    public MovementState movementState;

    float cooldownWaterRemain;
    float cooldownGroundRemain;

    private KeyCode keyCode;
    private string controllerInputName;

    private bool onGround;
    private int forceX = 0;
    private int forceY = 200;

    private AudioSource audioSource;
    private Rigidbody rgb;

    // Use this for initialization
    void Start()
    {
        originalPos = transform.localPosition;

        rgb = gameObject.GetComponent<Rigidbody>();
        audioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        audioSource.clip = movementSoundLand;

        movementState = MovementState.Ground;
        forceY = jumpForce;

        keyCode = key;
        /*switch (key)
        {
            case "q":
                keyCode = KeyCode.Q;
                controllerInputName = "LeftTriggerWindows";
                break;
            case "w":
                keyCode = KeyCode.W;
                controllerInputName = "LeftBumperWindows";
                break;
            case "e":
                keyCode = KeyCode.E;
                controllerInputName = "RightTriggerWindows";
                break;
            case "r":
                keyCode = KeyCode.R;
                controllerInputName = "RightBumperWindows";
                break;
        }*/
    }

    bool inputDown()
    {
        return Input.GetKeyDown(keyCode); //|| (controllerInputName.Contains("Trigger") ? Input.GetAxis(controllerInputName) > 0F : Input.GetButtonDown(controllerInputName));
    }

    // Update is called once per frame
    void Update()
    {
        if (GameControl.Instance.islose || GameControl.Instance.isWin)
        {
            return;
        }
        if (lastBodyPartForward != null)
        {
            forceX = (GameContext.lastJumpedBodyPart == lastBodyPartForward.name) ? -directionalForce : directionalForce;
        }
        Vector3 force = new Vector3(forceX, forceY, 0);

        if (movementState == MovementState.Ground && GameContext.playerGroundCount > 0 && inputDown() && cooldownGroundRemain <= 0)
        {
            rgb.AddForce(force);
            cooldownGroundRemain = cooldownOnGround;

            if (movementSoundLand != null)
                audioSource.PlayOneShot(movementSoundLand, 15F);

            GameContext.lastJumpedBodyPart = name;
        }
        else if (movementState == MovementState.Water && inputDown() && cooldownGroundRemain <= 0)
        {
            rgb.AddForce(force);

            cooldownWaterRemain = cooldownInWater;
            if (movementSoundWater != null)
                audioSource.PlayOneShot(movementSoundWater, 15F);

            GameContext.lastJumpedBodyPart = name;
        }
        if (cooldownGroundRemain > 0)
        {
            cooldownGroundRemain -= Time.deltaTime;
        }
        if (cooldownWaterRemain > 0)
        {
            cooldownWaterRemain -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
            GameContext.playerGroundCount++;
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = false;
            GameContext.playerGroundCount--;
        }
    }
}
