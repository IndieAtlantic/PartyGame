using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
    }
        public float FollowSpeed = 2f;
        public Transform Target;

        private void Update()
        {
            Vector3 newPosition = Target.position;
            newPosition.z = -10;
            newPosition.y = 2;
            transform.position = Vector3.Slerp(transform.position, newPosition, FollowSpeed * Time.deltaTime);
        }
    }

