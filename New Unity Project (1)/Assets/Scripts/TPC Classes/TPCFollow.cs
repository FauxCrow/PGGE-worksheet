using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PGGE
{
    public abstract class TPCFollow : TPCBase
    {
        public TPCFollow(Transform cameraTransform, Transform playerTransform) : base(cameraTransform, playerTransform)
        {
        }

        public override void Update()
        {
            Vector3 forward = mCameraTransform.rotation * Vector3.forward;
            Vector3 right = mCameraTransform.rotation * Vector3.right;
            Vector3 up = mCameraTransform.rotation * Vector3.up;

            Vector3 targetPos = mPlayerTransform.position;

            Vector3 desiredPosition = targetPos + forward * CameraConstants.CameraPositionOffset.z + right * CameraConstants.CameraPositionOffset.x + up * CameraConstants.CameraPositionOffset.y;

            Vector3 position = Vector3.Lerp(mCameraTransform.position, desiredPosition, Time.deltaTime * CameraConstants.Damping);
            mCameraTransform.position = position;
        }
    }
}
