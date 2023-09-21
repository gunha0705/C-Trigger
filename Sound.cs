
using System;
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

[UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
public class Sound : UdonSharpBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip changeSound;
     
    private VRCPlayerApi local;

    public GameObject[] target;
    /**
     * Add / Subtract / Reset 버튼 클릭 => SetScore(_score +- 1); 실행 -> Score 변경 -> Score의 OnScoreChanged(_score); 실행 => SetUI(score); 실행
     */

    private void Start()
    {
        local = Networking.LocalPlayer;
    }
     public void ToggleAudio()
    {
        audioSource.PlayOneShot(changeSound);
    }

    public override void Interact()
    {
        Networking.SetOwner(local,this.gameObject);
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All,"ToggleAudio");
    }
    
}
