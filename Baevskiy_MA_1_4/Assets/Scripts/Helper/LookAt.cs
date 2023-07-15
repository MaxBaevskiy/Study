using UnityEngine;

namespace Helper
{
    public class LookAt
    {
        public void Set(GameObject gameObject, Transform transform)
        {
            Vector3 lookAtRotation = Quaternion.LookRotation(gameObject.transform.position - transform.position).eulerAngles;
            transform.rotation = Quaternion.Euler(Vector3.Scale(lookAtRotation, new Vector3(0, 1, 0)));
        }
    }
}
