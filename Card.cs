
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card {

	//card names: ONE, TWO, THREE, LASSO, MIRROR, SEVEN
	//tag names: N - Normal, S - Special
	//bullet rep: ONE - 1, TWO - 2, THREE - 3, LASSO - 4, MIRROR - 5, SEVEN - 6
	private GameObject card;
	private GameObject clone;

	private GameObject cardPreview;
	private GameObject clone_preview;


	private string name;
	private int bullet;
	private string tag;

	private GameObject parent;

	private Vector2 position;
	private Vector2 size;

	private Handler handler;


	public Card(string name, GameObject parent)
	{
		this.name = name;
		this.parent = parent;

		if (name == "ONE" || name == "TWO" || name == "THREE") {
			tag = "N"; // N for Normal
		} else {
			tag = "S";
		}

		setCard ();
	}

	public Card(string name, GameObject parent, Vector2 position, Vector2 size)
	{
		this.name = name;
		this.parent = parent;
		this.position = position;
		this.size = size;

		if (name == "ONE" || name == "TWO" || name == "THREE") {
			tag = "N"; // N for Normal
		} else {
			tag = "S";
		}

		setCard ();

		instantiateCard ();
	}

	public void instantiateCard() //clone?
	{
		card = new GameObject();
		card.AddComponent<Image> ();
		card.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Card/"+name);

		card.GetComponent<RectTransform> ().anchoredPosition = position;
		card.GetComponent<RectTransform> ().sizeDelta = size;

		card.AddComponent<Button> ();

		card.AddComponent<EventTrigger> ();

		clone = GameObject.Instantiate (card, GameObject.Find(parent.name).GetComponent<RectTransform>(), false);
		clone.transform.SetParent (parent.transform);
		GameObject.Destroy (card);

		EventTrigger.Entry mouseEnter = new EventTrigger.Entry ();
		mouseEnter.eventID = EventTriggerType.PointerEnter;
		mouseEnter.callback.AddListener ((data) => {
			OnPointerEnterDelegate ((PointerEventData)data);
		});
		EventTrigger.Entry mouseExit = new EventTrigger.Entry ();
		mouseExit.eventID = EventTriggerType.PointerExit;
		mouseExit.callback.AddListener ((data) => {
			OnPointerExitDelegate ((PointerEventData)data);
		});
		clone.GetComponent<EventTrigger> ().triggers.Add (mouseEnter);
		clone.GetComponent<EventTrigger> ().triggers.Add (mouseExit);
		clone.gameObject.tag = "CARD";
	}

	public void OnPointerEnterDelegate (PointerEventData data){
		cardPreview = new GameObject();
		cardPreview.AddComponent<Image> ();
		cardPreview.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Card/"+name);

		cardPreview.GetComponent<RectTransform> ().anchoredPosition = new Vector2(position.x, position.y+300);
		cardPreview.GetComponent<RectTransform> ().sizeDelta = new Vector2((int)(size.x*1.5), (int)(size.y*1.5));

		cardPreview.AddComponent<Button> ();

		cardPreview.AddComponent<EventTrigger> ();

		clone_preview = GameObject.Instantiate (cardPreview, GameObject.Find(parent.name).GetComponent<RectTransform>(), false);
		clone_preview.transform.SetParent (parent.transform);
		GameObject.Destroy (cardPreview);
	}

	public void OnPointerExitDelegate (PointerEventData data){
		GameObject.Destroy (clone_preview);
		GameObject.Destroy (cardPreview);
	}

	public void OnMouseDown(){
		
	}



	public void destroyClone(){
		GameObject.Destroy (this.clone.gameObject);
	}

	public void setPosSize(Vector2 pos, Vector2 size){
		this.position = pos;
		this.size = size;
	}
		
	public void setCard(){
		switch(name){
		case "ONE":
			bullet = 1;
			break;
		case "TWO":
			bullet = 2;
			break;
		case "THREE":
			bullet = 3;
			break;
		case "LASSO":
			bullet = 4;
			break;
		case "MIRROR":
			bullet = 5;
			break;
		case "SEVEN":
			bullet = 6;
			break;
		default:
			bullet = 0;
			break;
		}
	}
	public void hide()
	{
		clone.gameObject.SetActive (false);
	}

	public void setPositionSize(Vector2 position, Vector2 size){
		this.position = position;
		this.size = size;
	}

	public string getName()
	{
		return name;
	}
	public int getBullet()
	{
		return bullet;
	}
	public string getTag()
	{
		return tag;
	}
	public void setParent(GameObject parent){
		this.parent = parent;
	}
	public void setHandler(Handler handler){
		this.handler = handler;
	}
		



}
