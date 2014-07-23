using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	// Name attributes for the server
	private const string typeName = "UniqueGameName";
	private const string gameName = "Kevin's Room";
	private RoomInfo[] roomsList;

	// Player prefab that will be spawned in
	public GameObject playerPrefab;
	public GameObject roomGUIPrefab;
	private bool joinRoom;

	private bool firstStartUp;

	// Calls on startup
	void Start() {
		firstStartUp = true;
		joinRoom = false;
		PhotonNetwork.ConnectUsingSettings("0.1");
	}

	// GUI to host or join a server
	void OnGUI() {
		if (!PhotonNetwork.connected) {
			GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
		}
		else if (PhotonNetwork.room == null) {
			if (!joinRoom) {
				if (GUI.Button(new Rect((Screen.width / 2) - (Screen.height / 10), (Screen.height / 2) - (Screen.height / 10), Screen.width / 10, Screen.height / 10), "Start Server")) {
					PhotonNetwork.CreateRoom(gameName, true, true, 5);
				}
				if (GUI.Button(new Rect((Screen.width / 2) - (Screen.height / 10), (Screen.height / 2) + (Screen.height / 10), Screen.width / 10, Screen.height / 10), "Join"))
					joinRoom = true;
			} else {
				listRooms ();
			}
		}
	}

	void OnReceivedRoomListUpdate() {
		roomsList = PhotonNetwork.GetRoomList();
	}

	void OnJoinedRoom() {
		if (firstStartUp) {
			GameObject clone = (GameObject) Instantiate (playerPrefab, Vector3.zero, Quaternion.identity);
			GameObject clone1 = (GameObject) Instantiate (roomGUIPrefab, Vector3.zero, Quaternion.identity);
			Debug.Log("Hi");
			firstStartUp = false;
		}
	}

	void listRooms() {
		GUI.Box (new Rect((Screen.width / 2) - (Screen.width / 8), (Screen.height / 20), Screen.width / 4, Screen.height / 10), "Available Server");
		if (roomsList != null) {
			for (int i = 0; i < roomsList.Length; i++) {
				if (GUI.Button(new Rect((Screen.width / 2) - (Screen.width / 8), (Screen.height / 20) + ((Screen.height / 10) * (i + 1)), Screen.width / 4, Screen.height / 10), "Join " + roomsList[i].name + " " + roomsList[i].playerCount + "/" + roomsList[i].maxPlayers)) {
					PhotonNetwork.JoinRoom(roomsList[i].name);
				}
			}
		}
		if (GUI.Button(new Rect(Screen.width / 20, Screen.height - (Screen.height / 10), Screen.width / 10, Screen.height / 20), "Back"))
			joinRoom = false;
	}
}
