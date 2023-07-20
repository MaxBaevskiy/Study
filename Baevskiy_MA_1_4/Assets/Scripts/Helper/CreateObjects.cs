using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Helper
{
    public class CreateObjects
    {
        public List<GameObject> objectsList = new List<GameObject> { };
        public void Create(Transform transform)
        {
            GameObject cube = Object.Instantiate( GameObject.Find("chair") );
            cube.name = "chair " + objectsList.Count;
            cube.transform.position = transform.position;
            cube.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

            objectsList.Add(cube);
        }

        public void RemoveAllObjects()
        {
            for (int i = 0; i < objectsList.Count; i++)
            {
                GameObject.Destroy(objectsList[i]);
            }

            objectsList = new List<GameObject> { };
        }
    }
}
