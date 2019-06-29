using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

	void GoToAllOutBattle()
    {
        SceneManager.LoadScene("BattleFront");
    }

    void GoToAmbushBattle()
    {
        SceneManager.LoadScene("Battle");
    }

    void GoToTestBattle()
    {
        SceneManager.LoadScene("Test");
    }
}
