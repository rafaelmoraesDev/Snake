using UnityEngine;

public class CameraAdjust : MonoBehaviour
{
    void Start()
    {
        Camera.main.transform.position = new Vector3(-0.5f, -0.5f, this.transform.position.z);
    }
}
