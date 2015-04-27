/* ---------------------------------------------------------------------------
 * Name: Character.cs
 * 
 * Purpose: Base Character class that all hero and enemy characters will be
 *          built on.
 * 
 * 			Provides all relevant stats and functions to be inherited by the 
 * 			lower classes.
 * 
 * 			1: maxHealth - The Character's Maximum health, should only change
 * 						at level ups
 * 			2: health - The Character's current health at any given moment.
 * 			3: maxEnergy - The Character's Maximum available energy, should
 * 						only change at level up.
 * 			4: energy - The Character's current energy to spend on actions.
 * 			5: maxMovement - The Character's maximum movement ability, should
 * 						only change at level up.
 * 			6: movement - The Character's current movement points to spend on
 * 						moving across the scene.
 * 			7: baseAttack - The Character's attack power before adding in the
 * 						power of weapons.
 * 			8: attack - The combination of the Character's baseAttack and
 * 						weapon power.
 * 			9: baseDefense -The Character's defense power before adding in the
 * 						power of armor.
 * 			10: defense - The combination of the Character's baseDefense and 
 * 						armor. NOT USED in version 1.
 * 			11: level - The multiplier used to calculate the other stats during
 * 						Character creation and level up.
 * 			12: experience - The measure of a Character's progress to the next
 * 						level up.
 * 			13: expToNext - The remaining experience needed to reach a
 * 						Character's next level.
 * 			14: range - The Character's attack range.
 *
 * Author: William Witten
 * Date: 3/25/2015
 * Modified by: William Witten
 * Date: 4/1/2015, 4/15/2015, 4/18/2015, 4/20/2015-4/23/2015
 ---------------------------------------------------------------------------*/

using UnityEngine;

public class Character : MonoBehaviour
{

	protected virtual void Awake()
	{
		maxHealth = 1;
		health = 1;
		maxEnergy = 1;
		energy = 1;
		baseAttack = 1;
		baseDefense = 1;
		movement = 1;
		attack = 1;
		defense = 1;
		level = 1;
		experience = 1;
		expToNext = 99;
		range = 1;
	}

  private int _maxHealth;
  public int maxHealth
  {
    get { return _maxHealth;}
    set { _maxHealth = value;}
  }

  private int _health;
  public int health
  {
    get { return _health;}
    set { if(_health + value <= _maxHealth) {_health = _health + value;}
            else _health = _maxHealth; }
  }
  private int _maxEnergy;
  public int maxEnergy
  {
    get { return _maxEnergy;}
    set { _maxEnergy = value;}
  }

  private int _energy;
  public int energy
  {
  get { return _energy;}
  set { if(_energy + value <= _maxEnergy) {_energy = value;}
          else _energy = _maxEnergy; }
  }
  
  private int _maxMovement;
  public int maxMovement
  {
  get { return _maxMovement;}
  set { _maxMovement = value;}
  }

  private int _movement;
  public int movement
  {
    get { return _movement;}
    set { if(_maxMovement + value <= _maxMovement) {_movement = value;}
            else _movement = _maxMovement; }
  }

  private int _baseAttack;
  public int baseAttack
  {
    get { return _baseAttack;}
    set { _baseAttack = value;}
  }

  private int _attack;
  public int attack
  {
    get { return _attack;}
    set { _attack = value + _baseAttack;}
  }

  private int _baseDefense;
  public int baseDefense
  {
    get { return _baseDefense;}
    set { _baseDefense = value;}
  }

  private int _defense;
  public int defense
  {
    get { return _defense;}
    set { _defense = value + _baseDefense;}
  }

  private int _level;
  public int level
  {
    get { return _level;}
    set { if(_level + value < 21) {_level = value;}
            else {_level = 20;} }
  }

  private int _experience;
  public int experience
  {
    get { return _experience;}
    set { if (_experience + value <= 99) {_experience = _experience + value;}
			else { _experience = 1; levelUP ();}
		}
  }

  private int _expToNext;
  public int expToNext
  {
    get { return _expToNext;}
    set { _expToNext = value;}
  }

  private int _range;
  public int range
  {
		get { return _range; }
		set { _range = value;}
  }

/*______________________________________________________________________________*/

  public void levelUP()
  {
    // do nothing, be overridden in derived classes
  }
 
	/* ---------------------------------------------------------------------------
	 * Name: Character()
	 * 
	 * Purpose: Default empty constructor, not likely to be used unless an error
	 * 			has occured.
	 * 
	 * Author: William Witten
	 * 
	 * -------------------------------------------------------------------------*/
	
  public Character()
  {
    maxHealth = 1;
    health = 1;
    maxEnergy = 1;
    energy = 1;
    baseAttack = 1;
    baseDefense = 1;
    movement = 1;
    attack = 1;
    defense = 1;
    level = 1;
    experience = 1;
    expToNext = 99;
	range = 1;
  }
  
	/* ---------------------------------------------------------------------------
	 * Name: Character(int maxHP, int HP, int maxMP, int MP, int baseATK,
	 * 					int baseDEF, int MOV, int ATK, int DEF, int LVL, int EXP,
	 * 					int RNG)
	 * 
	 * Purpose: Usual constructor that takes all Character stats to generate the
	 * 			Character object, inherited by all lower classes.
	 * 
	 * Author: William Witten
	 * 
	 * -------------------------------------------------------------------------*/
  public Character(int maxHP, int HP, int maxMP, int MP, int baseATK, int baseDEF,
	                 int MOV, int ATK, int DEF, int LVL, int EXP, int RNG)
  {
    maxHealth = maxHP;
    health = HP;
    maxEnergy = maxMP;
    energy = MP;
    baseAttack = baseATK;
    baseDefense = baseDEF;
    movement = MOV;
    attack = ATK;
    defense = DEF;
    level = LVL;
    experience = EXP;
    expToNext = 99;
	range = RNG;
  }

	/* ---------------------------------------------------------------------------
	 * Name: Attack()
	 * 
	 * Purpose: Determines if the attacking Character is within range of and hits
	 * 			an enemy Character. Calls the applyDamage function and adds to
	 * 			the attacking Character's experience.
	 * 
	 * 			Later Version should include random probability to miss.
	 * 
	 * Method: Retrieves the attacking Character's current position and then 
	 * 			uses a raycast to determine if the Character hits another Character.
	 * 			If the attack is successful it sends a message to the Character that
	 * 			was hit telling it how much damage to apply before increasing the
	 * 			attacking Character's experience directly.  If the attacker is
	 * 			not within range of it's target the move is simply wasted and ends.
	 * 
	 * 
	 * Author: William Witten
	 * 
	 * -------------------------------------------------------------------------*/
  public void Attack()
  {
		Vector2 position = this.transform.position;
		RaycastHit2D hit = Physics2D.Raycast (position, Vector2.zero, this.range);
		if (hit.rigidbody != null)
		{
			hit.rigidbody.gameObject.SendMessage("applyDamage", this.attack);
			this.experience += 25;
		}
  }

	/* ---------------------------------------------------------------------------
	 * Name: applyDamage(int Damage)
	 * 
	 * Purpose: Applies the damage done to the Character from the attack function
	 * 			and calculates if the damage was enough to destroy the Character.
	 * 
	 * Author: William Witten
	 * 
	 * -------------------------------------------------------------------------*/

	public void applyDamage(int Damage)
	{
		health -= Damage;
		if (health <= 0)
		{
			if(this.tag.Equals("Enemies"))
				this.SendMessageUpwards("updateEnemyCount");
			else
			{
				this.SendMessageUpwards("updatePlayerCount");
			}
			this.SendMessageUpwards("DestroyObject",this);
		}
	}


	new public string ToString()
	{
		var s = "Movement: " + movement + "\n";
		s += "Range: " + range;
		return s;
	}

}
