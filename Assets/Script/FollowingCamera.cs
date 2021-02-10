using UnityEngine;

/// <summary>
/// The camera added this script will follow the specified object.
/// The camera can be moved by left mouse drag and mouse wheel.
/// </summary>
[ExecuteInEditMode, DisallowMultipleComponent]
public class FollowingCamera : MonoBehaviour
{
    public GameObject target; // an object to follow
    public Vector3 offset; // offset form the target object

    [SerializeField] private float distance = 7.0f; // distance from following object
    [SerializeField] private float polarAngle = 20.0f; // angle with y-axis
    [SerializeField] private float azimuthalAngle = 270.0f; // angle with x-axis

    [SerializeField] private float minDistance = 3.0f;
    [SerializeField] private float maxDistance = 20.0f;
    [SerializeField] private float minPolarAngle = 30.0f;
    [SerializeField] private float maxPolarAngle = 80.0f;
    [SerializeField] private float mouseXSensitivity = 5.0f;
    [SerializeField] private float mouseYSensitivity = 5.0f;
    [SerializeField] private float scrollSensitivity = 5.0f;

    void LateUpdate()
    {
        updateAngle(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        if (Input.GetMouseButton(0))
        {

        }
        updateDistance(Input.GetAxis("Mouse ScrollWheel"));

        var lookAtPos = target.transform.position + offset;
        updatePosition(lookAtPos);
        transform.LookAt(lookAtPos);
    }

    void updateAngle(float x, float y)
    {
        if (Input.GetMouseButton(0))
        {
        }
        else
        {
            x = azimuthalAngle - x * mouseXSensitivity;
            azimuthalAngle = Mathf.Repeat(x, 360);
            y = polarAngle + y * mouseYSensitivity;
            polarAngle = Mathf.Clamp(y, minPolarAngle, maxPolarAngle);
        }

    }

    void updateDistance(float scroll)
    {
        scroll = distance - scroll * scrollSensitivity;
        distance = Mathf.Clamp(scroll, minDistance, maxDistance);
    }

    void updatePosition(Vector3 lookAtPos)
    {
        //多分ここらへんでCameraの座標いじってる
        var da = azimuthalAngle * Mathf.Deg2Rad;
        var dp = polarAngle * Mathf.Deg2Rad;
        transform.position = new Vector3(
            lookAtPos.x + distance * Mathf.Sin(dp) * Mathf.Cos(da),
            lookAtPos.y + distance * Mathf.Cos(dp),
            lookAtPos.z + distance * Mathf.Sin(dp) * Mathf.Sin(da));
    }
}