using UnityEngine;

public class QuaternionSlerpDemo : MonoBehaviour
{
    public Transform Red;
    public Transform Blue;
    [Range(0.0f, 1.0f)]
    public float SlerpValue;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Slerp(Red.rotation , Blue.rotation, SlerpValue);
    }
}
