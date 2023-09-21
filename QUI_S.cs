
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class QUI_S : UdonSharpBehaviour
{
    [UdonSynced]
    private int i=1;
    private bool toggle = false;

    private VRCPlayerApi local;

    public GameObject target1, target2;
    void Start()
    {
        local = Networking.LocalPlayer;
    }
   
    public void ToggleQuestion()
    {

        target2.SetActive(!target2.activeSelf);

        if(i==1)
        {
            target1.SetActive(!target1.activeSelf);
            i=0;
        }
        else
        {
            target1.SetActive(target1.activeSelf);
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
