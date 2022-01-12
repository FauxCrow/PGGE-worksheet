using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PGGE
{
    public class TPCTopDown : TPCBase
    {
        public TPCTopDown(Transform cameraTransform, Transform playerTransform) : base(cameraTransform, playerTransform)
        {
        }

        public override void Update()
        {
            Vector3 targetPos = mPlayerTransform.position;

            targetPos.y += CameraConstants.CameraPositionOffset.y * 4;

            Vector3 position = Vector3.Lerp(mCameraTransform.position, targetPos, Time.deltaTime * CameraConstants.Damping);
            mCameraTransform.position = position;

            mCameraTransform.LookAt(mPlayerTransform.position);
        }
    }
}
