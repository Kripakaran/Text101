using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {
	private enum States {cell, mirror, sheets_0, lock_0, sheets_1, cell_mirror, lock_1, corridor_0, stairs_0, floor, closet_door, stairs_1, 
						 corridor_1, in_closet, stairs_2, corridor_2, courtyard, corridor_3 };
	private States mystate;
	public Text text;
	// Use this for initialization
	void Start () {
		mystate = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		print (mystate);
		if 		(mystate == States.cell)				{cell();}
		else if (mystate == States.sheets_0)			{sheets_0();}		
		else if (mystate == States.mirror) 				{mirror();}
		else if (mystate == States.lock_0) 				{lock_0();}
		else if (mystate == States.cell_mirror) 		{cell_mirror();}
		else if (mystate == States.sheets_1) 			{sheets_1();}
		else if (mystate == States.lock_1) 				{lock_1();}
		else if (mystate == States.corridor_0) 			{corridor_0();}
		else if (mystate == States.stairs_0) 			{stairs_0();}
		else if (mystate == States.floor) 				{floor();}
		else if (mystate == States.closet_door) 		{closet_door();}
		else if (mystate == States.stairs_1) 			{stairs_1();}
		else if (mystate == States.corridor_1) 			{corridor_1();}
		else if (mystate == States.in_closet) 			{in_closet();}
		else if (mystate == States.stairs_2) 			{stairs_2();}
		else if (mystate == States.corridor_2) 			{corridor_2();}
		else if (mystate == States.courtyard) 			{courtyard();}
		else if (mystate == States.corridor_3) 			{corridor_3();}
	}
	#region
	
	void cell () {
		text.text = "You are in a prison cell, and you want to escape. There are" + 
					"some dirty sheets on the bed, a mirror on the wall, and the door" +
					"is locked from the outside.\n\n" +
					"Press S to view Sheets, M to view Mirror, L to view Lock";
		if (Input.GetKeyDown(KeyCode.S)) {
			mystate = States.sheets_0;
			}
		else if (Input.GetKeyDown(KeyCode.M)) {
			mystate = States.mirror;
		}	
		else if (Input.GetKeyDown(KeyCode.L)) {
			mystate = States.lock_0;
		}	
	
	}
	
	void sheets_0 () {
		text.text = "You can't believe you sleep in these things. Surely it's " + 
					"time somebody changed them. The pleasures of prison life " +
					"I guess!\n\n" +
					"Press R to return to roaming your cell";			
		if (Input.GetKeyDown(KeyCode.R)) {
			mystate = States.cell;
		}
	}
	void mirror () {
		text.text = "The dirty old mirror on the wall seems loose.\n\n" +
					"Press R to return to roaming your cell, " +
					"Press T to take the mirror";			
		if (Input.GetKeyDown(KeyCode.R)) {
			mystate = States.cell;
		}else if (Input.GetKeyDown(KeyCode.T)) {
			mystate = States.cell_mirror;
		}
	}
	void lock_0 () {
		text.text = "This is one of those button locks. You have no idea what the " + 
					"combination is. You wish you could somehow see where the dirty " +
					"fingerprints were. Maybe that could help.\n\n" +
					"Press R to return to roaming your cell";			
		if (Input.GetKeyDown(KeyCode.R)) {
			mystate = States.cell;
		}
	}
	void cell_mirror () {
		text.text = "You are still in your cell, and you STILL want to escape! There are " + 
					"some dirty sheets on the bed. A mark where the mirror was, and that pesky door is still there " +
					"and firmly locked! \n\n" +
					"Press S to view sheets, " +
					"Press L to view Lock ";			
		if (Input.GetKeyDown(KeyCode.S)) {
			mystate = States.sheets_1;
		}else if (Input.GetKeyDown(KeyCode.L)) {
			mystate = States.lock_1;
		}
	}
	void sheets_1 () {
		text.text = "Holding a mirror in your hand " + 
					"doesn't make the sheets look any better.\n\n" +
					"Press R to return to roaming your cell";			
		if (Input.GetKeyDown(KeyCode.R)) {
			mystate = States.cell_mirror;
		}
	}
	void lock_1 () {
		text.text = "You carefully put the mirror through the bars and turn it around " + 
					"so you can see the lock. You can just make out fingerprints around the buttons. " +
					"You press the dirty buttons and hear a click.\n\n" +
					"Press R to return to roaming your cell, " +
					"Press O to open ";
		if (Input.GetKeyDown(KeyCode.R)) {
			mystate = States.cell_mirror;
		}else if (Input.GetKeyDown(KeyCode.O)) {
			mystate = States.corridor_0;
		}
	}
	void corridor_0() {
		text.text = "You're out of your cell, but not out of trouble." +
					"You are in the corridor, there's a closet and some stairs leading to " +
					"the courtyard. There's also various detritus on the floor.\n\n" +
					"C to view the Closet, F to inspect the Floor, and S to climb the stairs";
		if (Input.GetKeyDown(KeyCode.S)) {mystate = States.stairs_0;}
		else if (Input.GetKeyDown(KeyCode.F)) {mystate = States.floor;}
		else if (Input.GetKeyDown(KeyCode.C)) {mystate = States.closet_door;}
	}

	void in_closet() {
		text.text = "Inside the closet you see a cleaner's uniform that looks about your size! " +
					"Seems like your day is looking-up.\n\n" +
					"Press D to Dress up, or R to Return to the corridor";
		if (Input.GetKeyDown(KeyCode.R)) {mystate = States.corridor_2;}
		else if (Input.GetKeyDown(KeyCode.D)) {mystate = States.corridor_3;}
	}
	void closet_door() {
		text.text = "You are looking at a closet door, unfortunately it's locked. " +
					"Maybe you could find something around to help enourage it open?\n\n" +
					"Press R to Return to the corridor";
		if (Input.GetKeyDown(KeyCode.R)) {mystate = States.corridor_0;}
	}
	void corridor_3() {
		text.text = "You're standing back in the corridor, now convincingly dressed as a cleaner. " +
					"You strongly consider the run for freedom.\n\n" +
					"Press S to take the Stairs, or U to Undress";
		if (Input.GetKeyDown(KeyCode.S)) {mystate = States.courtyard;}
		else if (Input.GetKeyDown(KeyCode.U)) {mystate = States.in_closet;}
	}
	void corridor_2() {
		text.text = "Back in the corridor, having declined to dress-up as a cleaner.\n\n" +
					"Press C to revisit the Closet, and S to climb the stairs";
		if (Input.GetKeyDown(KeyCode.C)) {mystate = States.in_closet;}
		else if (Input.GetKeyDown(KeyCode.S)) {mystate = States.stairs_2;}
	}
	void corridor_1() {
		text.text = "Still in the corridor. Floor still dirty. Hairclip in hand. " +
					"Now what? You wonder if that lock on the closet would succumb to " +
					"to some lock-picking?\n\n" +
					"P to Pick the lock, and S to climb the stairs";
		if (Input.GetKeyDown(KeyCode.P)) {mystate = States.in_closet;}
		else if (Input.GetKeyDown(KeyCode.S)) {mystate = States.stairs_1;}
	}
	void floor () {
		text.text = "Rummagaing around on the dirty floor, you find a hairclip.\n\n" +
					"Press R to Return to the standing, or H to take the Hairclip." ;
		if (Input.GetKeyDown(KeyCode.R)) {mystate = States.corridor_0;}
		else if (Input.GetKeyDown(KeyCode.H)) {mystate = States.corridor_1;}
	}
	void courtyard () {
		text.text = "You walk through the courtyard dressed as a cleaner. " +
					"The guard tips his hat at you as you waltz past, claiming " +
					"your freedom. You heart races as you walk into the sunset.\n\n" +
					"Press P to Play again." ;
		if (Input.GetKeyDown(KeyCode.P)) {mystate = States.cell;}
	}
	void stairs_0 () {
		text.text = "You start walking up the stairs towards the outside light. " +
					"You realise it's not break time, and you'll be caught immediately. " +
					"You slither back down the stairs and reconsider.\n\n" +
					"Press R to Return to the corridor." ;
		if (Input.GetKeyDown(KeyCode.R)) {mystate = States.corridor_0;}
	}
	void stairs_1 () {
		text.text = "Unfortunately weilding a puny hairclip hasn't given you the " +
					"confidence to walk out into a courtyard surrounded by armed guards!\n\n" +
					"Press R to Retreat down the stairs" ;
		if (Input.GetKeyDown(KeyCode.R)) {mystate = States.corridor_1;}
	}
	void stairs_2() {
		text.text = "You feel smug for picking the closet door open, and are still armed with " +
					"a hairclip (now badly bent). Even these achievements together don't give " +
					"you the courage to climb up the staris to your death!\n\n" +
					"Press R to Return to the corridor";
		if (Input.GetKeyDown(KeyCode.R)) {mystate = States.corridor_2;}
	}
	
	#endregion
}