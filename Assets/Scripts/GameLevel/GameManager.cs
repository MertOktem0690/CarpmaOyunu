using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject baslaImage;

    [SerializeField]
    private GameObject dogruImage, yanlisImage;

    [SerializeField]
    private Text soruText,birinciSonucText,ikinciSonucText,ucuncuSonucText;

    [SerializeField]
    private Text dogruText, yanlisText, puanText;

    string hangiOyun;

    int birinciCarpan;

    int ikinciCarpan;

    int dogruSonuc;

    int birinciYanlisSonuc;

    int ikinciYanlisSonuc;

    public int dogruAdet, yanlisAdet, toplamPuan;

    PlayerManager playerManager;

    AdmobManager admobManager;

    private void Awake()
    {
        playerManager = Object.FindObjectOfType<PlayerManager>();

        admobManager = Object.FindObjectOfType<AdmobManager>();

    }

    void Start()
    {
        dogruImage.GetComponent<RectTransform>().localScale = Vector3.zero;
        yanlisImage.GetComponent<RectTransform>().localScale = Vector3.zero;

        dogruAdet = 0;
        yanlisAdet = 0;
        toplamPuan = 0;

        if(PlayerPrefs.HasKey("hangiOyun"))
        {
            //Debug.Log(PlayerPrefs.GetString("hangiOyun"));

            hangiOyun = PlayerPrefs.GetString("hangiOyun");
        }

        StartCoroutine(baslaYaziRoutine());
    }


    void Update()
    {
        
    }

    IEnumerator baslaYaziRoutine()
    {
        baslaImage.GetComponent<RectTransform>().DOScale(1.3f, 0.5f);
        yield return new WaitForSeconds(0.6f);

        baslaImage.GetComponent<RectTransform>().DOScale(0f, 0.5f).SetEase(Ease.InBounce);

        yield return new WaitForSeconds(0.6f);

        OyunaBasla();
    }

    void OyunaBasla()
    {
        playerManager.rotaDegissinmi = true;

        //Debug.Log("oyuna basladý");
        SoruyuYazdir();

        admobManager.Showbanner();
    }

    void BirinciCarpanýAyarla()
    {
        switch (hangiOyun)
        {
            case "iki":
                birinciCarpan = 2;
                break;

            case "üç":
                birinciCarpan = 3;
                break;

            case "dört":
                birinciCarpan = 4;
                break;

            case "beþ":
                birinciCarpan = 5;
                break;

            case "altý":
                birinciCarpan = 6;
                break;

            case "yedi":
                birinciCarpan = 7;
                break;

            case "sekiz":
                birinciCarpan = 8;
                break;

            case "dokuz":
                birinciCarpan = 9;
                break;

            case "on":
                birinciCarpan = 10;
                break;

            case "karýþýk":
                birinciCarpan = Random.Range(2, 11);
                break;
        }

        //Debug.Log(birinciCarpan);
    }

    void SoruyuYazdir()
    {
        BirinciCarpanýAyarla();

        ikinciCarpan = Random.Range(2, 11);

        int rastgeleDeger = Random.Range(1, 100);

        if(rastgeleDeger<=50)
        {
            soruText.text = birinciCarpan.ToString() + "x" + ikinciCarpan.ToString();
        }else
        {
            soruText.text = ikinciCarpan.ToString() + "x" + birinciCarpan.ToString();
        }

        dogruSonuc = birinciCarpan * ikinciCarpan;

        SonuclariYazdir();
    }

    void SonuclariYazdir()
    {
        birinciYanlisSonuc = dogruSonuc + Random.Range(2, 5);

        if(dogruSonuc>10)
        {
            ikinciYanlisSonuc = dogruSonuc - Random.Range(2, 5);

        }else
        {
            ikinciYanlisSonuc = Mathf.Abs(dogruSonuc - Random.Range(1, 3));
        }

        int rastgeleDeger = Random.Range(1, 100);

        if(rastgeleDeger<=33)
        {
            birinciSonucText.text = dogruSonuc.ToString();

            ikinciSonucText.text = birinciYanlisSonuc.ToString();

            ucuncuSonucText.text = ikinciYanlisSonuc.ToString();

        }else if(rastgeleDeger<=66)
        {
            ikinciSonucText.text = dogruSonuc.ToString();

            birinciSonucText.text = birinciYanlisSonuc.ToString();

            ucuncuSonucText.text = ikinciYanlisSonuc.ToString();

        }
        else
        {
            ucuncuSonucText.text = dogruSonuc.ToString();

            ikinciSonucText.text = birinciYanlisSonuc.ToString();

            birinciSonucText.text = ikinciYanlisSonuc.ToString();
        }
    }

    public void SonucuKontrolEt(int textSonucu)
    {
        dogruImage.GetComponent<RectTransform>().localScale = Vector3.zero;
        yanlisImage.GetComponent<RectTransform>().localScale = Vector3.zero;

        if (textSonucu==dogruSonuc)
        {
            dogruAdet++;
            toplamPuan += 20;
            dogruImage.GetComponent<RectTransform>().DOScale(1, .1f);
            //Debug.Log("dogru Sonuç");
        }else
        {
            yanlisAdet++;
            yanlisImage.GetComponent<RectTransform>().DOScale(1, .1f);
            //Debug.Log("yanlýþ Sonuç");
        }
        dogruText.text = dogruAdet.ToString() + " DOÐRU";
        yanlisText.text = yanlisAdet.ToString() + " YANLIÞ";
        puanText.text = toplamPuan.ToString() + " PUAN";

        SoruyuYazdir();
    }
}
