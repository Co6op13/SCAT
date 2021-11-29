using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class EnemyLianaData : MonoBehaviour, iHP, iActivation
    {
        [SerializeField] private bool isActive;
        [SerializeField] internal Transform head;
        [SerializeField] private int maxHP;
        [SerializeField] internal float lianaLength;
        [SerializeField] internal float speedMovemeth;
        [SerializeField] internal Transform[] playersTransform;
        [SerializeField] private GameManager playersPool;

        [Space(5)]
        private Vector3 targetDirection;
        private float targetDirectionAngle;
        private Vector3 movePosition;
        private Vector3 targetPosition = Vector3.zero;
        [SerializeField] internal Transform target;
        private float direxctionX; // if player to the left -1 else +1

        private void Awake()
        {
            playersPool = FindObjectOfType<GameManager>();
        }
        public int GetMaxHP()
        {
            return (maxHP);
        }


        private void FixedUpdate()
        {
            if (isActive)
            {
                ///////// нужно переделать чтобы не постоянно сканировал а раз в секунду например
                /// need change. to get nearest Target not everytime
                Transform nearestTarget = playersPool.GetNearestTarger(transform.position);
                targetDirection = (nearestTarget.position - transform.position).normalized;
                targetDirectionAngle = GeneralMetods.GetAngleFromVectorFloat(targetDirection);
                movePosition = GetMovePostiion(targetDirection, nearestTarget.position);
                MoveHead(movePosition, targetDirectionAngle);
            }
        }

        private Vector3 GetMovePostiion(Vector3 directionToTarget, Vector3 playerPosition)
        {

            if (transform.position.x > playerPosition.x)
                direxctionX = -1;
            else
                direxctionX = +1;

            float catetA = playerPosition.y - transform.position.y;

            if (Mathf.Abs(catetA) > lianaLength - 1)
                catetA = lianaLength - directionToTarget.x * direxctionX;

            float catetB = Mathf.Sqrt(lianaLength * lianaLength - catetA * catetA);

            targetPosition = new Vector3((catetB * direxctionX), catetA, 0f);

            if (transform.position.y - lianaLength + 1 > playerPosition.y)
                targetPosition = new Vector3(targetPosition.x, targetPosition.y * -1, 0f);

            Debug.DrawLine(transform.position, targetPosition + transform.position, Color.yellow);

            return (targetPosition + transform.position);

        }
        private void MoveHead(Vector3 moveDirection, float directionAngle)
        {
            head.transform.eulerAngles = new Vector3(0f, 0f, directionAngle);
            head.transform.position = Vector3.MoveTowards(head.position, moveDirection,
                speedMovemeth * Time.fixedDeltaTime);
        }

        public void ActivationObject()
        {
            isActive = true;
        }
    }
}