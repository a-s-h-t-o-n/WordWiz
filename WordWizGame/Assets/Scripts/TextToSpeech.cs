using System;
using Unity.Services.Core;
using UnityEngine;
using Unity.Services.Vivox;
using Unity.Services.Authentication;

public class TextToSpeech : MonoBehaviour
{
    
    public static TextToSpeech Instance { get; private set; }

    private void Awake()
    {
        InitializeAsyncTTSService();
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    [ContextMenu("Test Speak")]
    private void TestSpeak()
    {
        SpeakWord("testing, one, two. check. bada bing bada boom.");
    }
    
    public void SpeakWord(string word)
    {
        VivoxService.Instance.TextToSpeechSendMessage(word, TextToSpeechMessageType.LocalPlayback);
    }

    async void InitializeAsyncTTSService()
    {
        await UnityServices.InitializeAsync();
        await AuthenticationService.Instance.SignInAnonymouslyAsync();

        await VivoxService.Instance.InitializeAsync();
    }
}
