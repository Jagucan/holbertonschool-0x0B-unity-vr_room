using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TeleportPoint : MonoBehaviour
{
    public UnityEvent OnTeleportEnter;
    public UnityEvent OnTeleport;
    public UnityEvent OnTeleportExit;

    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void OnTeleportEnterXR()
    {
        OnTeleportEnter?.Invoke();
    }

    public void OnTeleportClickXR()
    {
        ExecuteTeleoportation();
        OnTeleport?.Invoke();
        TeleportManager.Instance.DisableTeleportPoint(gameObject);
    }

    public void OnTeleportExitXR()
    {
        OnTeleportExit?.Invoke();
    }

    private void ExecuteTeleoportation()
    {
        GameObject player = TeleportManager.Instance.Player;
        player.transform.position = transform.position;
        Camera camera = player.GetComponentInChildren<Camera>();
        float rotationY = transform.rotation.eulerAngles.y - camera.transform.localEulerAngles.y;
        player.transform.rotation = Quaternion.Euler(0, rotationY, 0);
    }
}
