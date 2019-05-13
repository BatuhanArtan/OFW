using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadLevel : MonoBehaviour {

    public Framework getFrameWotkScript;

	public void Start () {
        StartCoroutine(restartLevel());
	}

    public IEnumerator restartLevel()
    {
        SceneManager.LoadScene("FrameworkTest");
        getFrameWotkScript.enabled = false;
        yield return new WaitForSeconds(1);
        getFrameWotkScript.enabled = true;
    }
}
