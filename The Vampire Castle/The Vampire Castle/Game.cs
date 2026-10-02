class Game
{
    private Player player;
    private Room room7;
    private bool playing;

    public Game()
    {
        CreateWorld();
        playing = true;
    }

    public void CreateWorld()
    {
        Room hallway = new Room(
            "Hallway",
            "A cold hallway. A free key sits on the floor.",
            null
        );

        Room room1 = new Room(
            "Room 1: Dracula's Chamber",
            "A damp stone chamber.",
            new Vampire("Dracula", "What is 3 + 4?", 7)
        );

        Room room2 = new Room(
            "Room 2: Carmilla's Room",
            "Cobwebs cover the corners.",
            new Vampire("Carmilla", "What is 9 - 2?", 7)
        );

        Room room3 = new Room(
            "Room 3: Lestat's Room",
            "Candles flicker on the walls.",
            new Vampire("Lestat", "What is 6 * 2?", 12)
        );

        Room room4 = new Room(
            "Room 4: Damon's Room",
            "A cold draft passes through.",
            new Vampire("Damon", "What is 20 / 4?", 5)
        );

        Room room5 = new Room(
            "Room 5: Stefan´s Room",
            "Bones are scattered on the floor.",
            new Vampire("Stefan", "What is 8 + 8?", 16)
        );

        Room room6 = new Room(
            "Room 6: Elena's Room",
            "A locked cabinet stands in the corner.",
            new Vampire("Elena", "What is 10 * 10?", 100)
        );

        room7 = new Room(
            "Room 7: The Rescue Room",
            "Your friend lies weakly against the wall.",
            null
        );

        // Connect rooms

        hallway.AddExit("north", room1);

        room1.AddExit("south", hallway);
        room1.AddExit("north", room2);

        room2.AddExit("south", room1);
        room2.AddExit("north", room3);

        room3.AddExit("south", room2);
        room3.AddExit("north", room4);

        room4.AddExit("south", room3);
        room4.AddExit("north", room5);

        room5.AddExit("south", room4);
        room5.AddExit("north", room6);

        room6.AddExit("south", room5);
        room6.AddExit("north", room7);

        room7.AddExit("south", room6);

        // Items

        Item rustyKey = new Item(
            "Rusty Key",
            "An old rusty key."
        );

        Item bronzeKey = new Item(
            "Bronze Key",
            "A small bronze key."
        );

        Item ironKey = new Item(
            "Iron Key",
            "A heavy iron key."
        );

        Item silverKey = new Item(
            "Silver Key",
            "A shiny silver key."
        );

        Item goldenKey = new Item(
            "Golden Key",
            "A valuable golden key."
        );

        Item antidote = new Item(
            "Antidote",
            "Medicine that can save your friend."
        );

        hallway.AddItem(rustyKey);
        room1.AddItem(bronzeKey);
        room2.AddItem(ironKey);
        room3.AddItem(silverKey);
        room4.AddItem(goldenKey);
        room6.AddItem(antidote);

        // NPCs

        NPC ghost = new NPC(
            "Ghost",
            new List<string>
            {
                "I have wandered here for centuries...",
                "The cold bites at my legs, even though I have none.",
                "Have you seen my missing hand?"
            }
        );

        NPC prisoner = new NPC(
            "Prisoner",
            new List<string>
            {
                "They locked me in here long ago. I don't remember why.",
                "The guards stopped coming years ago.",
                "Do you have food? No? ...I thought not."
            }
        );

        hallway.AddNpc(ghost);
        room4.AddNpc(prisoner);

        player = new Player(hallway);
    }

    public void Start()
    {
        Console.WriteLine("================================");
        Console.WriteLine("       VAMPIRE CASTLE");
        Console.WriteLine("================================");
        Console.WriteLine();

        Console.WriteLine(
            "Your friend is dying. Find the antidote and bring it to Room 7."
        );

        Console.WriteLine();
        Console.WriteLine("Type 'help' to see the available commands.");
        Console.WriteLine();

        while (playing)
        {
            ShowRoom();

            if (player.CurrentRoom.Guard != null &&
                !player.CurrentRoom.GuardDefeated)
            {
                FightVampire();
            }

            if (!playing)
            {
                break;
            }

            CheckWin();

            if (!playing)
            {
                break;
            }

            Console.Write("> ");
            string input = Console.ReadLine();

            InterpretCommand(input);

            Console.WriteLine();
        }
    }

    private void ShowRoom()
    {
        Console.WriteLine();
        Console.WriteLine("--- " + player.CurrentRoom.Name + " ---");
        Console.WriteLine(player.CurrentRoom.Description);

        Console.Write("Exits: ");

        foreach (string direction in player.CurrentRoom.Exits.Keys)
        {
            Console.Write(direction + " ");
        }

        Console.WriteLine();

        if (player.CurrentRoom.Items.Count > 0)
        {
            Console.Write("Items: ");

            foreach (Item item in player.CurrentRoom.Items)
            {
                Console.Write(item.Name + " ");
            }

            Console.WriteLine();
        }

        if (player.CurrentRoom.Npcs.Count > 0)
        {
            Console.Write("People here: ");

            foreach (NPC npc in player.CurrentRoom.Npcs)
            {
                Console.Write(npc.Name + " ");
            }

            Console.WriteLine();
        }
    }

    private void FightVampire()
    {
        Vampire vampire = player.CurrentRoom.Guard;

        Console.WriteLine();
        Console.WriteLine(
            vampire.Name + " blocks your way!"
        );

        bool passed = false;

        while (!passed)
        {
            Console.WriteLine(vampire.Question);
            Console.Write("Answer: ");

            int guess = int.Parse(Console.ReadLine());

            if (vampire.AskQuestion(guess))
            {
                Console.WriteLine(
                    vampire.Name + ": Correct. You may pass."
                );

                player.CurrentRoom.DefeatGuard();
                passed = true;
            }
            else
            {
                Console.WriteLine(
                    vampire.Name + ": Wrong! Try again."
                );
            }
        }
    }

    private void CheckWin()
    {
        if (player.CurrentRoom == room7)
        {
            if (player.HasItem("Antidote"))
            {
                Console.WriteLine();
                Console.WriteLine(
                    "You give the antidote to your friend."
                );

                Console.WriteLine(
                    "They recover. You win!"
                );
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine(
                    "You have nothing to give your friend..."
                );

                Console.WriteLine(
                    "Game over."
                );
            }

            playing = false;
        }
    }

    public void InterpretCommand(string input)
    {
        if (input == "inventory")
        {
            player.ShowInventory();
        }
        else if (input == "look")
        {
            ShowRoom();
        }
        else if (input == "help")
        {
            ShowHelp();
        }
        else if (input == "quit")
        {
            Console.WriteLine("The game ends. Goodbye!");
            playing = false;
        }
        else if (input == "go north")
        {
            Move("north");
        }
        else if (input == "go south")
        {
            Move("south");
        }
        else if (input == "go east")
        {
            Move("east");
        }
        else if (input == "go west")
        {
            Move("west");
        }
        else if (input == "take")
        {
            TakeItem();
        }
        else if (input == "talk")
        {
            TalkToNpc();
        }
        else
        {
            Console.WriteLine("I don't understand that command.");
        }
    }

    private void Move(string direction)
    {
        if (player.CurrentRoom.Exits.ContainsKey(direction))
        {
            Room nextRoom = player.CurrentRoom.Exits[direction];

            player.MoveTo(nextRoom);
        }
        else
        {
            Console.WriteLine("You can't go that way.");
        }
    }

    private void TakeItem()
    {
        if (player.CurrentRoom.Items.Count == 0)
        {
            Console.WriteLine("There are no items here.");
            return;
        }

        Console.WriteLine("What do you want to take?");

        foreach (Item item in player.CurrentRoom.Items)
        {
            Console.WriteLine("- " + item.Name);
        }

        Console.Write("> ");
        string itemName = Console.ReadLine();

        Item foundItem = null;

        foreach (Item item in player.CurrentRoom.Items)
        {
            if (item.Name == itemName)
            {
                foundItem = item;
            }
        }

        if (foundItem != null)
        {
            player.TakeItem(foundItem);

            Console.WriteLine(
                "You take the " + foundItem.Name + "."
            );
        }
        else
        {
            Console.WriteLine("That item is not here.");
        }
    }

    private void TalkToNpc()
    {
        if (player.CurrentRoom.Npcs.Count == 0)
        {
            Console.WriteLine("There is nobody here to talk to.");
            return;
        }

        Console.WriteLine("Who do you want to talk to?");

        foreach (NPC npc in player.CurrentRoom.Npcs)
        {
            Console.WriteLine("- " + npc.Name);
        }

        Console.Write("> ");
        string name = Console.ReadLine();

        NPC foundNpc = null;

        foreach (NPC npc in player.CurrentRoom.Npcs)
        {
            if (npc.Name == name)
            {
                foundNpc = npc;
            }
        }

        if (foundNpc != null)
        {
            Console.WriteLine(
                foundNpc.Name + ": " + foundNpc.NextLine()
            );
        }
        else
        {
            Console.WriteLine("That person is not here.");
        }
    }

    private void ShowHelp()
    {
        Console.WriteLine();
        Console.WriteLine("Available commands:");
        Console.WriteLine("go north");
        Console.WriteLine("go south");
        Console.WriteLine("go east");
        Console.WriteLine("go west");
        Console.WriteLine("take");
        Console.WriteLine("look");
        Console.WriteLine("inventory");
        Console.WriteLine("talk");
        Console.WriteLine("help");
        Console.WriteLine("quit");
    }
}