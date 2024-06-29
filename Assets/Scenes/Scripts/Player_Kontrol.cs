using System.Collections;
using BlobIO.Game;
using UnityEngine;

public class Player_Kontrol : MonoBehaviour
{
    private float hiz = 3f;
    public float growthRate = 0.15f; // Daha d���k bir b�y�me oran�
    public float growthDuration = 5f; // Daha uzun bir b�y�me s�resi
    private Score m_ScoreManager; // Score y�neticisi referans�
    private int m_CurrentScore = 0; // Mevcut puan
    public GameObject bitis;
    private AudioSource ses;


    void Start()
    {
        m_ScoreManager = FindObjectOfType<Score>(); // Score y�neticisini bul
      ses=GetComponent<AudioSource>();
    }

    void Update()
    {
        float dikeyhareket = Input.GetAxis("Vertical");
        float yatayhareket = Input.GetAxis("Horizontal");
        Vector3 hareket = new Vector3(yatayhareket, 0, dikeyhareket);

        Hareket(hareket);
    }

    private void Hareket(Vector3 hareket)
    {
        transform.position += hiz * hareket * Time.deltaTime;
    }

    void OnTriggerEnter(Collider temas)
    {
        if (temas.gameObject.CompareTag("Blob") || temas.gameObject.CompareTag("Blob2"))
        {
            Blob blob = temas.gameObject.GetComponent<Blob>();
            if (blob != null)
            {
                blobFonk(blob);
                ses.Play();
            }
        }
    }

    public void blobFonk(Blob blob)
    {
        StartCoroutine(BuyumeRutini()); // B�y�me rutini ba�lat�l�r
        blob.Klon(); // Yeni blob olu�tur
        blob.yoket(); // Orijinal blobu yok et

        // Her 10 puan i�in puan ekleyelim
        m_CurrentScore += 10;
        m_ScoreManager.SetScore(m_CurrentScore);
    }

    private IEnumerator BuyumeRutini()
    {
        Vector3 initialScale = transform.localScale;
        Vector3 targetScale = initialScale * (1 + growthRate);
        float elapsedTime = 0f;

        while (elapsedTime < growthDuration)
        {
            transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / growthDuration);
            elapsedTime += Time.deltaTime; // Zaman� Time.deltaTime ile artt�r
            yield return null;
        }

        transform.localScale = targetScale;
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Engel")
        {
            Destroy(this.gameObject);
            bitis.SetActive(true);
           
        }
    }
}
