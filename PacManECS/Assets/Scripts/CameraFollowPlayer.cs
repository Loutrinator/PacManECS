﻿using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform cameraTarget;
    public float smoothedSpeed = 10.0f;
    public Vector3 dist;
    public Transform lookTarget;

    private void FixedUpdate() {
        if (lookTarget == null) return;
        Vector3 distancePos = cameraTarget.position + dist;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, distancePos, smoothedSpeed * Time.fixedDeltaTime);
        transform.position = smoothedPos;
        transform.LookAt(lookTarget.position);
    }
}
