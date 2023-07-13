using Lesson;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float maxSize = 10; // max size of scaling
    public float minSize = 0; // min size of scaling
    public float step = 2f; // change step
    public float waitTime = 1; // waiting time in seconds
    private int iterator = 1; // default value for iterator
    private bool directionIteration = true; // direction of loop. true - increasing, false - decreasing.

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(new Helper().Transforms(
            TypesOfTransform.pos,
            0,
            0,
            step,
            transform,
            iterator,
            minSize,
            maxSize,
            step,
            directionIteration,
            waitTime
         )); // Start loop
    }
}
