using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int stage;       //현재 단계
    public int stagePoint;  //모은 재료수
    public string[] types = new string[] { "불", "물", "돌", "바람"}; //속성 배열
    public Text stageText;  //현재 단계 표시
    public GameObject Victory;//승리 화면

    public GameObject B1_1; //모을 재료 표시
    public GameObject B1_2;
    public GameObject B1_3;
    public GameObject B2_1;
    public GameObject B2_2;
    public GameObject B3_1;
    public GameObject B3_2;
    public GameObject B4_1;
    public GameObject B4_2;


    public GameObject B2;  //만들어진 재료 표시
    public GameObject B3;
    public GameObject B4;


    void Start()    //초기 세팅
    {
        Text T1_1 = B1_1.GetComponentInChildren<Text>();    //버튼 텍스트 변수
        Text T1_2 = B1_2.GetComponentInChildren<Text>();
        Text T1_3 = B1_3.GetComponentInChildren<Text>();

        //승리 패널 비활성화
        Victory.SetActive(false);

        //2단계 이상 비활성화
        B2.SetActive(false);
        B2_1.SetActive(false);
        B2_2.SetActive(false);
        B3.SetActive(false);
        B3_1.SetActive(false);
        B3_2.SetActive(false);
        B4.SetActive(false);
        B4_1.SetActive(false);
        B4_2.SetActive(false);

        //1단계 랜덤 생성
        T1_1.text = randomtype();
        T1_2.text = randomtype();
        T1_3.text = randomtype();

    }

    public void NextStage() //다음 단계 함수
    {
        Text T2 = B2.GetComponentInChildren<Text>();    //버튼 텍스트 변수
        Text T2_1 = B2_1.GetComponentInChildren<Text>();
        Text T2_2 = B2_2.GetComponentInChildren<Text>();

        Text T3 = B3.GetComponentInChildren<Text>();
        Text T3_1 = B3_1.GetComponentInChildren<Text>();
        Text T3_2 = B3_2.GetComponentInChildren<Text>();

        Text T4 = B4.GetComponentInChildren<Text>();
        Text T4_1 = B4_1.GetComponentInChildren<Text>();
        Text T4_2 = B4_2.GetComponentInChildren<Text>();

        switch (stage)  //단계별 행동
        {
            case 1: //1단계 완수
                T2_1.text = randomtype();
                T2_2.text = randomtype();

                B2.SetActive(true);
                B2_1.SetActive(true);
                B2_2.SetActive(true);
                break;

            case 2: //2단계 완수
                T3_1.text = randomtype();
                T3_2.text = randomtype();

                B3.SetActive(true);
                B3_1.SetActive(true);
                B3_2.SetActive(true);
                break;

            case 3: //3단계 완수
                T4_1.text = randomtype();
                T4_2.text = randomtype();

                B4.SetActive(true);
                B4_1.SetActive(true);
                B4_2.SetActive(true);
                break;

            case 4: //4단계 완수, 승리
                Victory.SetActive(true);
                break;
        }

        stage++;
        stageText.text = stage + "단계";  //단계 표시
    }

    public void Point(GameObject Btn)   //재료 모음
    {
        Image Btnimg = Btn.GetComponent<Image>();
        Btnimg.color = Color.yellow;
        Btn.GetComponent<Button>().interactable = false;
        stagePoint++;

        if (stagePoint == 3) //재료 모을 경우
        {
            stagePoint = 1;
            NextStage();
        }
    }

    public string randomtype()  //속성 스트링 랜덤 반환
    {
        int rand = Random.Range(0, 4);
        string type = types[rand];
        return type;
    }

    public void Restart()   //재시작
    {
        SceneManager.LoadScene(0);
    }

    public void GameExit()  //게임 종료
    {
        Application.Quit(); 
    }
}