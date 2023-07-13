using System.Collections;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    public float maxStep = 10; // max step of scaling
    public float minStep = 0; // min step of scaling
    public float step = 1.5f; // change step
    public float waitTime = 1; // waiting time in seconds
    private int iterator = 1; // default value for iterator
    private bool directionIteration = true; // direction of loop. true - increasing, false - decreasing.
    private bool isEnableAnimate = true; // Enable animation
    private Coroutine coroutine;
    private IEnumerator numerator;

    private Vector3 initialScale;

    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
        numerator = new Helpers.Transforms().Set(
            Helpers.TypesOfTransform.scal, // transform type
            step, // x
            step, // y
            step, // z
            transform, // object transform
            iterator,
            minStep,
            maxStep,
            step,
            directionIteration,
            waitTime
         );
        coroutine = StartCoroutine(numerator); // Start loop
    }
    void Update()
    {
        // Stop/start animation
        if (Input.GetKeyDown("space"))
        {
            if (!isEnableAnimate)
            {
                coroutine = StartCoroutine(numerator);
                isEnableAnimate = true;
            }
            else
            {
                StopCoroutine(coroutine);
                isEnableAnimate = false;
            }
        }

        // Reset all
        if (Input.GetKeyDown(KeyCode.Return))
        {
            transform.localScale = initialScale;
            directionIteration = true;
            isEnableAnimate = true;
            iterator = 1;

            numerator = new Helpers.Transforms().Set(
                Helpers.TypesOfTransform.scal, // transform type
                step, // x
                step, // y
                step, // z
                transform, // object transform
                iterator,
                minStep,
                maxStep,
                step,
                directionIteration,
                waitTime
             );

            StopCoroutine(coroutine);
            coroutine = StartCoroutine(numerator);
        }
    }
}
