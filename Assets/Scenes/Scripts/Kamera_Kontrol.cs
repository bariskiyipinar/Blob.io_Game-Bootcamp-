using UnityEngine;

public class Kamera_Kontrol : MonoBehaviour
{
    public Transform playerTransform; // Oyuncunun transformu
    public Vector3 initialOffset; // Ba�lang��taki offset de�eri
    public float smoothTime = 0.3f; // Hareket yumu�atma s�resi
    private Vector3 velocity = Vector3.zero; // H�z de�i�keni (SmoothDamp i�in)

    void Start()
    {
        // Ba�lang��ta player ile kamera aras�ndaki mesafeyi hesapla
        initialOffset = transform.position - playerTransform.position;
    }

    void LateUpdate()
    {
        if (playerTransform == null)
            return;

        // Oyuncunun �u anki �l�e�ini al
        Vector3 playerScale = playerTransform.lossyScale;

        // �l�e�e g�re kamera offset de�erini ayarla
        Vector3 scaledOffset = initialOffset * playerScale.magnitude;

        // Hedef pozisyonu belirle (Oyuncunun pozisyonu + offset)
        Vector3 targetPosition = playerTransform.position + scaledOffset;

        // Yumu�ak hareket i�in SmoothDamp kullanarak kameran�n pozisyonunu g�ncelle
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
