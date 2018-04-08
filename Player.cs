using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {

	private int n; //Player Number
	private int hp; //Health Points

	private List<Card> cards; //Player's handcards
	private List<Card> chosen; //Three chosen cards for that round

	private Handler handler;

	public Player(int num){
		this.n = num;
		hp = 3;

	}

	public int getNum(){
		return n;
	}

	public int getHP(){
		return hp;
	}

	public void addCard(Card c){
		cards.Add (c);
	}
	public void removeCard(Card c){
		cards.Remove (c);
	}

	public void addChosen(Card c){
		chosen.Add (c);
	}
	public void removeChosen(Card c){
		chosen.Remove (c);
	}

	public void displayCards(){
		foreach (Card card in cards)
			card.destroyClone ();
		//x from -224 to 261
		//y -252
		int i=0;
		foreach (Card card in cards) {
			card.setPositionSize (new Vector2 (-224 + 485 / cards.Count / 2 * i+485/4, -242), new Vector2 (142, 197)); 
			card.setParent (handler.canvas_game);
			card.instantiateCard ();
			i++;
		}
	}

	public void setHandler(Handler handler){
		this.handler = handler;
	}


		
		
}

