# SekaiNi
Zyjacya

SekaiNi is a free, open-source, and standalone world-engine and toolbox for use in D&D. Specifically, this tool is designed for use by 
DMs in order to allow them to more easily generate, connect, and keep consistent smaller parts of a setting, allowing their
attention to be devoted to subjects of larger scale and interest.

Currently, each type has an editor (except generator), and they can be edited, saved, and loaded anywhere (or at least they should be. This is likely not the case quite yet as I am still developing much of the program. Testers appreciated in helping me find the problems.) This allows consistency in settings such that a change made in one place persists across all places it is referenced.

Moving forward, my primary concern at this point is to either make the D100 editor more robust, or to fix the issue I am 99% positive is going to pop up where saving and loading the entities on lists of other entities is going to not work as desired. 

One of the primary targets I have is to make a generator program that offers the ease-of-use of conventional generators with a deep power of customization. To do this, I plan to make "Node-by-node" generator, where you can create maps that sort D100 lists into a series of rolls, which can be rolled and produce a new entity that can then be saved for later use. Essentially, by customizing D100 lists, and then choosing which ones you want to use, in-order, you can greatly customize the way in which you roll for things like NPCs, items, shops, etc. Additionally, I hope to implement options that allow you to cause specified rolls to impact the probability and/or possibility of future rolls. For example, if you are generating a town NPC, you would be able to specify that a race roll of "Elf" results in the probability of blonde hair increasing by 30%, and the possbility of red hair being eliminated entirely. By doing this, and by creating this in a standardized file format, I hope that people can share their lists and consolodate them into a database which can then be used by anyone with this program. 



---------------- ----------------
Entity types:
---------------- ----------------
Character

D100 lists

Establishment/Building

Event

Faction

Guildhall

Item

Location

Module

Generator (Planned, need more work done on D100 lists and I need to learn more about data binding)
