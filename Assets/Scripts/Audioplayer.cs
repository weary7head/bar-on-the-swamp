using System.Collections.Generic;
using UnityEngine;

public class Audioplayer : MonoBehaviour
{
    [SerializeField] private List<AudioClip> audioClips;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask layerMask;

    private int currentAudioIndex = -1;

    private void Start()
    {
        PlayNextAudio();
    }

    private void Update()
    {
        if (!audioSource.isPlaying) PlayNextAudio();
        if (!Input.GetMouseButtonDown(0)) return;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit, layerMask)) PlayNextAudio();
    }

    private void PlayNextAudio()
    {
        currentAudioIndex++;
        if (currentAudioIndex == audioClips.Count) currentAudioIndex = 0;
        audioSource.clip = audioClips[currentAudioIndex];
        audioSource.Play();
    }
}
