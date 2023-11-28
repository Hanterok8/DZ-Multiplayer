using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class ManagerUI : MonoBehaviour
{
    [SerializeField] private Button _Host;
    [SerializeField] private Button _Client;
    private void Awake()
    {
        _Host.onClick.AddListener(call: () => NetworkManager.Singleton.StartHost());
        _Client.onClick.AddListener(call: () => NetworkManager.Singleton.StartClient());
    }
}
