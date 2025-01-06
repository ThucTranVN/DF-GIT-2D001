using Unity.AI.Navigation;
using UnityEngine;

public class StepsScript : MonoBehaviour
{
    private NavMeshSurface[] m_StepsSurface;
    public bool CanStep = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_StepsSurface = GetComponents<NavMeshSurface>();
        m_StepsSurface[1].enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanStep)
        {
            if(m_StepsSurface[1].isActiveAndEnabled == false)
            {
                m_StepsSurface[1].enabled = true;
            }
        }
    }
}
