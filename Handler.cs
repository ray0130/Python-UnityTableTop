using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handler{

	private Player player;
	private Card card;
	private Deck deck;

	public GameObject canvas_game;

	public Handler(Deck deck){
		this.deck = deck;
	}

	public void setPlaying(Player player){
		this.player = player;
	}

	public void setCard(Card card){
		this.card = card;
	}

	public Player getPlaying(){
		return player;
	}

	public Card getCard(){
		return card;
	}

	public Deck getDeck(){
		return deck;
	}

		

}
