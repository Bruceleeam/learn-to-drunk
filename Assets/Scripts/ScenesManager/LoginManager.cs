using System;
using System.Collections;
using System.Collections.Generic;
using Firebase;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    private FirebaseApp app;
    public Text displayName;

    // Start is called before the first frame update
    public void Login()
    {
        //FacebookAuthProvider facebookAuthProvider = new FacebookAuthProvider();
        EmailAuthProvider emailAuthProvider = new EmailAuthProvider();
        AuthenticationService authenticationService = new AuthenticationService(emailAuthProvider);

        // Chiamare il metodo Authenticate per avviare l'autenticazione
        authenticationService.Authenticate(OnSuccess, OnFailure);
        
    }

    // Definire i callback di successo e fallimento
    void OnSuccess(Firebase.Auth.AuthResult result)
    {
        Debug.LogFormat("User signed in successfully: {0} ({1})",
        result.User.DisplayName, result.User.UserId);
        displayName.text = result.User.DisplayName;
    }

    void OnFailure(string error)
    {
        Console.WriteLine("Errore durante l'autenticazione: " + error);
    }

}
