using UnityEngine;

public class BoxControl : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10.0f; // กำหนดความเร็วของการเคลื่อนที่
    public float bounceForce = 5.0f; // กำหนดแรงเด้งกลับ

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // รับค่า Input
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // คำนวณเวกเตอร์การเคลื่อนที่
        Vector3 move = new Vector3(moveX, 0.0f, moveZ) * speed;

        // เพิ่มแรงเคลื่อนที่
        rb.AddForce(move);
    }

    void OnCollisionEnter(Collision collision)
    {
        // คำนวณเวกเตอร์เด้งกลับ
        Vector3 bounceDirection = collision.contacts[0].normal;
        rb.AddForce(bounceDirection * bounceForce, ForceMode.Impulse);
    }
}