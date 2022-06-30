using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField]
    private Text sureText;

    [SerializeField]
    private GameObject sonucPanel;

    [SerializeField]
    private GameObject puanObje, playerObje, sonuclarObje, dogruYanlisObje, zamanObje;

    public int kalanSure;

    bool sureSaysinmi;

    void Start()
    {
        sureSaysinmi = true;

        sonucPanel.SetActive(false);

        StartCoroutine(SureTimerRoutine());
    }


    void Update()
    {
        
    }

    IEnumerator SureTimerRoutine()
    {
        while(sureSaysinmi)
        {
            yield return new WaitForSeconds(1f);

            if(kalanSure<10)
            {
                sureText.text = "0" + kalanSure.ToString();
            }else
            {
                sureText.text = kalanSure.ToString();
            }

            if(kalanSure<=0)
            {
                sureSaysinmi = false;
                sureText.text = "";
                EkraniTemizle();
                sonucPanel.SetActive(true);
            }
            kalanSure--;
        }
    }

    void EkraniTemizle()
    {
        puanObje.SetActive(false);

        playerObje.SetActive(false);

        sonuclarObje.SetActive(false);

        dogruYanlisObje.SetActive(false);

        zamanObje.SetActive(false);
    }
}
