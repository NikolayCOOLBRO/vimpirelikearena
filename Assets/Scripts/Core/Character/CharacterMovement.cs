using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VampireLike.Core.Characters
{
    public class CharacterMovement : IMoving
    {
        public void Move(Vector3 direction, float speed, Transform transform)
        {
            var currentPostion = transform.position;

            var directionVector3 = new Vector3(direction.x, 0f, direction.z);

            var newPostion = currentPostion + directionVector3 * speed * Time.deltaTime;

            transform.position = newPostion;
        }
    }
}