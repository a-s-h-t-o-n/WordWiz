using System;
using Unity.Services.Core;
using UnityEngine;
using Unity.Services.Vivox;
using Unity.Services.Authentication;

public class TextToSpeechSingleton : MonoBehaviour
{
    [SerializeField] private GameObject TTSPrefab;
    public static TextToSpeechSingleton Instance
    {
        get
        {
            if (_instance != null)
            {
                return _instance;
            }

            GameObject go = new GameObject("TextToSpeechManager");
            go.AddComponent<TextToSpeechSingleton>();
            Instantiate(go);
            return _instance;
        }
        private set {}
    }

    [SerializeField] private string TestWord;

    [SerializeField] private static TextToSpeechSingleton _instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        InitializeAsyncTTSService();
    }

    TextToSpeechSingleton()
    {
        _instance = this;
    }

    [ContextMenu("Test Speak")]
    private void TestSpeak()
    {
        SpeakWord(TestWord);
    }
    
    public static void SpeakWord(string word)
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
