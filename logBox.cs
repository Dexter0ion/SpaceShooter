using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class logBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, Screen.width / 5, Screen.height / 4),
            "信息提示");
        GUI.Label(new Rect(Screen.width / 2, Screen.height * 9 / 16,
            Screen.width / 5, Screen.height * 3 / 8), "这是一个测试系统，版权归辽宁工程技术大学所有");
        if (GUI.Button(new Rect(Screen.width * 11 / 20, Screen.height * 11 / 16,
            Screen.width / 10, Screen.height / 16), "退出"))
        {
            GameObject xx = GameObject.Find("Main Camera");
           //xx.GetComponent<ShowInformation>().enabled = false;
        }

    }
}
