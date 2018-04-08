using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour {

	private Player playing;
	private List<Player> players;
	private int round;

	public GameObject canvas_game;

	private Handler handler;

	private Deck deck;

	void Start(){
		canvas_game.SetActive (true);

		players = new List<Player> ();
		for(int i = 0; i < 4; i++){
			players.Add(new Player(i));
		}

		round = 0;
		playing = players [round];

		deck = new Deck (200);

		handler = new Handler (deck);

		handler.setPlaying (playing);

		playing.setHandler (handler);
		deck.setHandler (handler);

		deck.drawSeven (playing);

		playing.displayCards ();

	}

}
