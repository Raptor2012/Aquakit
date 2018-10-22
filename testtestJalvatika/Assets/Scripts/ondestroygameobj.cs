using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ondestroygameobj : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDestroy()
    {
        
        if (PlayerPrefs.HasKey("LOGINCHECK") == false  )
        {

            SceneManager.LoadScene("SetPasswordScene");

        }
        else if (PlayerPrefs.GetString("LOGINCHECK") == "0")
        {
            SceneManager.LoadScene("LogInScene2");
        }
        else if (PlayerPrefs.GetString ("LOGINCHECK") == "1")
        {
            SceneManager.LoadScene("HomeScene");
        }
    }
}
