# 2D SHOPKEEPER & CHARACTER CUSTOMIZATION

This repository contains the source code of a unity demo, developed in
approximately 48h, which simulates a 2d shopkeeper and character
customization.

## Screenshots

![Initial Area](Images/Screenshot_1.png "Initial Area")
![Shopkeeper House](Images/Screenshot_2.png "Shopkeeper's House")
![Shop UI](Images/Screenshot_3.png "Shop UI")
![Shop UI 2](Images/Screenshot_5.png "Shop UI")
![Saved Changes](Images/Screenshot_4.png "Saves Changes")

## Approach

### Day 1

> **May 4th (16:00 -> 00:00)**

Started by creating the scene using Unity's Tilemap and some [12x12
pixel art sprites][2d-assetpack], this part took some time, but I was having fun.

Next up, I introduced a playable 2D top down character, also from this pack,
which used sprite sheets to animate moving in the 4 main directions. At
this point, my main concern was the feel of the character moving in the world,
so I made sure it couldn't move diagonally, pokemon style.

![Initial Character Movement](Images/FirstCharacter.gif)

### Day 2

> **May 24th (12:00 -> 00:00)**  
> Note: Abandoned tech test due to some personal limitations, returned later on,
> at this date.

The problem with sprite sheet animations is that they are super impractical
for customizable characters (which I only realised later). For every new item,
the animation sprites multiply exponentially and eventually become unmanageable.

The solution for this was to get a [new character asset][character], with a
skeletal body. This way, each animation controls the character's bones, and the
sprites attached to the character can easily be modified, without affecting the
animation. The problem is that I only managed to find an asset with side
animations and sprites, which doesn't look the best when moving up or down.

> This is a problem that could easily be fixed with dedicated assets, introducing
> new sets of animations and skeletal bodies for up/down movement.

Once the character was replaced, I got to work on world interaction and
collisions, so that the character could interact with and "enter" the shopkeeper's
house.

To manage the gameplay differences between roaming around and being in the shop
customizing the character, I created game states and a game manager. Together with
dedicated overlay UI panels, this allows to seamlessly make it look like a new
scene is loaded when entering the shop, by creating a transition to a black screen,
disabling player control and moving it to a "shop area" (which is just a brown
background), and then revealing the shop UI controls. The same happens when leaving
the shop.

As for the shop menu itself, each "item card" contains info regarding what body
part it holds and respective sprites, when the "EQUIP" button is pressed, an event
containing that information is raised and managed by the Player Inventory, which
will switch the sprites relative to that body part with the new ones.

As for the information each card displays (EQUIPPED, OWNED, BUY), these are
managed by simply enabling and disabling empty game objects containing these
displays when a button is pressed. For example:

```c#
public void Equip()
{
    // Replaces "owned" with "equipped" layout.
    _ownedLayout.SetActive(false);
    _equippedLayout.SetActive(true);

    // Event raised with sprites and body part name.
    OnEquip?.Invoke(_sprites, _bodyPart);
}
```

Once the shop was functional for one of the items (started with shoulders),
the majority of the work was pretty much done.

### Day 3

> **May 25th (10:00 -> 12:00)**

All that was left to do now was give the player money, make it have
influence over the shop, and create the remaining shop pages for all the other
body parts, which was pretty much copying the shoulders tab, replacing the sprites.

```c#
public void Buy()
{
    // _data is a scriptable object that holds shared game data.

    // If the player can't afford this item, stop here.
    if (_data.Money < _value) return;

    // Charge player for item and update money display.
    _data.Money -= _value;
    OnTransaction?.Invoke();

    // Replaces "locked" with "equipped" layout.
    _locked.SetActive(false);
    _equipped.SetActive(true);
}
```

## References

All assets and code are of my own making with the exception of:

+ [Environment pixel art sprites][2d-assetpack]
+ [Character sprites & animations][character]

## Metadata

> Created by [André Santos].  
> 48h Programming test for undisclosed studio, 2023.

[2d-assetpack]:https://cypor.itch.io/12x12-rpg-tileset
[character]:https://assetstore.unity.com/packages/2d/characters/mighty-heroes-rogue-2d-fantasy-characters-pack-85770
[André Santos]:https://github.com/andrepucas
