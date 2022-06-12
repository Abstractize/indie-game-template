using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;

public class MultiplayerManager : MonoBehaviour
{
    private void Start()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };

        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }

    private void OnSuccess(LoginResult obj)
    {
        Debug.Log("Success!");
    }

    private void OnError(PlayFabError obj)
    {
        Debug.LogError("Error!");
    }
}
