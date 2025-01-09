using UnityEngine;

public class LookAtObjectNoY : MonoBehaviour
{
    [SerializeField] private GameObject targetObject = null;
    void LateUpdate()
    {
        transform.LookAt(targetObject.transform);
        transform.Rotate(0, 180, 0);
        transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
    }
}
