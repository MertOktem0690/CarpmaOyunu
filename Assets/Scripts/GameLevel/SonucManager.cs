using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class SonucManager : MonoBehaviour
{
    [SerializeField]
    private Image sonucImage;

    [SerializeField]
    private Text dogruText, yanlisText, puanText;

    [SerializeField]
    private GameObject tekrarOynaBtn, menuyeDonBtn;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip audioClick;

    float sureTimer;
    bool sonucAcilsinmi;

    public GameObject gameManager;

    private void OnEnable()
    {
        sureTimer = 0;
        sonucAcilsinmi = true;

        dogruText.text = "";
        yanlisText.text = "";
        puanText.text = "";

        tekrarOynaBtn.GetComponent<RectTransform>().localScale = Vector3.zero;
        menuyeDonBtn.GetComponent<RectTransform>().localScale = Vector3.zero;


        StartCoroutine(SonucAcRoutine());
    }

    IEnumerator SonucAcRoutine()
    {
        while(sonucAcilsinmi)
        {
            sureTimer += 0.1f;
            sonucImage.fillAmount = sureTimer;

            yield return new WaitForSeconds(0.1f);

            if(sureTimer>=1)
            {
                sureTimer = 1;
                sonucAcilsinmi = false;

                dogruText.text = gameManager.GetComponent<GameManager>().dogruAdet + " DOÐRU";
                yanlisText.text = gameManager.GetComponent<GameManager>().yanlisAdet + " YANLIÞ";
                puanText.text = gameManager.GetComponent<GameManager>().toplamPuan + " PUAN";

                tekrarOynaBtn.GetComponent<RectTransform>().DOScale(1, .3f);
                menuyeDonBtn.GetComponent<RectTransform>().DOScale(1, .3f);
            }
        }
    }

    public void TekrarOyna()
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(audioClick);
        }
        SceneManager.LoadScene("AltMenuLevel");
    }

    public void MenuyeDon()
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(audioClick);
        }
        SceneManager.LoadScene("MenuLevel");
    }
}