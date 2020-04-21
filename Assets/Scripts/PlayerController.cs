using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    float xThrow, yThrow;

    [Header("General")]
    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 75f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 75f;

    
    [Tooltip("In m")][SerializeField] float xRange = 20f;
    [Tooltip("In m")][SerializeField] float yRange = 12;


    [Header("Screen-Position Parameters")]
    [SerializeField] float positionPitchFactor = -1.5f;
    [SerializeField] float positionYawFactor = 1.2f;

    [Header("Control-Throw Parameters")]
    [SerializeField] float throwPitchFactor = -20f;
    [SerializeField] float throwRollFactor = -20f;

    bool controlEnabled = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
        }
        
    }

    void OnPlayerDeath() // called by a string reference
    {
        controlEnabled = false;
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;

        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
    private void ProcessRotation()
    {
        float pitch = 0f;
        float yaw = 0f;
        float roll = 0f;


        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToThrow = yThrow * throwPitchFactor;
        pitch = pitchDueToPosition + pitchDueToThrow;

        yaw = transform.localPosition.x * positionYawFactor;

        roll = xThrow * throwRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

}
