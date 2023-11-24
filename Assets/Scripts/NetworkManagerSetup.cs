using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;

public class NetworkManagerSetup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var configText = File.ReadAllText($"{Application.dataPath}/config.json");
        var config = JsonUtility.FromJson<NetworkConfig>(configText);
        NetworkManager.Singleton.GetComponent<UnityTransport>().ConnectionData.Address = config.adress;
        NetworkManager.Singleton.GetComponent<UnityTransport>().ConnectionData.Port = ushort.Parse(config.port);
    }
}

public class NetworkConfig
{
    public string adress;
    public string port;
}
