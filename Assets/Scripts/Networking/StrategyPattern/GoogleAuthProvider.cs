using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoogleAuthProvider : IAuthProvider
{
    public override void Authenticate(Action<Firebase.Auth.AuthResult> successCallback, Action<string> failureCallback)
    {
        // Implementa l'autenticazione tramite SDK di Google
        // Chiamata a successCallback o failureCallback a seconda dell'esito
    }
}

