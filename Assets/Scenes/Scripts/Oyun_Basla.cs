using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Oyun_Basla : MonoBehaviour
{
    
    [SerializeField] private GameObject resim1;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject scoretext;
    void Start()
    {
       scoretext.SetActive(false);
    }

    
   

    public void Oyun_basla()
    {
        button.SetActive(false);
        resim1.SetActive(false);
        Time.timeScale = 1.0f;
        scoretext.SetActive(true);
    }
}
