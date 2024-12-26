using UnityEngine;

public class BotOrbit : MonoBehaviour
{
    public Transform Target;

    void Update()
    {
        Vector3 direction = (Target.position + new Vector3(0, 1f,0)) - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        Quaternion currentRotation = transform.localRotation;
        transform.localRotation = Quaternion.Lerp(currentRotation, rotation, Time.deltaTime);
        transform.Translate(0,0, 3 * Time.deltaTime);
    }
}
