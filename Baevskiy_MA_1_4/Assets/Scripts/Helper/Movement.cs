using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Helper
{
    public class Movement
    {
        public TypesOfMovement type { get; set; }
        public float speed { get; set; }
        public float step { get; set; }
        public float waitTime { get; set; }
        public Transform transform { get; set; }
        public MonoBehaviour player { get; set; }

        private Vector3 _startPosition = Vector3.zero;
        private Animator _animator;
        private Coroutine _coroutine;
        private Coroutine _restartCoroutine;
        private bool isRuning = true;
        private CreateObjects _createObjects = new CreateObjects();

        public void StartMoving()
        {
            if (_coroutine is Coroutine)
            {
                player.StopCoroutine(_coroutine);
            }

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
                    case TypesOfMovement.Hexagon:
                        yield return HexMoving();
                        break;
                    case TypesOfMovement.Star:
                        yield return StarMoving();
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
            _createObjects.Create(transform);

            yield return new WaitForSeconds(waitTime);

            yield return Rotating(0);
            yield return Moving(step);
            _createObjects.Create(transform);

            yield return new WaitForSeconds(waitTime);

            yield return Rotating(270);
            yield return Moving(step);
            _createObjects.Create(transform);

            yield return new WaitForSeconds(waitTime);

            yield return Rotating(180);
            yield return Moving(step);
            _createObjects.Create(transform);

            yield return new WaitForSeconds(waitTime);

            yield return Rotating(90);
            yield return Moving(step / 2);

            yield return Stop();

            yield break;
        }

        private IEnumerator TriangleMoving()
        {
            yield return Moving(step);

            yield return Rotating(90);
            yield return Moving(step / 2);
            _createObjects.Create(transform);

            yield return new WaitForSeconds(waitTime);

            yield return Rotating(330);
            yield return Moving(step);
            _createObjects.Create(transform);

            yield return new WaitForSeconds(waitTime);

            yield return Rotating(210);
            yield return Moving(step);
            _createObjects.Create(transform);

            yield return new WaitForSeconds(waitTime);

            yield return Rotating(90);
            yield return Moving(step / 2);

            yield return Stop();

            yield break;
        }

        private IEnumerator HexMoving()
        {
            yield return Moving(step);

            yield return Rotating(60);
            yield return Moving(step);
            yield return new WaitForSeconds(waitTime);
            _createObjects.Create(transform);

            yield return Rotating(0);
            yield return Moving(step);
            yield return new WaitForSeconds(waitTime);
            _createObjects.Create(transform);

            yield return Rotating(300);
            yield return Moving(step);
            yield return new WaitForSeconds(waitTime);
            _createObjects.Create(transform);

            yield return Rotating(240);
            yield return Moving(step);
            yield return new WaitForSeconds(waitTime);
            _createObjects.Create(transform);

            yield return Rotating(180);
            yield return Moving(step);
            yield return new WaitForSeconds(waitTime);
            _createObjects.Create(transform);

            yield return Rotating(120);
            yield return Moving(step);
            yield return new WaitForSeconds(waitTime);
            _createObjects.Create(transform);

            yield return Stop();

            yield break;
        }

        private IEnumerator StarMoving()
        {
            yield return Moving(step);

            yield return Rotating(54f);
            yield return Moving(step);
            yield return new WaitForSeconds(waitTime);
            _createObjects.Create(transform);

            yield return Rotating(342f);
            yield return Moving(step);
            yield return new WaitForSeconds(waitTime);
            _createObjects.Create(transform);

            yield return Rotating(270f);
            yield return Moving(step);
            yield return new WaitForSeconds(waitTime);
            _createObjects.Create(transform);

            yield return Rotating(198.1f);
            yield return Moving(step);
            yield return new WaitForSeconds(waitTime);
            _createObjects.Create(transform);

            yield return Rotating(126f);
            yield return Moving(step);
            yield return new WaitForSeconds(waitTime);
            _createObjects.Create(transform);

            yield return Moving(step);
            yield return new WaitForSeconds(waitTime);
            _createObjects.Create(transform);

            yield return LookAt(_createObjects.objectsList[0]);
            yield return MovingTo(_createObjects.objectsList[0].transform.position);

            yield return LookAt(_createObjects.objectsList[1]);
            yield return MovingTo(_createObjects.objectsList[1].transform.position);

            yield return Rotating(90f);
            yield return Moving(step);

            yield return new WaitForSeconds(waitTime);
            _createObjects.Create(transform);

            yield return LookAt(_createObjects.objectsList[0]);
            yield return MovingTo(_createObjects.objectsList[0].transform.position);

            yield return LookAt(_createObjects.objectsList[1]);
            yield return MovingTo(_createObjects.objectsList[1].transform.position);

            yield return Rotating(332f);

            yield return Moving(step);
            yield return new WaitForSeconds(waitTime);
            _createObjects.Create(transform);

            yield return LookAt(_createObjects.objectsList[2]);
            yield return MovingTo(_createObjects.objectsList[2].transform.position);

            yield return Rotating(270f);
            yield return Moving(step);
            yield return new WaitForSeconds(waitTime);
            _createObjects.Create(transform);

            yield return LookAt(_createObjects.objectsList[3]);
            yield return MovingTo(_createObjects.objectsList[3].transform.position);

            yield return LookAt(_createObjects.objectsList[4]);
            yield return MovingTo(_createObjects.objectsList[4].transform.position);

            yield return Rotating(234f);
            yield return Moving(step);
            yield return new WaitForSeconds(waitTime);
            _createObjects.Create(transform);

            yield return LookAt(_createObjects.objectsList[3]);
            yield return MovingTo(_createObjects.objectsList[3].transform.position);

            yield return LookAt(_createObjects.objectsList[4]);
            yield return MovingTo(_createObjects.objectsList[4].transform.position);

            yield return Stop();

            yield break;
        }

        private IEnumerator Moving(float stepSize)
        {
            Vector3 targetPosition = transform.position + transform.forward * stepSize;

            yield return Run(targetPosition);
            yield break;
        }

        private IEnumerator MovingTo(Vector3 targetPosition)
        {
            yield return Run(targetPosition);
            yield break;
        }

        private IEnumerator Run(Vector3 targetPosition)
        {
            _animator.SetBool("isRuning", true);
            _animator.speed = speed / 5;

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
            Quaternion targetRotation = transform.rotation;
            targetRotation = Quaternion.AngleAxis(angle, new Vector3(0, 1, 0));

            while (targetRotation.eulerAngles.y != transform.eulerAngles.y)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, angle, 0), 50f * speed * Time.deltaTime);

                yield return null;
            }

            yield break;
        }

        private IEnumerator Stop()
        {
            yield return LookAt(GameObject.Find("chair"));

            yield return MovingTo(_startPosition); 
            yield return Rotating(0);

            _animator.speed = 1;
            _animator.SetBool("StandUp", false);
            player.StopCoroutine(_coroutine);

            transform.position = _startPosition; // normilize position values.

            _coroutine = player.StartCoroutine(StandUpAndRun());

            yield break;
        }

        private IEnumerator LookAt(GameObject gameObject)
        {
            Vector3 lookAtRotation = Quaternion.LookRotation(gameObject.transform.position - transform.position).eulerAngles;
            float startRotY = transform.eulerAngles.y;
            float endRotY = 0;

            while (startRotY != endRotY)
            {
                startRotY = transform.eulerAngles.y;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(Vector3.Scale(lookAtRotation, new Vector3(0, 1, 0))), 50f * speed * Time.deltaTime);
                endRotY = transform.eulerAngles.y;

                yield return null;
            }

            yield break;
        }

        public void Restart()
        {
            player.StopCoroutine(_coroutine);
            _restartCoroutine = player.StartCoroutine(ReturnToStart());

            _createObjects.RemoveAllObjects();
        }

        public IEnumerator ReturnToStart()
        {
            yield return Stop();

            player.StopCoroutine(_restartCoroutine);

            yield break;
        }

    }
}
