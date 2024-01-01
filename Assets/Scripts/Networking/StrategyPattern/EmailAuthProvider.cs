using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmailAuthProvider : IAuthProvider
{
    public InputField email;
    public InputField password;

    public override void Authenticate(Action<Firebase.Auth.AuthResult> successCallback, Action<string> failureCallback)
    {
        Firebase.Auth.Credential credential = Firebase.Auth.EmailAuthProvider.GetCredential("test@test.test", "test1234!@");
        auth.SignInAndRetrieveDataWithCredentialAsync(credential).ContinueWith(task =>
        {
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

    public void UpdateUsersProfile()
    {
        Firebase.Auth.FirebaseUser user = auth.CurrentUser;
        if (user != null)
        {
            Firebase.Auth.UserProfile profile = new Firebase.Auth.UserProfile
            {
                DisplayName = "Suzie Q.",
                PhotoUrl = new System.Uri("https://example.com/jane-q-user/profile.jpg"),
            };
            user.UpdateUserProfileAsync(profile).ContinueWith(task => {
                if (task.IsCanceled)
                {
                    Debug.LogError("UpdateUserProfileAsync was canceled.");
                    return;
                }
                if (task.IsFaulted)
                {
                    Debug.LogError("UpdateUserProfileAsync encountered an error: " + task.Exception);
                    return;
                }

                Debug.Log("User profile updated successfully.");
            });
        }
    }
}

