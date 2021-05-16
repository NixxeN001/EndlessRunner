using UnityEngine;
using UnityEngine.Events;

public abstract class Pickup : MonoBehaviour
{
    float speed = 10f;
    public LayerMask whatIsPlayer;
    public UnityEvent onInteract;

    public virtual void OnTriggerEnter(Collider collision)
    {
        if ((whatIsPlayer.value & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
        {
            //Debug.Log("Player Collision");
            onInteract.Invoke();
        }
    }

    public virtual void Update()
    {
        this.transform.position = Vector3.Lerp(transform.position, transform.position - transform.forward, speed * Time.deltaTime);
    }
}
