using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class faq_test
{
    public string question;
    public string answer;

    public string getQuestion()
    {

        return question;
    }

    public string getAnswer()
    {

        return question;
    }

    public void setQuestion(string q)
    {

        question = q;
    }
    public void setAnswer(string a)
    {

        answer = a;
    }
}
