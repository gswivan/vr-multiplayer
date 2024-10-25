
using ExitGames.Client.Photon.StructWrapping;
using UnityEngine;
using Fusion;
using Labo7;
using Unity.VisualScripting;
using UnityEngine.XR.Management;

public class GameManager : MonoBehaviour
{
    public GameObject UICamera;
    public GameObject StartMenu;
    public GameObject VRPlayerPrefab;
    public GameObject DesktopPlayerPrefab;
    public FusionBootstrap Bootstrap;

    private GameObject PlayerPrefab;
    
    public void StartVR()
    {
        Bootstrap.StartSharedClient();
        PlayerPrefab = VRPlayerPrefab;
    }
    
    public void StartDesktop()
    {
        Bootstrap.StartSharedClient();
        PlayerPrefab = DesktopPlayerPrefab;
    }

    public void OnPlayerJoin(NetworkRunner runner_, PlayerRef pleyer_)
    {
        if (pleyer_ == runner_.LocalPlayer)
        {
            StartMenu.SetActive(false);
            UICamera.SetActive(false);
            NetworkObject player = runner_.Spawn(PlayerPrefab, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
            
            DesktopPlayer desktopPlayer = player.GetComponent<DesktopPlayer>();
            if (desktopPlayer != null)
            {
                desktopPlayer.SetLocal();
            }
            
            VRPlayer vrPlayer = player.GetComponent<VRPlayer>();
            if (vrPlayer != null)
            {
                XRGeneralSettings.Instance.Manager.StartSubsystems();
                vrPlayer.SetLocal();
            }
            
        }
    }
    
    
    
}
