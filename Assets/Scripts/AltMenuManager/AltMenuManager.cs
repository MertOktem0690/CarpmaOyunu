using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class AltMenuManager : MonoBehaviour
{

    [SerializeField]
    private GameObject altMenuPaneli;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip audioClick;

    void Start()
    {
        if(altMenuPaneli!=null)
        {
            altMenuPaneli.GetComponent<CanvasGroup>().DOFade(1, 1f);

            altMenuPaneli.GetComponent<RectTransform>().DOScale(1, 2f).SetEase(Ease.OutBounce);
        }
    }

    public void HangiOyunAcilsin(string hangiOyun)
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(audioClick);
        }

        //Debug.Log(hangiOyun);

        PlayerPrefs.SetString("hangiOyun", hangiOyun);

        SceneManager.LoadScene("GameLevel");
    }

    public void GeriDon()
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(audioClick);
        }

        SceneManager.LoadScene("MenuLevel");
    }
}
