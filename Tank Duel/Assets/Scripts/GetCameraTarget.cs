using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Cameras;

public class GetCameraTarget : NetworkBehaviour
{
    public GameObject CameraTarget;

    // Use this for initialization
    private void Start()
    {
        if (isLocalPlayer)
        {
            var CameraRig = FindObjectOfType<FreeLookCam>();
            CameraRig.SetTarget(CameraTarget.transform);
        }
    }
}