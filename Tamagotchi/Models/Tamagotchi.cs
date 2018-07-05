using System;
using System.Collections.Generic;

namespace Tamagotchi.Models
{
  public class Item
  {
    Random num = new Random();
    private int _id;
    private int _hunger;
    private int _exhaustion;
    private int _boredom;
    private bool _isHungry;
    private bool _isExhausted;
    private bool _isBored;
    private int _hungerCounter;
    private int _exhaustionCounter;
    private int _boredomCounter;
    private bool _isDead;
    private int _lifespan;
    private string _name;
    private static List<Item> _instances = new List<Item> {};

    public Item(string nameTamagotchi)
    {
      _hunger = num.Next(4,8);
      _exhaustion = num.Next(8,14);
      _boredom = num.Next(4,14);
      _isHungry = false;
      _isExhausted = false;
      _isBored = false;
      _hungerCounter = 4;
      _exhaustionCounter = 4;
      _boredomCounter = 4;
      _isDead = false;
      _name = nameTamagotchi;
      _lifespan = 0;
      if(_name != "")
      {
        _instances.Add(this);
      }
      _id = _instances.Count;
    }
    public string GetStatus()
    {
      if(_isDead == true)
      {
        return "Your Tamagotchi is dead. RIP";
      }
      else if(_isHungry == true || _isExhausted == true || _isBored == true)
      {
        return "Your Tamagotchi is distressed D:";
      }
      else
      {
        return "Your Tamagotchi is happy :P";
      }
    }
    public void WarningCheck()
    {
      if(_isDead == false)
      {
        if(_isHungry == true)
        {
          _hungerCounter--;
        }
        else
        {
          _hungerCounter = 4;
        }
        if(_isExhausted == true)
        {
          _exhaustionCounter--;
        }
        else
        {
          _exhaustionCounter = 4;
        }
        if(_isBored == true)
        {
          _boredomCounter--;
        }
        else
        {
          _boredomCounter = 4;
        }
      }
      if(_hungerCounter == 0 || _exhaustionCounter == 0 || _boredomCounter == 0)
      {
        _isDead = true;
      }
    }
    public static void GameTick(List<Item> tamagotchis)
    {
      foreach(Item tamagotchi in tamagotchis)
      {
        tamagotchi._lifespan++;
        if(tamagotchi._lifespan %tamagotchi._hunger == 0)
        {
          tamagotchi._isHungry = true;
        }
        if(tamagotchi._lifespan %tamagotchi._exhaustion == 0)
        {
          tamagotchi._isExhausted = true;
        }
        if(tamagotchi._lifespan %tamagotchi._boredom == 0)
        {
          tamagotchi._isBored = true;
        }
        tamagotchi.WarningCheck();
      }
    }
    public int GetId()
    {
      return _id;
    }
    public static List<Item> GetAll()
    {
       return _instances;
    }
    public void SetHunger(int newHunger)
    {
      _hunger = newHunger;
    }
    public int GetHunger()
    {
      return _hunger;
    }

    public void SetExhaustion (int newExhaustion)
    {
      _exhaustion = newExhaustion;
    }
    public int GetExhaustion()
    {
      return _exhaustion;
    }

    public void SetBoredom (int newBoredom)
    {
      _boredom = newBoredom;
    }
    public int GetBoredom()
    {
      return _boredom;
    }

    public void SetLifespan (int newLifespan)
    {
      _lifespan = newLifespan;
    }
    public int GetLifespan()
    {
      return _lifespan;
    }
    public void SetName (string newName)
    {
      _name = newName;
    }
    public string GetName()
    {
      return _name;
    }
    public void SetIsHungry (bool newIsHungry)
    {
      _isHungry = newIsHungry;
    }
    public bool GetIsHungry()
    {
      return _isHungry;
    }
    public void SetIsExhausted (bool newIsExhausted)
    {
      _isExhausted = newIsExhausted;
    }
    public bool GetIsExhausted()
    {
      return _isExhausted;
    }
    public void SetIsBored (bool newIsBored)
    {
      _isBored = newIsBored;
    }
    public bool GetIsBored()
    {
      return _isBored;
    }
    public void SetHungerCounter (int newHungerCounter)
    {
      _hungerCounter = newHungerCounter;
    }
    public int GetHungerCounter()
    {
      return _hungerCounter;
    }
    public void SetExhaustionCounter (int newExhaustionCounter)
    {
      _exhaustionCounter = newExhaustionCounter;
    }
    public int GetExhaustionCounter()
    {
      return _exhaustionCounter;
    }
    public void SetBoredomCounter (int newBoredomCounter)
    {
      _boredomCounter = newBoredomCounter;
    }
    public int GetBoredomCounter()
    {
      return _boredomCounter;
    }
    public static Item Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
