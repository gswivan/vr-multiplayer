
using Fusion;
using UnityEngine;

public class VRPlayer : NetworkBehaviour
{

    public GameObject LocalRig;

    public GameObject LocalHead;
    public GameObject LocalLeftHand;
    public GameObject LocalRightHand;
    
    public GameObject RemoteHead;
    public GameObject RemoteLeftHand;
    public GameObject RemoteRightHand;
    
    public void SetLocal()
    {
        LocalRig.SetActive(true);
        DisableMesh(RemoteHead);
        DisableMesh(RemoteLeftHand);
        DisableMesh(RemoteRightHand);
    }

    public override void FixedUpdateNetwork()
    {
        RemoteHead.transform.position = LocalHead.transform.position;
        RemoteHead.transform.rotation = LocalHead.transform.rotation;
        RemoteLeftHand.transform.position = LocalLeftHand.transform.position;
        RemoteLeftHand.transform.rotation = LocalLeftHand.transform.rotation;
        RemoteRightHand.transform.position = LocalRightHand.transform.position;
        RemoteRightHand.transform.rotation = LocalRightHand.transform.rotation;
    }

    void DisableMesh(GameObject obj)
    {
        MeshRenderer mesh = obj.GetComponent<MeshRenderer>();
        mesh.enabled = false;
    }
    
}
