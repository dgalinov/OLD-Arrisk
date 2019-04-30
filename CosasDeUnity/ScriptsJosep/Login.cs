
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text;
using System;
using System.Security.Cryptography;

public class Login : MonoBehaviour {
    public GameObject username;
    public GameObject password;
    private string Username;
    private string Password;
    private string[] Lines;
    private string DecryptedPassword;

    public void LoginButton() {
        bool UN = false;
        bool PW = false;

        if(Username != "") {
            if (System.IO.File.Exists(@"C:/UnityTestFolder/" + Username + ".txt")) {
                UN = true;
                Lines = System.IO.File.ReadAllLines(@"C:/UnityTestFolder/" + Username + ".txt");
            } else {
                Debug.LogWarning("Username Invalid.");
            }
        } else {
            Debug.LogWarning("Username Field Empty.");
        }

        if (Password != "") {
            if(System.IO.File.Exists(@"C:/UnityTestFolder/" + Username + ".txt")) {
                int i = 1;
                foreach (char c in Lines[2]) {
                    i++;
                    char Decrypted = (char)(c / 1);
                    DecryptedPassword += Decrypted.ToString();
                }
                byte[] data = System.Text.Encoding.ASCII.GetBytes(Password);
                data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                String hash = System.Text.Encoding.ASCII.GetString(data);

                if (hash == DecryptedPassword) {
                    PW = true;
                } else {
                    Debug.LogWarning("Password is invalid.");
                }
            } else {
                Debug.LogWarning("Password is invalid.");
            }
        } else {
            Debug.LogWarning("Password field Empty.");
        }
        if (UN == true && PW == true) {
            username.GetComponent<InputField>().text = "";
            password.GetComponent<InputField>().text = "";
            print("Login Succesful");
            SceneManager.LoadScene(0);
        }
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            if (username.GetComponent<InputField>().isFocused) {
                password.GetComponent<InputField>().Select();
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Username != "" && Password != "")
            {
                LoginButton();
            }
        }

        Username = username.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;

    }
} 
