using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck{

	private List<Card> deck;
	private int size;

	private Handler handler;

	private GameObject parent;

	private string[] CARD_NAME = { "ONE", "TWO", "THREE", "LASSO", "MIRROR", "SEVEN" };
	private double[] CARD_PROBABILITY = { 25, 30, 20, 5, 7.5, 12.5};

	public Deck(int size){
		this.deck = new List<Card> ();
		this.size = size;

		initializeDeck ();
	}

	public void initializeDeck()
	{
		for (int i = 0; i < CARD_NAME.Length; i++) {
			for (int j = 0; j < CARD_PROBABILITY [i] * size / 100; j++) {
				//deck.Add(new Card(
				deck.Add (new Card(CARD_NAME[i], handler.canvas_game, new Vector2(0,0), new Vector2(0,0)));
				deck [i].setHandler (handler);
				deck [i].hide();
			}
		}
	}

	public void drawSix(Player player){
		int r;
		for (int i = 0; i < 6; i++) {
			r = Random.Range (0, deck.Count);
			player.addCard (deck [r]);
			deck.RemoveAt (r);
		}
	}

	public void drawSeven(Player player){
		int r;
		for (int i = 0; i < 7; i++) {
			r = Random.Range (0, deck.Count);
			player.addCard (deck [r]);
			deck.RemoveAt (r);
		}
	}

	public void setHandler(Handler handler){
		this.handler = handler;
	}

	public void drawOne(Player player){
		int r;
			r = Random.Range (0, deck.Count);
			player.addCard (deck [r]);
			deck.RemoveAt (r);

	}

	public void draw(int count, Player player){
		int r;
		for (int i = 0; i < count; i++) {
			r = Random.Range (0, deck.Count);
			player.addCard (deck [r]);
			deck.RemoveAt (r);
		}
	}

}
