using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CircleRotateManager : MonoBehaviour
{
    string hangiSonuc;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="mermi")
        {
            //Debug.Log(this.gameObject.name);

            gameObject.transform.DORotate(transform.eulerAngles + Quaternion.AngleAxis(45, Vector3.forward).eulerAngles, 0.5f);

            if(collision.gameObject!=null)
            {
                Destroy(collision.gameObject);
            }
            if(gameObject.name=="solDaire")
            {
                hangiSonuc = GameObject.Find("solText").GetComponent<Text>().text;

            }else if(gameObject.name=="ortaDaire")
            {
                hangiSonuc = GameObject.Find("ortaText").GetComponent<Text>().text;

            }else if (gameObject.name == "sagDaire")
            {
                hangiSonuc = GameObject.Find("sagText").GetComponent<Text>().text;
            }

            //Debug.Log(hangiSonuc);

            gameManager.SonucuKontrolEt(int.Parse(hangiSonuc));
        }
    }
}
