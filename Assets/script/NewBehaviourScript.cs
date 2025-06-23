using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;
    public float verticalLookLimit = 80f;

    private float rotationX = 0f;

    void Update()
    {
        // Kontrol gerakan karakter
        MoveCharacter();

        // Kontrol kamera hanya jika tombol kanan mouse ditekan
        if (Input.GetMouseButton(1)) // 1 adalah tombol kanan mouse
        {
            LookAround();
        }
    }

    private void MoveCharacter()
    {
        // Mendapatkan input dari keyboard
        float moveX = Input.GetAxis("Horizontal");  // A dan D, atau Panah Kiri dan Panah Kanan
        float moveZ = Input.GetAxis("Vertical");    // W dan S, atau Panah Atas dan Panah Bawah

        // Membuat vektor gerakan
        Vector3 move = new Vector3(moveX, 0f, moveZ);
        move = transform.TransformDirection(move); // Mengubah ke arah lokal

        // Memindahkan objek
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);
    }

    private void LookAround()
    {
        // Mendapatkan input mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Menghitung rotasi vertikal
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -verticalLookLimit, verticalLookLimit);

        // Menerapkan rotasi
        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}