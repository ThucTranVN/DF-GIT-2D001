using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public Transform Target;

    void Update()
    {
        Vector3 direction = Target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
