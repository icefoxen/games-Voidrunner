using UnityEngine;

using System.Net;
using System.Net.Sockets;
using System.Collections;

using MongoDB.Bson;
using VRLib;

public class Main : MonoBehaviour {
	
	string serverName = "phoenix.internal";
	int serverPort = 4444;
	// Use this for initialization
	void Start () {
		var ug = new UniverseGen();
		var p = ug.MakeRandomStarSystem(0);
		Debug.Log (p);
		var client = new TcpClient(serverName, serverPort);
		Debug.Log (string.Format("Client connected: {0}", client.Connected));
		var stream = client.GetStream();
		Debug.Log ("Grawr!");
		var wossname = BsonDocument.ReadFrom(stream);
		var pl = DecodeMessage.Place (wossname);
		Debug.Log (pl);

		var msg = EncodeMessage.PlayerEnteredSystem();
		msg.WriteTo(stream);
		//var place = DecodeMessage.Place(wossname);
		//Debug.Log (place.ToString());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
