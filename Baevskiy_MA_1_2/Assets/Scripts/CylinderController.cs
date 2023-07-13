using UnityEngine;
using Lesson;

public class CylinderController : MonoBehaviour
{
    public float maxSize = 20; // max size of scaling
    public float minSize = 0; // min size of scaling
    public float step = -5f; // change step
    public float waitTime = 1; // waiting time in seconds
    private int iterator = 1; // default value for iterator
    private bool directionIteration = true; // direction of loop. true - increasing, false - decreasing.

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(new Helper().Transforms(
            TypesOfTransform.rot,
            step,
            0,
            0,
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
