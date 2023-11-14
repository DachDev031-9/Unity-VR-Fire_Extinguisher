using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour{
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currenQuestion;

    public GameObject BookInteraction;

    public GameObject Quizpanel;
    public GameObject GoPanel;
    public GameObject DoorToSimulation;

    public Text QuestionTxt;
    public Text ScoreTxt;

    int totalQuestions = 5;
    public int score;
    int NumOfQuestion = 5;

    public GameObject Quiz_bar;

    private void Start(){
        //totalQuestions = QnA.Count;
        //GoPanel.SetActive(false);
        generateQuestion();
    }
    public void retry(){
        Quiz_bar.SetActive(false);
        InstructionManualManager.OpenTutorialsStatus = false;
        InstructionManualManager.ObjectStatus = true;
        BookInteraction.SetActive(true);
        //NumOfQuestion = 5;
        //score = 0;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GameOver(){
        Quizpanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreTxt.text = score + "/" + totalQuestions;


        TimeSimuration.Time += (score*30);
        //if (score == 5){
            DoorToSimulation.SetActive(false);
        //}
    }
    public void correct(){
        // when you are right
        score += 1;
        QnA.RemoveAt(currenQuestion);
        generateQuestion();
    }
    public void wrong(){
        // when you answer wrong
        QnA.RemoveAt(currenQuestion);
        generateQuestion();
    }
    void SetAnswers(){
        for(int i = 0; i < options.Length; i++){
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currenQuestion].Answers[i];
            if (QnA[currenQuestion].CorrecAnswer == i+1){
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }
    void generateQuestion(){
        //if (QnA.Count > 1){
        if (NumOfQuestion > 0){
            NumOfQuestion -= 1;
            currenQuestion = Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[currenQuestion].Question;
            SetAnswers();
        }else{
            Debug.Log("Out of Question");
            GameOver();
        }
    }
}
