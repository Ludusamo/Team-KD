using UnityEngine;
using System.Collections;

public class NetworkMasterChar : MonoBehaviour {

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			// We own this player: send the others our data
			stream.SendNext(((MasterGUI)gameObject.GetComponent<MasterGUI>()).stolengold);
		}
		else
		{
			// Network player, receive data
			((MasterGUI)gameObject.GetComponent<MasterGUI>()).stolengold = (int)stream.ReceiveNext();

		}
	}
}
