using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{ 
   public List<GameObject>Object;
   public GameObject LevelUI;
   public GameObject panelscreen;
   
   public AudioSource AwakeSound;
   public AudioClip destroysound;
   public AudioClip tap;

   public TextMeshProUGUI Score;
   public TextMeshProUGUI Gameover;
   public TextMeshProUGUI Highestscore;
   public TextMeshProUGUI Title;
   public TextMeshProUGUI Lives;
   public Button restartButton;
   public Button Quit;
   public Slider VolumeController;
    
    
 
   public  bool isactive= true ;
   public  float point = 0;
   private bool pause  = true ;
   public  int  lifeLoss = 3;
  

  

    void Start()
    { 
        
        UIstart();
    }
    
    void Update()
    { if (lifeLoss != -1)
        {
            Lives.text = "Lives" + " " + lifeLoss;
        }
        else
        {
            Lives.text = "Lives" + " " + 0;
        }

     if (   Input.GetKeyDown(KeyCode.Escape))
       {
            Paused();

       }
    }
  public  void   gameover()
    {
        Gameover.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        Quit.gameObject.SetActive(true);

    }


   public  void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

 
    

    public float Updatescore(int score)
    {
        if (isactive)
        {
            AwakeSound.PlayOneShot(destroysound, 1);
            point += score;
            Score.text = "Score" + " "+ point.ToString();

        }
            return( point);
    }

   public void Levelchanger(float time)
    {
        AwakeSound.PlayOneShot(tap, 1); 
        Score.gameObject.SetActive(true);
        Lives.gameObject.SetActive(true);
               
        Title.gameObject.SetActive(false);
        LevelUI.gameObject.SetActive(false);
        VolumeController.gameObject.SetActive(false);      
        StartCoroutine(spawn(time));

    }

     IEnumerator  spawn(float x)// ienumerator return the string 
    {
         while (isactive)
       {
            float spawnx = Random.Range(-3,3);
             yield return new WaitForSeconds(x);
            int index = Random.Range(0,Object.Count);
            Vector3 pos = new Vector3(spawnx, 0, 0f);
            Instantiate(Object[index], pos, Quaternion.identity);
        }
    }
    void UIstart()
    {
        Title.gameObject.SetActive(true);     
        LevelUI.gameObject.SetActive(true);    
        VolumeController.gameObject.SetActive(true);
    }
    public  void Totallife(int lifeleft)
    { 
        lifeLoss += lifeleft;

        if (lifeLoss == 0)
        {
            gameover();
         
        }
    }

     [SerializeField]
      private void Paused ()
    {
      if (pause == true)
      {
       pause = false;
       Time.timeScale = 0;
       panelscreen.gameObject.SetActive(true);
      
            
      }
      else 
        {
        pause = true;
        panelscreen.gameObject.SetActive(false);
        Time.timeScale = 1;
      

        }
    }
    public void OnApplicationQuit()
    {
        Application.Quit();

    }
}
