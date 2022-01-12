using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PGGE
{
    public abstract class TPCBase
    {
        protected Transform mCameraTransform;
        protected Transform mPlayerTransform;

        public Transform cameraTransform
        {
            get
            {
                return mCameraTransform;
            }
        }
        public Transform playerTransform
        {
            get
            {
                return mPlayerTransform;
            }
        }

        public TPCBase(Transform cameraTransform, Transform playerTransform)
        {
            mCameraTransform = cameraTransform;
            mPlayerTransform = playerTransform;
        }

        public abstract void Update();
    }
}
