using UnityEngine;

public class QuaternionEulerDemo : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.rotation *= Quaternion.Euler(0f, 0f, 15f);
        }
    }
}
