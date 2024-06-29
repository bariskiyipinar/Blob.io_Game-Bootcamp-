using UnityEngine;

public class Kamera_Kontrol : MonoBehaviour
{
    public Transform playerTransform; // Oyuncunun transformu
    public Vector3 initialOffset; // Baþlangýçtaki offset deðeri
    public float smoothTime = 0.3f; // Hareket yumuþatma süresi
    private Vector3 velocity = Vector3.zero; // Hýz deðiþkeni (SmoothDamp için)

    void Start()
    {
        // Baþlangýçta player ile kamera arasýndaki mesafeyi hesapla
        initialOffset = transform.position - playerTransform.position;
    }

    void LateUpdate()
    {
        if (playerTransform == null)
            return;

        // Oyuncunun þu anki ölçeðini al
        Vector3 playerScale = playerTransform.lossyScale;

        // Ölçeðe göre kamera offset deðerini ayarla
        Vector3 scaledOffset = initialOffset * playerScale.magnitude;

        // Hedef pozisyonu belirle (Oyuncunun pozisyonu + offset)
        Vector3 targetPosition = playerTransform.position + scaledOffset;

        // Yumuþak hareket için SmoothDamp kullanarak kameranýn pozisyonunu güncelle
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
