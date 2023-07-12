using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        int i = 0;

        new Timer(_ =>
        {
            if (i <= 100)
            {
                i++;
            }
            else
            {
                i--;
            }

            ChangeTrasform(i * 1.5f);
            Console.WriteLine(i * 1.5f);
        }, null, 0, 2000);

        Thread.Sleep(TimeSpan.FromMinutes(1));
    }

    public void ChangeTrasform(float transfromPoint)
    {
        Console.WriteLine(transfromPoint);
        transform.localScale.Set( 1 + transfromPoint, 1 + transfromPoint, 1 + transfromPoint);
    }
}
