using UnityEngine;

public class AimBarrel : MonoBehaviour
{
    public float RotateSpeed = 10;
    public float AimDistance = 1000;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        int x = Screen.width / 2;
        int y = Screen.height / 2;

        Ray ray = Camera.main.ScreenPointToRay(new Vector3(x, y));

        Debug.DrawRay(ray.origin, ray.direction * AimDistance, Color.yellow);
        Debug.DrawRay(transform.position, transform.forward * AimDistance, Color.blue);

        //RaycastHit hit;
        Vector3 targetPoint = ray.GetPoint(AimDistance);

        AimAt(targetPoint);
    }

    protected void AimAt(Vector3 targetPoint)
    {
        var targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, RotateSpeed * Time.fixedDeltaTime);
    }
}