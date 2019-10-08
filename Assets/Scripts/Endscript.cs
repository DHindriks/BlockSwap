using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endscript : MonoBehaviour {
    public string scene;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.name == "Goldblock")
        {
            collision.gameObject.tag = "Won";
            //SceneManager.LoadScene(scene);
            StartCoroutine("LoadScene");
        }
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(scene);
    }
}
