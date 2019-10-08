using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
    public string scene;
    public bool scenes = true;
    public bool quit = false;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnCollisionEnter(Collision collision)
    {
        if (scenes == true) {
            if (collision.transform.gameObject.name == "Goldblock")
            {
                SceneManager.LoadScene(scene);
            }
        }

        if (quit == true)
        {
            Application.Quit();
        }

    } 

}
