using System;
using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;
using UnityEngine;

public class FacebookAuthProvider : IAuthProvider
{
    public string Token;
    public string Error;
    public List<string> perms = new List<string>() { "public_profile", "email" };

    // Awake function from Unity's MonoBehavior
    void Awake()
    {
        if (!FB.IsInitialized)
        {
            // Initialize the Facebook SDK
            FB.Init(InitCallback, OnHideUnity);
        }
        else
        {
            // Already initialized, signal an app activation App Event
            FB.ActivateApp();
        }
    }

    void InitCallback()
    {
        if (FB.IsInitialized)
        {
            // Signal an app activation App Event
            FB.ActivateApp();
            // Continue with Facebook SDK
        }
        else
        {
            Debug.Log("Failed to Initialize the Facebook SDK");
        }
    }

    void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            // Pause the game - we will need to hide
            Time.timeScale = 0;
        }
        else
        {
            // Resume the game - we're getting focus again
            Time.timeScale = 1;
        }
    }

    public override void Authenticate(Action<Firebase.Auth.AuthResult> successCallback, Action<string> failureCallback)
    {       

        FB.LogInWithReadPermissions(perms, result =>
        {
            if (FB.IsLoggedIn)
            {
                Token = AccessToken.CurrentAccessToken.TokenString;
                Firebase.Auth.Credential credential = Firebase.Auth.FacebookAuthProvider.GetCredential(Token);
                auth.SignInAndRetrieveDataWithCredentialAsync(credential).ContinueWith(task => {
                    if (task.IsCanceled)
                    {
                        Debug.LogError("SignInAndRetrieveDataWithCredentialAsync was canceled.");
                        return;
                    }
                    if (task.IsFaulted)
                    {
                        Debug.LogError("SignInAndRetrieveDataWithCredentialAsync encountered an error: " + task.Exception);
                        return;
                    }

                    Firebase.Auth.AuthResult result = task.Result;
                    successCallback(result);
                });
            }
            else
            {
                Error = "User cancelled login";
                failureCallback(Token);
            }
        });
    }

}

