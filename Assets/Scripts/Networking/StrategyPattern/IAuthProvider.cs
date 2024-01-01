using System;
using UnityEngine;

public abstract class IAuthProvider : MonoBehaviour
{
    public Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
    public abstract void Authenticate(Action<Firebase.Auth.AuthResult> successCallback, Action<string> failureCallback);
}

