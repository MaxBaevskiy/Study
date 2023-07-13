using System;
using System.Collections;
using UnityEngine;

namespace Helpers
{
    public enum TypesOfTransform
    {
        scal,
        pos,
        rot,
    }

    public class Transforms
    {
        public IEnumerator Set(
            TypesOfTransform typeOfTransform,
            float x,
            float y,
            float z,
            Transform transform,
            int iterator,
            float minStep,
            float maxStep,
            float step,
            bool directionIteration,
            float waitTime
        )
        {
            while (true)
            {
                if (iterator <= minStep)
                {
                    directionIteration = true; // Change direction to increasing, if object scale more less then minSize
                }

                if (iterator >= maxStep)
                {
                    directionIteration = false; // Change direction to decreasing, if object scale more than maxSize
                }

                if (directionIteration)
                {
                    iterator++;
                    if (typeOfTransform == TypesOfTransform.scal)
                    {
                        transform.localScale += new Vector3(x, y, z); // increase object scale
                    } else if (typeOfTransform == TypesOfTransform.pos )
                    {
                        transform.position += new Vector3(x, y, z); // change object position
                    }
                }
                else
                {
                    iterator--;
                    if (typeOfTransform == TypesOfTransform.scal)
                    {
                        transform.localScale -= new Vector3(x, y, z); // decrease object scale
                    }
                    else if (typeOfTransform == TypesOfTransform.pos)
                    {
                        transform.position -= new Vector3(x, y, z); // change object position
                    }
                }

                if (typeOfTransform == TypesOfTransform.rot)
                {
                    transform.Rotate(step, y, z, Space.Self); // rotate object. only xAxis
                }

                yield return new WaitForSeconds(waitTime); // wait for n seconds
            }
        }
    }
}