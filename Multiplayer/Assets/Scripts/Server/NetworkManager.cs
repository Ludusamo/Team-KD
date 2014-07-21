using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	// Name attributes for the server
	private const string typeName = "UniqueGameName";
	private const string gameName = "Kevin's Room";
	private RoomInfo[] roomsList;

	// Player prefab that will be spawned in
	public GameObject playerPrefab;

	// Calls on startup
	void Start() {
		PhotonNetwork.ConnectUsingSettings("0.1");
	}

	// GUI to host or join a server
	void OnGUI() {
		if (!PhotonNetwork.connected) {
			GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
		}
		else if (PhotonNetwork.room == null) {
			// Create Room
			if (GUI.Button(new Rect(100, 100, 250, 100), "Start Server"))
				PhotonNetwork.CreateRoom(gameName, true, true, 5);
			
			// Join Room
			if (roomsList != null) {
				for (int i = 0; i < roomsList.Length; i++) {
					if (GUI.Button(new Rect(100, 250 + (110 * i), 250, 100), "Join " + roomsList[i].name))
						PhotonNetwork.JoinRoom(roomsList[i].name);
				}
			}
		}
	}

	void OnReceivedRoomListUpdate() {
		roomsList = PhotonNetwork.GetRoomList();
	}
	void OnJoinedRoom() {
		PhotonNetwork.Instantiate(playerPrefab.name, Vector3.up * 5, Quaternion.identity, 0);
	}
}
