using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float garbageCount;
    public bool isFail;
    public bool isFinish;
    public bool isInGarbageMission;
    public bool isInSatelliteMission;
    public GameObject moon,pluton;

    public static GameManager _instance;
    public Text textCounter;
    public float gameCounter;
    public Text missionText,missionText2;
   
    void Start()
    {
     if(_instance==null)_instance=this;
     isInGarbageMission=true;
     UpdateGame();
     Cursor.lockState = CursorLockMode.Locked;
     Time.timeScale=1f;

    }

    void Update()
    {   
        if(UIManager.isPaused){
            Cursor.lockState = CursorLockMode.Confined;}
        if(isFail){
            Cursor.lockState = CursorLockMode.Confined;
        }
        else if(!UIManager.isPaused) Cursor.lockState = CursorLockMode.Locked;
        
        if(garbageCount>=10){
            isInGarbageMission=false;
            isInSatelliteMission=true;
            UpdateGame();
            garbageCount=0;
        }
        gameCounter+=Time.deltaTime;
        textCounter.text="SURE "+gameCounter.ToString("0");
        if(isInGarbageMission){
            
            missionText.color=Color.red;
            missionText.text="Asteroidleri Yok Et"+" "+garbageCount.ToString()+"/10";
        }else{
            missionText.color=Color.green;
        }
        if(isInSatelliteMission){
            missionText2.color=Color.red;
            missionText2.text="Ay'I KACIR(CEMBERİN ICINDE BEKLE)";
            

        }
        

        
    }
    public void UpdateGame(){
    if(isFail){

        }
        if(isInGarbageMission){
            moon.transform.GetChild(0).gameObject.SetActive(false);
            pluton.transform.GetChild(0).gameObject.SetActive(false);
            missionText.color=Color.red;
            missionText.text="Asteroidleri Yok Et"+" "+garbageCount.ToString()+"/10";

        }if(isInSatelliteMission){
            moon.transform.GetChild(0).gameObject.SetActive(true);
            //pluton.transform.GetChild(0).gameObject.SetActive(true);

        }
    }
    public IEnumerator IsFinish(){
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(3);
        

    }
   
}
