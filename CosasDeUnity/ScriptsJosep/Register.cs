using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
using System;

public class Register : MonoBehaviour
{
    public GameObject username;
    public GameObject email;
    public GameObject password;
    public GameObject confirmPassword;
    private string Username;
    private string Email;
    private string Password;
    private string ConfirmPassword;
    private string form;
    private bool EmailValid = false;
    private string[] Characters = {"a","b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t",
                                   "u","v", "w", "x", "y", "z","A","B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O",
                                   "P", "Q", "R", "S", "T", "U","V", "W", "X", "Y", "Z",
                                   "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "_", "-"};

    // Use this for initialization
    void Start(){

    }

    public void RegisterButton(){
        bool UN = false;
        bool EM = false;
        bool PW = false;
        bool CPW = false;
        
        if (Username != ""){
            if (!System.IO.File.Exists(@"C:/UnityTestFolder/" + Username + ".txt")){
                UN = true;
            } else {
                Debug.LogWarning("Username Taken.");
            }
        } else {
            Debug.LogWarning("Username field Empty.");
        }
        if (Email != ""){
            EmailValidation();
            if (EmailValid){
                if(Email.Contains("@")){
                    if (Email.Contains(".")){
                        EM = true;
                    } else {
                        Debug.LogWarning("Email is Incorrect.");
                    }
                } else {
                    Debug.LogWarning("Email is Incorrect.");
                }
            } else {
                Debug.LogWarning("Email is Incorrect.");
            }
        }
        else {
            Debug.LogWarning("Email Field Empty.");
        }
        if (Password != ""){
            if (Password.Length > 5){
                PW = true;
            } else {
                Debug.LogWarning("Password must be atleast 6 characters long.");
            }  

        }else {
            Debug.LogWarning("Password Field is Empty.");
        }
        if (ConfirmPassword != "")
        {
            if (ConfirmPassword == Password)
            {
                CPW = true;
            }
            else
            {
                Debug.LogWarning("Password don't match.");
            }
        } else {
            Debug.LogWarning("Confirmation password field is Empty.");
        }
        if(UN == true && EM == true && PW == true && CPW == true) {
            bool Clear = true;
            int i = 1;
            foreach(char c in Password) {
                if (Clear) {
                    Password = "";
                    Clear = false;
                } 
                i++;
                char Encrypted = (char)(c * 1);
                Password += Encrypted.ToString();
            }
            //Password Encryptment

            byte[] data = System.Text.Encoding.ASCII.GetBytes(Password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);

            form = (Username +Environment.NewLine + Email +Environment.NewLine + hash);
            System.IO.File.WriteAllText(@"C:/UnityTestFolder/" + Username + ".txt", form);
            username.GetComponent<InputField>().text = "";
            email.GetComponent<InputField>().text = "";
            password.GetComponent<InputField>().text = "";
            confirmPassword.GetComponent<InputField>().text = "";
            print("Registration Complete");
        }
    }
        
    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Tab)){
            if (username.GetComponent<InputField>().isFocused){
                email.GetComponent<InputField>().Select();
            }
            if (email.GetComponent<InputField>().isFocused){
                password.GetComponent<InputField>().Select();
            }
            if (password.GetComponent<InputField>().isFocused){
                confirmPassword.GetComponent<InputField>().Select();
            }
        }
        if (Input.GetKeyDown(KeyCode.Return)){
            if (Username != "" && Email != "" && Password != "" && ConfirmPassword != ""){
                RegisterButton();
            }
        }
        Username = username.GetComponent<InputField>().text;
        Email = email.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
        ConfirmPassword = confirmPassword.GetComponent<InputField>().text;
    }
    void EmailValidation() {
        bool SW = false;
        bool EW = false;
        for (int i = 0;  i< Characters.Length; i++) {
            if (Email.StartsWith(Characters[i])) {
                SW = true;  
            }
        }
        for (int i = 0; i < Characters.Length; i++)
        {
            if (Email.EndsWith(Characters[i])) {
                EW = true;
            }
        }

        if(SW == true && EW == true) {
            EmailValid = true;
        } else {
            EmailValid = false;
        }
    }
}

