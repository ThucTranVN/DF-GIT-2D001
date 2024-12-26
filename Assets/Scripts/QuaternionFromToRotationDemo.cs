using UnityEngine;

public class QuaternionFromToRotationDemo : MonoBehaviour
{
    private RaycastHit RaycastHit;

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position, -transform.up, out RaycastHit, 10f))
        {
            Debug.DrawRay(RaycastHit.point, RaycastHit.normal, Color.red);
            //transform.position = RaycastHit.point + RaycastHit.normal * 1f;
            transform.rotation = Quaternion.FromToRotation(Vector3.up, RaycastHit.normal);
        }
    }
}
