using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PGGE
{
    public class TPCFollowTrackPosition : TPCFollow
    {
        public TPCFollowTrackPosition(Transform cameraTransform, Transform playerTransform) : base(cameraTransform, playerTransform)
        {
        }

        public override void Update()
        {
            Quaternion initialRotation = Quaternion.Euler(CameraConstants.CameraAngleOffset);

            mCameraTransform.rotation = Quaternion.RotateTowards(mCameraTransform.rotation, initialRotation, Time.deltaTime * CameraConstants.Damping);

            base.Update();
        }
    }
}
