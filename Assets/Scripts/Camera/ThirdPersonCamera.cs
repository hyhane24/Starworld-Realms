using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour
{
    public float positionSmoothTime = 1f;
    public float rotationSmoothTime = 1f;
    public float positionMaxSpeed = 50f;
    public GameObject targetObj;
    private Transform target;

    //Vector3 offset;

    protected Vector3 currentPositionCorrectionVelocity;
    protected Quaternion quaternionDeriv;

    void Start()
    {
        if (targetObj != null)
        {
            //offset = transform.position - targetObj.transform.position;
            target = targetObj.transform;
        }
    }

	void LateUpdate ()
	{
        if (target != null)
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.position, ref currentPositionCorrectionVelocity, positionSmoothTime, positionMaxSpeed, Time.deltaTime);
            //transform.rotation = Quaternion.Euler(0, Mathf.LerpAngle(transform.eulerAngles.y, target.transform.eulerAngles.y, Time.deltaTime * rotationSmoothTime), 0);

            var targForward = target.forward;
            transform.rotation = QuaternionUtil.SmoothDamp(transform.rotation, Quaternion.LookRotation(targForward, Vector3.up), ref quaternionDeriv, rotationSmoothTime);

            //Vector3 desiredPosition = targetObj.transform.position + offset;
            //transform.position = desiredPosition;
        }
    }
}
