
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
public class QUI : UdonSharpBehaviour
{
    [UdonSynced]
    private bool toggle = false;

    private VRCPlayerApi local;

    public GameObject[] target;
    void Start()
    {
        local = Networking.LocalPlayer;
    }

    public void ToggleQuestion()
    {
        foreach (var obj in target)
        {
            obj.SetActive(!obj.activeSelf);
        }
    }

    public override void Interact()
    {
        Networking.SetOwner(local,this.gameObject);
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All,"ToggleQuestion");
        toggle=!toggle;
    }

    public override void OnPlayerJoined(VRCPlayerApi player)
    {
        if(player==local)
        {
            if(toggle==true)
            {
                ToggleQuestion();
            }
        }
    }
}
