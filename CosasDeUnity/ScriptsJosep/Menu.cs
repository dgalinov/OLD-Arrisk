using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    //public Button MyButton = null;
    // Use this for initialization
    /*void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}*/

    public void SendToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void SendToCargarPartida () {
        SceneManager.LoadScene(1);
    }

    public void SendToOptionMenu() {
        SceneManager.LoadScene(2);
    }
    
    public void SendToCrearPartida() { 
        SceneManager.LoadScene(3);
    }

    public void SendToLogin()
    {
        SceneManager.LoadScene(4);
    }

    public void SendToNivel1()
    {
        SceneManager.LoadScene(5);
    }

    public void SendToTutorial()
    {
        SceneManager.LoadScene(6);
    }

    public void SendToNivel2()
    {
        SceneManager.LoadScene(7);
    }
}

