using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    public LayerMask whatIsObstacle;

    private void OnTriggerEnter(Collider collision)
    {
        if ((whatIsObstacle.value & 1<< collision.gameObject.layer)== 1<< collision.gameObject.layer)
        {
            Object.Destroy(collision.gameObject);
        }
    }

  
}
