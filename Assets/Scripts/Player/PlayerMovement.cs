using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Ship Movement")]
    [SerializeField]
    private float yawTorque = 100f;
    [SerializeField]
    private float pitchTorque = 100f;
    [SerializeField]
    private float rollTorque = 100f;
    [SerializeField]
    private float thrust = 100f;
    [SerializeField]
    private float upThrust = 50f;
    [SerializeField]
    private float strafeThrust = 50f;
    [SerializeField,Range(0.001f,0.999f)]
    private float thrustGlideReduction = 0.5f;
    [SerializeField, Range(0.001f, 0.999f)]
    private float upDownGlideReduction = 0.111f;
    [SerializeField, Range(0.001f, 0.999f)]
    private float leftRightGlideReduction = 0.111f;
    float glide = 0f;
    float verticalGlide = 0f;
    float horizontalGlide = 0f;

    [Header("Nitro")]
    [SerializeField]
    private float maxBoostTank = 2f;
    [SerializeField]
    private float BoostDeprecation = 0.1f;
    [SerializeField]
    private float boostRechargeRate = 0.5f;
    [SerializeField]
    private float boostMultiplier = 5f;
    public bool nitro = false;
    public float currentBoost;


    Rigidbody rb;

    private float thrust1D;
    private float strafe1D;
    private float upDown1D;
    private float roll1D;
    private Vector2 pitchYaw;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentBoost = 0;
        //Cursor.lockState = CursorLockMode.Locked;

    }

    void FixedUpdate()
    {
        if(UIManager.isPaused){
            //Cursor.lockState=CursorLockMode.None;
        }else{
            //Cursor.lockState = CursorLockMode.Locked;
        }
        Boosting();
        HandleMovement();
    }
    void Boosting()
    {
        if(nitro && currentBoost > 0f)
        {
            currentBoost -= BoostDeprecation;
            if(currentBoost <= 0f)
            {
                nitro = false;
            }
        }
        else
        {
            if(currentBoost < maxBoostTank)
            {
                currentBoost += boostRechargeRate;
            }
        }
    }

    void HandleMovement()
    {
        rb.AddRelativeTorque(Vector3.back * roll1D * rollTorque * Time.deltaTime);
        rb.AddRelativeTorque(Vector3.right *Mathf.Clamp( -pitchYaw.y,-1f,1f) * pitchTorque * Time.deltaTime);
        rb.AddRelativeTorque(Vector3.up * Mathf.Clamp( pitchYaw.x,-1f,1f) * yawTorque * Time.deltaTime);

        if(thrust1D >0.1f || thrust1D < -0.1f)
        {
            float currentThrust = thrust;
            if (nitro)
            {
                currentThrust = thrust * boostMultiplier;
            }
            else
            {
                currentThrust = thrust;
            }
            rb.AddRelativeForce(Vector3.forward * thrust1D * currentThrust * Time.deltaTime);
            glide = thrust;
        }
        else
        {
            rb.AddRelativeForce(Vector3.forward * glide * Time.deltaTime);
            glide *= thrustGlideReduction;
        }

        //Up down movement
        if (upDown1D > 0.1f || upDown1D < -0.1f)
        {
            rb.AddRelativeForce(Vector3.up * upDown1D * upThrust * Time.fixedDeltaTime);
            verticalGlide = upDown1D * upThrust;
        }
        else
        {
            rb.AddRelativeForce(Vector3.up * verticalGlide * Time.fixedDeltaTime);
            verticalGlide *= upDownGlideReduction;
        }
        //STRAFE
        if (strafe1D > 0.1f || strafe1D < -0.1f)
        {
            rb.AddRelativeForce(Vector3.right * strafe1D * upThrust * Time.fixedDeltaTime);
            horizontalGlide = strafe1D * strafeThrust;
        }
        else
        {
            rb.AddRelativeForce(Vector3.right * horizontalGlide * Time.fixedDeltaTime);
            horizontalGlide *= leftRightGlideReduction;
        }
    }
    #region Input Methods
    public void Thrust(InputAction.CallbackContext context)
    {
        thrust1D = context.ReadValue<float>();
    }
    public void Strafe(InputAction.CallbackContext context)
    {
        strafe1D = context.ReadValue<float>();
    }
    public void UpDown(InputAction.CallbackContext context)
    {
        upDown1D = context.ReadValue<float>();
    }
    public void Roll(InputAction.CallbackContext context)
    {
        roll1D = context.ReadValue<float>();
    }
    public void PitchYaw(InputAction.CallbackContext context)
    {
        pitchYaw = context.ReadValue<Vector2>();
    }
    public void Nitro(InputAction.CallbackContext context)
    {
        nitro = context.performed;
    }
    #endregion

   
}
