using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    /// <summary>
    /// 체력, 속도 적용 이슈
    /// </summary>
    public static UIManager instance;
    public int userMoney = 1000;
    public GameObject umaru;
    public GameObject spawner;
    //public UmaruMovement umaruMovement;
    //public Spawner spawner;
    public int score = 0;

    public bool isGameOver = false;
    public float HP;
    public float Speed;

    public Text stage_txt;
    public Text score_txt;
    public Text gold_txt;
    public Text hp_txt;
    public Text speed_txt;



    private void Awake()
    {
 
        if (instance == null)
        {
            instance = this;
            //umaruMovement = umaru.GetComponent<UmaruMovement>();
        }
        else
        {
            Debug.Log("한 게임에 2개이상의 씬이 존재할 수 없습니다.");
            Destroy(instance);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AddMonsterInfo(); 
        UserInfo();
    }
    public void AddMonsterInfo()
    {
        if (!isGameOver)
        {
            //float HP = umaruMovement.umaruHP;
            //HP = umaru.GetComponent<UmaruMovement>().umaruHP;
            //float HP = umaru.GetComponent<Spawner>().UmaruMovement.umaruHP;

            float stCount = spawner.GetComponent<Spawner>().stageCount;
            float updateHP = 10 + 5 * (stCount - 1);
            hp_txt.text = "HP : <color=#FF8B55>" + updateHP.ToString() +"</color>";

            //float speed = umaru.GetComponent<UmaruMovement>().speed;
            //Speed = umaru.GetComponent<UmaruMovement>().speed;
            double updateSpeed = 3 + 0.3 * (stCount - 1);
            speed_txt.text = "SPEED : <color=#FF8B55>" + updateSpeed.ToString() + "</color>";
        }

    }

    public void UserInfo() 
    {
        if (!isGameOver) 
        { 
            int stage = spawner.GetComponent<Spawner>().stageCount;
            stage_txt.text = "STAGE : <color=#FF8B55>" + stage.ToString() + "</color>";

            gold_txt.text = "GOLD : <color=#FF8B55>" + userMoney.ToString() + "</color>";

            score_txt.text = "SCORE : <color=#FF8B55>" + score.ToString() + "</color>";        
        }
    }
}
