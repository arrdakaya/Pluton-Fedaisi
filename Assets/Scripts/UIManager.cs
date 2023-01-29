using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
   public static UIManager _instance;
    public static bool isPaused = false;
    public GameObject failMenu;
    public GameObject PauseMenuUI;
    public GameObject Player;
    public GameObject Pluto;
    public GameObject plutoNews;

    private void Start()
    {
        if(_instance==null)_instance=this;
        //Cursor.lockState = CursorLockMode.Locked;
    

    }
    private void Update()
    {
        if(GameManager._instance.isFail){
            failMenu.SetActive(true);
            
            Cursor.lockState=CursorLockMode.Confined;

        }
        //Cursor.lockState = CursorLockMode.Confined;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if(isPaused)
            {
                Resume();
                
                
            }
            else
            {
                Pause();
                
               
            }
        }
    }
    public IEnumerator PlayNumerator()
    {
        plutoNews.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(1);

    }
    public void PlayButton()
    {
        StartCoroutine(PlayNumerator());
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

    }
    public void Restart(){
        Application.LoadLevel(Application.loadedLevel);
    }
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void LostButton()
    {
        PauseMenuUI.SetActive(false);
        Player.transform.position = Pluto.transform.position;
        Time.timeScale = 1f;
        isPaused = false;

    }
}
