using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuthenticationService
{
    private IAuthProvider authProvider;

    public AuthenticationService(IAuthProvider provider)
    {
        authProvider = provider;
    }

    public void Authenticate(Action<Firebase.Auth.AuthResult> successCallback, Action<string> failureCallback)
    {
        authProvider.Authenticate(
            token => successCallback(token),
            error => failureCallback(error)
        );
    }
}

