using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class BulletRocket : BasicBullet
    {
        [SerializeField] private float speedRotation;
        [SerializeField]private float delayFly = 1;
        [SerializeField] private GameManager playersPool;

        private void Awake()
        {
            playersPool = FindObjectOfType<GameManager>();
        }

        //private new void Start()
        //{
        //    delayFly = delayFly + Time.time;
           
        //}

        void FixedUpdate()
        {
            if (delayFly > Time.deltaTime)
            {
                Transform nearestTarget = playersPool.GetNearestTarger(transform.position);
                Vector3 targetDirection = (nearestTarget.position - transform.position);
                float targetDirectionAngle = GeneralMetods.GetAngleFromVectorFloat(targetDirection);
                Debug.DrawRay(transform.position, GeneralMetods.GetVectorFromAngle(targetDirectionAngle) * 5, Color.red);
                TurnDirection(targetDirectionAngle + 90);
                Move();               
            }

            if (Time.time > lifeTime)
            {
                Destroy(gameObject);
            }
        }

        void Move ()
        {
            transform.Translate(Vector3.right * speedMovement * Time.fixedDeltaTime);
        }    

        void TurnDirection (float directionAngle)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.Euler(0f, 0f, directionAngle - 90), speedRotation * Time.fixedDeltaTime);
        }
    }
}
