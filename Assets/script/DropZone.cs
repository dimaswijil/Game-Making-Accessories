using UnityEngine;

public class DropZone : MonoBehaviour
{
    private int objectCount = 0; // Menghitung jumlah barang yang jatuh

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grabbable")) // Memeriksa tag "Grabbable"
        {
            objectCount++;
            Debug.Log("Barang dengan tag 'Grabbable' telah jatuh. Total: " + objectCount);

            // Tambahkan logika lainnya jika perlu
            // Contoh: Efek suara, animasi, atau menghancurkan objek
        }
    }
}
