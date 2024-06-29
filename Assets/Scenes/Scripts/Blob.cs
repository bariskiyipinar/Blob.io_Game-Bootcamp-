using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlobIO.Game
{
    public class Blob : MonoBehaviour
    {

        public static  GameObject blobprefab;
        public static GameObject blobprefab2;



        public  void yoket()
        {
            Destroy(this.gameObject);
        }

        public void Klon()
        {
            float rastgelex = Random.Range(-30f, 30f);
            float rastgelez = Random.Range(-30f, 30f);
            Vector3 position = new Vector3(rastgelex, transform.position.y, rastgelez);

            if (blobprefab != null)
            {
                // Yeni bir Blob oluþtur ve gerekli ayarlarý yap
                GameObject blobObject = Instantiate(blobprefab, position, Quaternion.identity);
                Blob blob = blobObject.GetComponent<Blob>();
             
            }

            if (blobprefab2 != null)
            {
                // Yeni bir Blob oluþtur ve gerekli ayarlarý yap
                GameObject blobObject2 = Instantiate(blobprefab2, position, Quaternion.identity);
                Blob blob2 = blobObject2.GetComponent<Blob>();
          
            }
        }
    }
}
