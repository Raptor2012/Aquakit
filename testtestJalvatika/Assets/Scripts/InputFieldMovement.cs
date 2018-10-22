using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class InputFieldMovement : MonoBehaviour {

    // Use this for initialization

    public GameObject subpivot1;
    public GameObject subpivot2;
    public GameObject subpivot3;
    public GameObject subpivot4;

    public GameObject FinalPos1;
    public GameObject InitailPos1;

    private void Awake()
    {
        
       
    }

    private void OnEnable()
    {
        if (SceneManager.GetActiveScene().name == "LogInScene2")
        {
            subpivot1.transform.DOMoveY(FinalPos1.transform.position.y, 0.2f, false);
        }

        if (SceneManager.GetActiveScene().name == "SetPasswordScene")
        {
            subpivot1.transform.DOMoveY(FinalPos1.transform.position.y, 0.2f, false);
        }

        if (SceneManager.GetActiveScene().name == "credentialsenter")
        {
            subpivot1.transform.DOMoveY(FinalPos1.transform.position.y, 0.2f, false);
        }
    }

    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnDisable()
    {
        if (SceneManager.GetActiveScene().name == "LogInScene2")
        {
            subpivot1.transform.DOMoveY(InitailPos1.transform.position.y, 0.2f, false);
        }

        if (SceneManager.GetActiveScene().name == "SetPasswordScene")
        {
            subpivot1.transform.DOMoveY(InitailPos1.transform.position.y, 0.2f, false);
        }

        if (SceneManager.GetActiveScene().name == "credentialsenter")
        {
            subpivot1.transform.DOMoveY(InitailPos1.transform.position.y, 0.2f, false);
        }
    }
}
