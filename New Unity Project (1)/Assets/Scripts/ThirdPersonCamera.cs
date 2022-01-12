using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform mPlayer;

    PGGE.TPCBase mThirdPersonCamera;

    public Vector3 mPositionOffset = new Vector3(0.0f, 2.0f, -2.5f);
    public Vector3 mAngleOffset = new Vector3(0.0f, 0.0f, 0.0f);
    public float mDamping = 1.0f;

    void Start()
    {
        // Set to GameConstants class so that other objects can use
        PGGE.CameraConstants.Damping = mDamping;
        PGGE.CameraConstants.CameraPositionOffset = mPositionOffset;
        PGGE.CameraConstants.CameraAngleOffset = mAngleOffset;

        //mThirdPersonCamera = new TPCTrack(transform, mPlayer);
        //mThirdPersonCamera = new TPCFollowTrackPosition(transform, mPlayer);
        mThirdPersonCamera = new PGGE.TPCFollowTrackPositionAndRotation(transform, mPlayer);
        //mThirdPersonCamera = new TPCTopDown(transform, mPlayer);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        mThirdPersonCamera.Update();
    }
}