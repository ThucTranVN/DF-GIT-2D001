using UnityEngine;

public class QuaternionInverseDemo : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.rotation = Quaternion.Inverse(transform.rotation);
        }
    }
}
