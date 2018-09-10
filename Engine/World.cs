using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class World
    {
        public static readonly List<Item> Items = new List<Item>();
        public static readonly List<Monster> Monsters = new List<Monster>();
        public static readonly List<Quest> Quests = new List<Quest>();
        public static readonly List<Location> Locations = new List<Location>();

        public const int ItemIdRustySword = 1;
        public const int ItemIdRatTail = 2;
        public const int ItemIdPieceOfFur = 3;
        public const int ItemIdSnakeFang = 4;
        public const int ItemIdSnakeskin = 5;
        public const int ItemIdClub = 6;
        public const int ItemIdHealingPotion = 7;
        public const int ItemIdSpiderFang = 8;
        public const int ItemIdSpiderSilk = 9;
        public const int ItemIdAdventurerPass = 10;

        public const int MonsterIdRat = 1;
        public const int MonsterIdSnake = 2;
        public const int MonsterIdGiantSpider = 3;

        public const int QuestIdClearAlchemistGarden = 1;
        public const int QuestIdClearFarmersField = 2;

        public const int LocationIdHome = 1;
        public const int LocationIdTownSquare = 2;
        public const int LocationIdGuardPost = 3;
        public const int LocationIdAlchemistHut = 4;
        public const int LocationIdAlchemistsGarden = 5;
        public const int LocationIdFarmhouse = 6;
        public const int LocationIdFarmField = 7;
        public const int LocationIdBridge = 8;
        public const int LocationIdSpiderField = 9;

        static World()
        {
            PopulateItems();
            PopulateMonsters();
            PopulateQuests();
            PopulateLocations();
        }

        private static void PopulateItems()
        {
            Items.Add(new Weapon(ItemIdRustySword, "Rusty sword", "Rusty swords", 0, 5));
            Items.Add(new Item(ItemIdRatTail, "Rat tail", "Rat tails"));
            Items.Add(new Item(ItemIdPieceOfFur, "Piece of fur", "Pieces of fur"));
            Items.Add(new Item(ItemIdSnakeFang, "Snake fang", "Snake fangs"));
            Items.Add(new Item(ItemIdSnakeskin, "Snakeskin", "Snakeskins"));
            Items.Add(new Weapon(ItemIdClub, "Club", "Clubs", 3, 10));
            Items.Add(new HealingPotion(ItemIdHealingPotion, "Healing potion", "Healing potions", 5));
            Items.Add(new Item(ItemIdSpiderFang, "Spider fang", "Spider fangs"));
            Items.Add(new Item(ItemIdSpiderSilk, "Spider silk", "Spider silks"));
            Items.Add(new Item(ItemIdAdventurerPass, "Adventurer pass", "Adventurer passes"));
        }

        private static void PopulateMonsters()
        {
            Monster rat = new Monster(MonsterIdRat, "Rat", 5, 3, 10, 3, 3);
            rat.LootTable.Add(new LootItem(ItemById(ItemIdRatTail), 75, false));
            rat.LootTable.Add(new LootItem(ItemById(ItemIdPieceOfFur), 75, true));

            Monster snake = new Monster(MonsterIdSnake, "Snake", 5, 3, 10, 3, 3);
            snake.LootTable.Add(new LootItem(ItemById(ItemIdSnakeFang), 75, false));
            snake.LootTable.Add(new LootItem(ItemById(ItemIdSnakeskin), 75, true));

            Monster giantSpider = new Monster(MonsterIdGiantSpider, "Giant spider", 20, 5, 40, 10, 10);
            giantSpider.LootTable.Add(new LootItem(ItemById(ItemIdSpiderFang), 75, true));
            giantSpider.LootTable.Add(new LootItem(ItemById(ItemIdSpiderSilk), 25, false));

            Monsters.Add(rat);
            Monsters.Add(snake);
            Monsters.Add(giantSpider);
        }

        private static void PopulateQuests()
        {
            Quest clearAlchemistGarden =
                new Quest(
                    QuestIdClearAlchemistGarden,
                    "Clear the alchemist's garden",
                    "Kill rats in the alchemist's garden and bring back 3 rat tails. You will receive a healing potion and 10 gold pieces.", 20, 10);

            clearAlchemistGarden.QuestCompletionItems.Add(new QuestCompletionItem(ItemById(ItemIdRatTail), 3));

            clearAlchemistGarden.RewardItem = ItemById(ItemIdHealingPotion);

            Quest clearFarmersField =
                new Quest(
                    QuestIdClearFarmersField,
                    "Clear the farmer's field",
                    "Kill snakes in the farmer's field and bring back 3 snake fangs. You will receive an adventurer's pass and 20 gold pieces.", 20, 20);

            clearFarmersField.QuestCompletionItems.Add(new QuestCompletionItem(ItemById(ItemIdSnakeFang), 3));

            clearFarmersField.RewardItem = ItemById(ItemIdAdventurerPass);

            Quests.Add(clearAlchemistGarden);
            Quests.Add(clearFarmersField);
        }

        private static void PopulateLocations()
        {
            // Create each location
            Location home = new Location(LocationIdHome, "Home", "Your house. You really need to clean up the place.");

            Location townSquare = new Location(LocationIdTownSquare, "Town square", "You see a fountain.");

            Location alchemistHut = new Location(LocationIdAlchemistHut, "Alchemist's hut", "There are many strange plants on the shelves.");
            alchemistHut.QuestAvailableHere = QuestById(QuestIdClearAlchemistGarden);

            Location alchemistsGarden = new Location(LocationIdAlchemistsGarden, "Alchemist's garden", "Many plants are growing here.");
            alchemistsGarden.MonsterLivingHere = MonsterById(MonsterIdRat);

            Location farmhouse = new Location(LocationIdFarmhouse, "Farmhouse", "There is a small farmhouse, with a farmer in front.");
            farmhouse.QuestAvailableHere = QuestById(QuestIdClearFarmersField);

            Location farmersField = new Location(LocationIdFarmField, "Farmer's field", "You see rows of vegetables growing here.");
            farmersField.MonsterLivingHere = MonsterById(MonsterIdSnake);

            Location guardPost = new Location(LocationIdGuardPost, "Guard post", "There is a large, tough-looking guard here.", ItemById(ItemIdAdventurerPass));

            Location bridge = new Location(LocationIdBridge, "Bridge", "A stone bridge crosses a wide river.");

            Location spiderField = new Location(LocationIdSpiderField, "Forest", "You see spider webs covering covering the trees in this forest.");
            spiderField.MonsterLivingHere = MonsterById(MonsterIdGiantSpider);

            // Link the locations together
            home.LocationToNorth = townSquare;

            townSquare.LocationToNorth = alchemistHut;
            townSquare.LocationToSouth = home;
            townSquare.LocationToEast = guardPost;
            townSquare.LocationToWest = farmhouse;

            farmhouse.LocationToEast = townSquare;
            farmhouse.LocationToWest = farmersField;

            farmersField.LocationToEast = farmhouse;

            alchemistHut.LocationToSouth = townSquare;
            alchemistHut.LocationToNorth = alchemistsGarden;

            alchemistsGarden.LocationToSouth = alchemistHut;

            guardPost.LocationToEast = bridge;
            guardPost.LocationToWest = townSquare;

            bridge.LocationToWest = guardPost;
            bridge.LocationToEast = spiderField;

            spiderField.LocationToWest = bridge;

            // Add the locations to the static list
            Locations.Add(home);
            Locations.Add(townSquare);
            Locations.Add(guardPost);
            Locations.Add(alchemistHut);
            Locations.Add(alchemistsGarden);
            Locations.Add(farmhouse);
            Locations.Add(farmersField);
            Locations.Add(bridge);
            Locations.Add(spiderField);
        }

        public static Item ItemById(int id)
        {
            foreach (Item item in Items)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            return null;
        }

        public static Monster MonsterById(int id)
        {
            foreach (Monster monster in Monsters)
            {
                if (monster.Id == id)
                {
                    return monster;
                }
            }

            return null;
        }

        public static Quest QuestById(int id)
        {
            foreach (Quest quest in Quests)
            {
                if (quest.Id == id)
                {
                    return quest;
                }
            }

            return null;
        }

        public static Location LocationById(int id)
        {
            foreach (Location location in Locations)
            {
                if (location.Id == id)
                {
                    return location;
                }
            }

            return null;
        }
    }
}
