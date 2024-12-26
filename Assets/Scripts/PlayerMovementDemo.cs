using UnityEngine;

public class PlayerMovementDemo : MonoBehaviour
{
    [SerializeField]
    private float m_RotationSpeed;
    [SerializeField]
    private float m_JumpHeight;
    [SerializeField]
    private float m_JumpSpeed;
    [SerializeField]
    private CharacterController m_CharacterController;
    [SerializeField]
    private Animator m_Animator;

    [SerializeField]
    private float m_JumpButtonGracePeriod;
    private float? m_LastGroundedTime;
    private float? m_JumpButtonPressedTime;

    private float m_Gravity;
    private float m_HorizontalInput;
    private float m_VerticalInput;
    private bool m_IsJumping;
    private bool m_IsGrounded;

    void Awake()
    {
        m_Animator = GetComponent<Animator>();
        m_CharacterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        m_HorizontalInput = Input.GetAxis("Horizontal");
        m_VerticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(m_HorizontalInput, 0, m_VerticalInput);
        float inputMagnitude = Mathf.Clamp01(moveDirection.magnitude);
        if (Input.GetKey(KeyCode.LeftControl))
        {
            inputMagnitude /= 2;
        }
        m_Animator.SetFloat("InputMagnitude", inputMagnitude, 0.05f, Time.deltaTime);
        moveDirection.Normalize();

        m_Gravity += Physics.gravity.y * Time.deltaTime;

        if (m_CharacterController.isGrounded)
        {
            m_LastGroundedTime = Time.time;
        }

        if (Input.GetButtonDown("Jump"))
        {
            m_JumpButtonPressedTime = Time.time;
        }

        if (Time.time - m_LastGroundedTime <= m_JumpButtonGracePeriod)
        {
            m_Gravity = -0.5f;
            m_Animator.SetBool("IsGround", true);
            m_IsGrounded = true;
            m_Animator.SetBool("IsJumping", false);
            m_IsJumping = false;
            m_Animator.SetBool("IsFalling", false);

            if (Time.time - m_JumpButtonPressedTime <= m_JumpButtonGracePeriod)
            {
                m_Gravity = m_JumpHeight;
                m_Animator.SetBool("IsJumping", true);
                m_IsJumping = true;
                m_JumpButtonPressedTime = null;
                m_LastGroundedTime = null;
            }
        }
        else
        {
            m_CharacterController.stepOffset = 0;
            m_Animator.SetBool("IsGround", false);
            m_IsGrounded = false;
            if ((m_IsJumping && m_Gravity < 0) || m_Gravity < -2)
            {
                m_Animator.SetBool("IsFalling", true);
            }
        }


        if (moveDirection != Vector3.zero)
        {
            m_Animator.SetBool("IsMoving", true);
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, m_RotationSpeed * Time.deltaTime);
        }
        else
        {
            m_Animator.SetBool("IsMoving", false);
        }

        if (m_IsGrounded == false)
        {
            Vector3 velocity = moveDirection * inputMagnitude * m_JumpSpeed;
            velocity.y = m_Gravity;
            m_CharacterController.Move(velocity * Time.deltaTime);
        }
    }

    private void OnAnimatorMove()
    {
        if (m_IsGrounded)
        {
            Vector3 velocity = m_Animator.deltaPosition;
            velocity.y = m_Gravity * Time.deltaTime;
            m_CharacterController.Move(velocity);
        }
    }
}
