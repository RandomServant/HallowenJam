using UnityEngine;

public class Ghost : MonoBehaviour
{
    private float horizontal;
    private float vertical;

    private Vector3 direction;

    [SerializeField] private float speed;

    private bool isFacingRight = true;

    void Update()
    {
        horizontal = Input.GetAxisRaw(GlobalStringVars.HORIZONTAL_AXIS);
        vertical = Input.GetAxisRaw(GlobalStringVars.VERTICAL_AXIS);

        direction = new Vector3(horizontal, vertical, 0);

        Flip();
        Move();
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void Move()
    {
        transform.position = transform.position + direction * speed * Time.deltaTime;
    }
}
