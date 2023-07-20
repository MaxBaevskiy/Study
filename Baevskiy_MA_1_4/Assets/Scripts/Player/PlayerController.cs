using Helper;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private TypesOfMovement _typeOfMovement = TypesOfMovement.Square;
        [SerializeField, Range(0, 10)] private float _movementSpeed = 1;
        [SerializeField, Range(0, 10)] private float _stepSize = 5;
        [SerializeField, Range(0, 10)] private float _waitTime = 1;

        private Movement _userMovement;

        // Start is called before the first frame update
        void Start()
        {
            _userMovement = new Movement
            {
                step = _stepSize,
                speed = _movementSpeed,
                waitTime = _waitTime,
                transform = transform,
                type = _typeOfMovement,
                player = this
            };

            _userMovement.StartMoving();

        }

        void Update()
        {
            if (_typeOfMovement != _userMovement.type && _userMovement is Movement )
            {
                _userMovement.type = _typeOfMovement;
                _userMovement.speed = _movementSpeed;
                _userMovement.waitTime = _waitTime;
                _userMovement.Restart();
            }
        }
    }
}