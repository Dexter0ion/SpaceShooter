using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene1Maneger : MonoBehaviour
{
    private int logState = 0;
    private int logCnt = 0;
    private string[] logContent = { "Ciao", "Bonjour" };
    Text textMeet;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //float dis = Vector3.Distance(object1.transform.position, object2.transform.position);
        textMeet = GameObject.Find("Canvas/Text1").GetComponent<Text>();
        if (logState == 1)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                textMeet.text = logContent[logCnt];
                logCnt++;
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Stage")
        {
            operaScene1();
        }
    }

    void operaScene1()
    {
        textMeet = GameObject.Find("Canvas/Text1").GetComponent<Text>();
        textMeet.text = "Connecting";
        logState = 1;
    }
}
