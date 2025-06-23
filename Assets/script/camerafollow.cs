using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public Transform player; // Referensi ke objek player
    public Vector3 offset;   // Jarak antara kamera dan player

    void Update()
    {
        // Mengatur posisi kamera sesuai dengan posisi player + offset
        transform.position = player.position + offset;
    }
}

    
