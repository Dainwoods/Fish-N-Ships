using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour {

	// Use this for initialization

	
	// Update is called once per frame


    public void takeDamage() {
        SceneManager.LoadScene("Scene_Play");
    }
}
