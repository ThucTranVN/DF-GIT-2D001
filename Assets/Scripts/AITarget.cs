using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AITarget : MonoBehaviour
{
    public Transform m_Target;
    public float m_AttackDistance;

    private NavMeshAgent m_Agent;
    private Animator m_Animator;
    private float m_Distance;
    private int m_AttackIndex = Animator.StringToHash("Attatck");
    private Vector3 m_StartingPoint;
    private bool m_PathCalculate = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        m_Animator = GetComponent<Animator>();
        m_StartingPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        m_Distance = Vector3.Distance(m_Agent.transform.position, m_Target.position);

        if(m_Distance < m_AttackDistance)
        {
            m_Agent.isStopped = true;
            m_Animator.SetBool(m_AttackIndex, true);
        }
        else
        {
            m_Agent.isStopped = false;

            if(!m_Agent.hasPath && m_PathCalculate)
            {
                m_Agent.destination = m_StartingPoint;
                m_PathCalculate = false;
            }
            else
            {
                m_Animator.SetBool(m_AttackIndex, false);
                m_Agent.destination = m_Target.position;
                m_PathCalculate = true;
            }
        }
    }
}
