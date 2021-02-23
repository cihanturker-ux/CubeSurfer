using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float lerpValue;

    private void LateUpdate()
    {
        Vector3 position = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, position, lerpValue);
    }
}
