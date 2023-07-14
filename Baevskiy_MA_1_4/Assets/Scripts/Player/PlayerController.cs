using Helper;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private TypesOfMovement _typeOfMovement = TypesOfMovement.Square;
        [SerializeField, Range(0, 10)] private float _movementSpeed = 1;
        [SerializeField, Range(0, 10)] private float _stepSize = 5;

        private Vector3 _startPosition = Vector3.zero;
        private Animator _animator;
        private Animation _animation;
        private int _animationIDstart = 13170;
        private int _animationIDrun = 14060;
        private int _animationIDidle = 14058;

        // Start is called before the first frame update
        void Start()
        {
            _animator = GetComponent<Animator>();
            _animator.SetBool("StandUp", true);

            for (int i = 0; i < _animator.runtimeAnimatorController.animationClips.Length; i++)
            {
                AnimationClip clip = _animator.runtimeAnimatorController.animationClips[i];

                Debug.Log(clip.name);
            }

        }

        void Update()
        {

            /*
            if (_animator.IsInTransition(0) && _animator.runtimeAnimatorController.GetInstanceID() == _animationIDstart)
            {
                _animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("EverydayMotionPackFree/Mecanim/female_sprint");
            }

            if (_animator.runtimeAnimatorController.GetInstanceID() == _animationIDrun)
            {
                _animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("EverydayMotionPackFree/Mecanim/female_pant");
            }
            if (_animator.runtimeAnimatorController.GetInstanceID() == _animationIDidle)
            {
                _animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("EverydayMotionPackFree/Mecanim/female_chair");
            }
            */


        }
    }
}