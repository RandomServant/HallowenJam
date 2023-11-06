using UnityEngine;

public class Ghost : MonoBehaviour
{
    private float horizontal;
    private float vertical;

    private Vector3 direction;

    [SerializeField] private float speed;
    void Start()
    {
        
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw(GlobalStringVars.HORIZONTAL_AXIS);
        vertical = Input.GetAxisRaw(GlobalStringVars.VERTICAL_AXIS);

        direction = new Vector3(horizontal, vertical, 0);

        Move();
    }

    private void Move()
    {
        transform.position = transform.position + direction * speed * Time.deltaTime;
    }
}
