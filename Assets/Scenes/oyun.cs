using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class oyun : MonoBehaviour
{
    public Soru[] sorular;
    private static List<Soru> sorulmamisSorular;
    private Soru simdikiSoru;
    public Text SoruTexti;

    public Button butonA;
    public Button butonB;
    public Button butonC;
    public Button butonD;
    public GameObject soruPaneli;
    public GameObject OyunBittiPaneli;
    
    public Text doğruSayisiText;
    public Text yanlisSayisiText;

    private static int doğruSayisi;
    private static int yanlisSayisi;

    void Start()
    {
        if (sorulmamisSorular==null){
        sorulmamisSorular=sorular.ToList<Soru> ();
        }
        if(sorulmamisSorular.Count<=0){
            OyunBitti();
        }
        else{
            SoruSor();
        }
    }
    void SoruSor(){
        int soruIndexi=Random.Range(0,sorulmamisSorular.Count);
        simdikiSoru=sorulmamisSorular[soruIndexi];
        SoruTexti.text=simdikiSoru.soru;
        sorulmamisSorular.RemoveAt(soruIndexi);

        butonA.GetComponentInChildren<Text>().text=simdikiSoru.A_s;
        butonB.GetComponentInChildren<Text>().text=simdikiSoru.B_s;
        butonC.GetComponentInChildren<Text>().text=simdikiSoru.C_s;
        butonD.GetComponentInChildren<Text>().text=simdikiSoru.D_s;

    }
    public void SecenekA(){
        if(simdikiSoru.cevap==1){
            butonA.GetComponent<Image> ().color=Color.green;
            doğruSayisi++;
        }
        else{
            butonA.GetComponent<Image> ().color=Color.red;
            yanlisSayisi++;
        }
        StartCoroutine(SonrakiSoru());
    }
    public void SecenekB(){
        if(simdikiSoru.cevap==2){
            butonB.GetComponent<Image> ().color=Color.green;
            doğruSayisi++;
        }
        else{
            butonB.GetComponent<Image> ().color=Color.red;
            yanlisSayisi++;
        }
        StartCoroutine(SonrakiSoru());
    }public void SecenekC(){
        if(simdikiSoru.cevap==3){
            butonC.GetComponent<Image> ().color=Color.green;
            doğruSayisi++;
        }
        else{
            butonC.GetComponent<Image> ().color=Color.red;
            yanlisSayisi++;
        }
        StartCoroutine(SonrakiSoru());
    }public void SecenekD(){
        if(simdikiSoru.cevap==4){
            butonD.GetComponent<Image> ().color=Color.green;
            doğruSayisi++;
        }
        else{
            butonD.GetComponent<Image> ().color=Color.red;
            yanlisSayisi++;
        }
        StartCoroutine(SonrakiSoru());
    }
    IEnumerator SonrakiSoru(){
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }
    public void OyunBitti(){
        soruPaneli.SetActive(false);
        butonA.gameObject.SetActive(false);
        butonB.gameObject.SetActive(false);
        butonC.gameObject.SetActive(false);
        butonD.gameObject.SetActive(false);

        doğruSayisiText.text=doğruSayisi+"";
        yanlisSayisiText.text=yanlisSayisi+"";
        OyunBittiPaneli.SetActive(true);

    }

}
