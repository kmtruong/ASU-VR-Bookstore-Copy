using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;


public class FAQ_List : MonoBehaviour
{
    [SerializeField]
    private GameObject faq_row;
    [SerializeField]
    private List<faq_test> my_faq_list;
    private List<GameObject> faq_row_list;
    private GameObject store_row;
    private int i;


    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        //my_faq_list = new List<faq_test>();
        
        faq_row_list = new List<GameObject>();

        store_row = Instantiate(faq_row, transform);
        store_row.transform.Find("Question").GetComponent<Text>().text = "q1";
        store_row.transform.Find("Answer").GetComponent<Text>().text = "a1";
        faq_row_list.Add(store_row);
    }

    // Update is called once per frame
    void Update()
    {
        //print("my_faq_list size: "+ my_faq_list.Count);
        if(my_faq_list.Count > i)
        {
            add_FAQ_to_list(i);
            i++;
        }
    }

    public void add_FAQ_to_list(int i)
    {
        //for(int i = 0; i < my_faq_list.Count; i++)
        //{
            if(my_faq_list[i].question == null || my_faq_list[i].answer == null)
            {
                print("question or answer null");
            }
            else
            {
                store_row = Instantiate(faq_row, transform);
                //print("my_faq_list[i].question: "+ my_faq_list[i].question);
                store_row.transform.Find("Question").GetComponent<Text>().text = my_faq_list[i].question;
                store_row.transform.Find("Answer").GetComponent<Text>().text = my_faq_list[i].answer;
                faq_row_list.Add(store_row);
            }
        //}
    }


}
