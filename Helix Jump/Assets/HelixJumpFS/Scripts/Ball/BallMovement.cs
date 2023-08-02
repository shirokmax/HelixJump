using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BallMovement : MonoBehaviour
{
    [Header("Fall")]
    [SerializeField] private float fallHeight;
    [SerializeField] private float fallStartSpeed;
    [SerializeField] private float fallMaxSpeed;
    [SerializeField] private float fallAccelerationSpeed;

    private Animator animator;
    private float fallSpeed;
    private float floorY;

    private void Start()
    {
        animator = GetComponent<Animator>();
        enabled = false;
    }

    private void Update()
    {
        if (transform.position.y > floorY)
        {
            transform.position += Vector3.down * fallSpeed * Time.deltaTime;

            if (fallSpeed < fallMaxSpeed)
            {
                fallSpeed += fallAccelerationSpeed * Time.deltaTime;
            }
            else
            {
                fallSpeed = fallMaxSpeed;
            }
        }
        else
        {
            transform.position = new Vector3(transform.position.x, floorY, transform.position.z);      
            enabled = false;
        }
    }

    public void Jump()
    {
        animator.speed = 1;
        fallSpeed = fallStartSpeed;
    }

    public void Fall(float startFloorY)
    {
        animator.speed = 0;
        enabled = true;
        floorY = startFloorY - fallHeight;
    }

    public void Stop()
    {
        animator.speed = 0;
    }
}
