using System.Collections;
using UnityEngine;

namespace Helper
{
    public class Movement
    {
        public TypesOfMovement type { get; set; }
        public float speed { get; set; }
        public float step { get; set; }
        public Transform transform { get; set; }
        public Coroutine coroutine { get; set; }
        public MonoBehaviour player { get; set; }

        private Vector3 _startPosition = Vector3.zero;
        private Animator _animator;
        private string _animationStartPath = "EverydayMotionPackFree/Mecanim/female_chair";
        private string _animationRunPath = "EverydayMotionPackFree/Mecanim/female_sprint";
        private string _animationIdlePath = "EverydayMotionPackFree/Mecanim/female_pant";

        public void StartMoving()
        {
            _animator = player.GetComponent<Animator>();

            //new LookAt().Set(GameObject.Find("chair"), transform);

            switch (type)
            {
                case TypesOfMovement.Square:
                    player.StartCoroutine(StandUpAndRun());
                    break;

            }
        }

        private IEnumerator StandUpAndRun()
        {
            _animator.SetBool("StandUp", true);


            while (_animator.IsInTransition(0) || !_animator.GetCurrentAnimatorStateInfo(0).IsName("female_idle_pant"))
            {
                yield return null;
            }

            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("female_idle_pant"))
            {
                yield return Moving(step);

                yield return Rotating(90);
                yield return Moving(step / 2);

                yield return Rotating(0);
                yield return Moving(step);

                yield return Rotating(-90);
                yield return Moving(step);

                yield return Rotating(-180);
                yield return Moving(step);

                yield return Rotating(-270);
                yield return Moving(step / 2);

                yield return Rotating(-180);
                yield return Moving(step);


                yield return Rotating(-180);

            }
        }

        private IEnumerator Moving(float step)
        {
            _animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(_animationRunPath);
            Vector3 targetPosition = transform.position + transform.forward * step;

            while (transform.position != targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

                yield return null;
            }

            _animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(_animationIdlePath);

            yield break;
        }

        private IEnumerator Rotating(float angle)
        {

            while (transform.localEulerAngles.y < angle)
            {
                transform.localRotation *= Quaternion.Euler(0, 50f * speed * Time.deltaTime, 0);

                yield return null;
            }

            transform.localRotation = Quaternion.Euler(0, angle, 0);

            yield break;
        }


    }
}
