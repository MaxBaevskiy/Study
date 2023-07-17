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
        private Coroutine _coroutine;
        private bool isRuning = true;

        public void StartMoving()
        {
            _animator = player.GetComponent<Animator>();
            _coroutine = player.StartCoroutine(StandUpAndRun());
        }

        private IEnumerator StandUpAndRun()
        {
            _animator.SetBool("StandUp", true);

            while (_animator.IsInTransition(0) || !_animator.GetCurrentAnimatorStateInfo(0).IsName("female_idle_pant"))
            {
                yield return null;
            }

            while (_animator.GetCurrentAnimatorStateInfo(0).IsName("female_idle_pant"))
            {
                switch (type)
                {
                    case TypesOfMovement.Square:
                        yield return SquareMoving();
                        break;
                    case TypesOfMovement.Triangle:
                        yield return TriangleMoving();
                        break;

                }

                yield return null;
            }

            yield break;
        }

        private IEnumerator SquareMoving()
        {
            yield return Moving(step);

            yield return Rotating(90);
            yield return Moving(step / 2);

            yield return Rotating(0);
            yield return Moving(step);

            yield return Rotating(270);
            yield return Moving(step);

            yield return Rotating(180);
            yield return Moving(step);

            yield return Rotating(90);
            yield return Moving(step / 2);

            yield return Rotating(180);
            yield return Moving(step);

            yield return Rotating(0);

            yield return Stop();

            yield break;
        }

        private IEnumerator TriangleMoving()
        {
            yield return Moving(step);

            yield return Rotating(90);
            yield return Moving(step / 2);

            yield return Rotating(330);
            yield return Moving(step);

            yield return Rotating(210);
            yield return Moving(step);
  
            yield return Rotating(90);
            yield return Moving(step / 2);

            yield return Rotating(180);
            yield return Moving(step);

            yield return Rotating(0);

            yield return Stop();

            yield break;
        }

        private IEnumerator Moving(float step)
        {
            _animator.SetBool("isRuning", true);
            _animator.speed = speed / 5;

            Vector3 targetPosition = transform.position + transform.forward * step;

            while (transform.position != targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

                yield return null;
            }

            _animator.SetBool("isRuning", false);

            yield break;
        }

        private IEnumerator Rotating(float angle)
        {
            while (transform.localEulerAngles.y != angle)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, angle,0), 50f * speed * Time.deltaTime);

                yield return null;
            }

            yield break;
        }

        private IEnumerator Stop()
        {
            Debug.Log("1");
            _animator.speed = 1;
            _animator.SetBool("StandUp", false);
            player.StopCoroutine(_coroutine);

            yield break;
        }


    }
}
