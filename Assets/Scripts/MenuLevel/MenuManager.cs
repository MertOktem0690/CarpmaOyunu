using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPaneli;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip audioClick;

    [SerializeField]
    private GameObject sesPaneli;

    bool sesPaneliAcikmi;
 
    void Start()
    {
        sesPaneliAcikmi = false;

        sesPaneli.GetComponent<RectTransform>().localPosition = new Vector3(0, -150, 0);

        menuPaneli.GetComponent<CanvasGroup>().DOFade(1, 1f);

        menuPaneli.GetComponent<RectTransform>().DOScale(1, 2f).SetEase(Ease.OutBounce);
    }

    public void AltMenuyeGec()
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(audioClick);
        }
        SceneManager.LoadScene("AltMenuLevel");
    }

    public void AyarlariYap()
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(audioClick);
        }

        if(!sesPaneliAcikmi)
        {
            sesPaneli.GetComponent<RectTransform>().DOLocalMoveX(365, .5f);
            sesPaneliAcikmi = true;
        }else
        {
            sesPaneli.GetComponent<RectTransform>().DOLocalMoveX(0, .5f);
            sesPaneliAcikmi = false;
        }
    }

    public void OyundanCik()
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(audioClick);
        }
        Application.Quit();
        Debug.Log("Oyundan Çýktý");
    }
}
