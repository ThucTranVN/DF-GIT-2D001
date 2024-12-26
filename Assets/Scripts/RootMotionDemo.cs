using UnityEngine;

public class RootMotionDemo : MonoBehaviour
{
    [SerializeField]
    private Animator m_Animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            m_Animator.SetBool("IsMoving", true);
        }
        else
        {
            m_Animator.SetBool("IsMoving", false);
        }
    }
}
