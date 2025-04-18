﻿namespace TextRPG_최다혜
{
    public class Player
    {
        public int playerLevel = 1;
        public string playerName = "르탄";
        public string classType = "전사";
        public int baseAttackPower = 10;
        public int baseDefensePower = 5;
        public int hp = 100;
        public int gold = 1500;

        public Item equippedWeapon;
        public Item equippedArmor;
    }

    public class Item
    {
        public string itemName;
        public string description;
        public int addAttackPower;
        public int addDefensePower;
        public int price;
        public bool isPurchased = false;
    }

    internal class Program
    {
        static Item[] itemList = new Item[]
        {
            new Item { itemName = "수련자 갑옷", addDefensePower = 5, description = "수련에 도움을 주는 갑옷입니다.", price = 1000 },
            new Item { itemName = "무쇠갑옷", addDefensePower = 9, description = "무쇠로 만들어져 튼튼한 갑옷입니다.", price = 2000 },
            new Item { itemName = "스파르타의 갑옷", addDefensePower = 15, description = "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", price = 3500 },
            new Item { itemName = "낡은 검", addAttackPower = 2, description = "쉽게 볼 수 있는 낡은 검 입니다.", price = 600 },
            new Item { itemName = "청동 도끼", addAttackPower = 5, description = "어디선가 사용됐던거 같은 도끼입니다.", price = 1500 },
            new Item { itemName = "스파르타의 창", addAttackPower = 7, description = "스파르타의 전사들이 사용했다는 전설의 창입니다.", price = 2500 },
            new Item { itemName = "수련자의 목걸이", addDefensePower = 2, description = "수련에 도움을 주는 목걸이입니다.", price = 500 }
        };

        static void Main(string[] args)
        {
            Player player = new Player();

            bool isGameRunning = true;

            while (isGameRunning)
            {
                PrintDivider();
                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n");
                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점\n");
                Console.WriteLine("0. 게임 종료\n");
                Console.Write(">> ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ShowStatus(player);
                        break;

                    case "2":
                        ShowInventory(player);
                        break;

                    case "3":
                        ShowShop(player);
                        break;

                    case "0":
                        PrintDivider();
                        Console.WriteLine("게임을 종료합니다.");
                        isGameRunning = false;
                        break;

                    default:
                        PrintDivider();
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }
        }

        static void ShowStatus(Player player)
        {
            string input = "";

            while (input != "0")
            {
                PrintDivider();
                Console.WriteLine("<상태 보기>");

                int weaponBonus = player.equippedWeapon?.addAttackPower ?? 0;
                int armorBonus = player.equippedArmor?.addDefensePower ?? 0;

                Console.WriteLine($"Lv     : {player.playerLevel}");
                Console.WriteLine($"직업   : {player.classType}");
                Console.WriteLine($"공격력 : {player.baseAttackPower + weaponBonus} {(weaponBonus > 0 ? $"(+{weaponBonus})" : "")}");
                Console.WriteLine($"방어력 : {player.baseDefensePower + armorBonus} {(armorBonus > 0 ? $"(+{armorBonus})" : "")}");
                Console.WriteLine($"체력   : {player.hp}");
                Console.WriteLine($"골드   : {player.gold}");

                Console.WriteLine("\n0. 나가기");
                Console.Write(">> ");
                input = Console.ReadLine();

                if (input != "0")
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }

        }


        static void ShowInventory(Player player)
        {
            string input = "";

            while (input != "0")
            {
                PrintDivider();
                Console.WriteLine("<인벤토리>");
                Console.WriteLine($"보유 골드: {player.gold} G");
                Console.WriteLine("");
                Console.WriteLine("[아이템 목록]");

                bool hasItem = false;
                foreach (var item in itemList)
                {
                    if (item.isPurchased)
                    {
                        hasItem = true;
                        string addPower = item.addAttackPower > 0
                            ? $"공격력 +{item.addAttackPower}"
                            : $"방어력 +{item.addDefensePower}";
                        Console.WriteLine($"- {item.itemName} | {addPower} | {item.description}");
                    }
                }

                if (!hasItem)
                {
                    Console.WriteLine("보유 중인 아이템이 없습니다.");
                }

                Console.WriteLine("\n1. 장착 관리\n\n0. 나가기\n>> ");
                input = Console.ReadLine();

                if (input == "1")
                {
                    ShowEquipManager(player);
                }
                else if (input != "0")
                {
                    PrintDivider();
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }

        static void ShowEquipManager(Player player)
        {
            string input = "";

            while (input != "0")
            {
                PrintDivider();
                Console.WriteLine("<장착 관리>");

                bool hasItem = false;
                for (int i = 0; i < itemList.Length; i++)
                {
                    var item = itemList[i];
                    if (item.isPurchased)
                    {
                        hasItem = true;
                        string equippedMark = (player.equippedWeapon == item || player.equippedArmor == item) ? "[E] " : "    ";
                        string stat = item.addAttackPower > 0 ? $"공격력 +{item.addAttackPower}" : $"방어력 +{item.addDefensePower}";
                        Console.WriteLine($"{i + 1}. {equippedMark}{item.itemName} | {stat} | {item.description}");
                    }
                }

                if (!hasItem)
                {
                    Console.WriteLine("보유 중인 아이템이 없습니다.");
                }

                Console.WriteLine("\n0. 나가기\n>> ");
                input = Console.ReadLine();

                if (int.TryParse(input, out int number) &&
                    number >= 1 && number <= itemList.Length)
                {
                    Item selected = itemList[number - 1];
                    if (selected.isPurchased)
                    {
                        if (selected.addAttackPower > 0)
                        {
                            // 무기 장착/해제
                            if (player.equippedWeapon == selected)
                            {
                                player.equippedWeapon = null;
                                Console.WriteLine($"'{selected.itemName}' 무기를 해제했습니다.");
                            }
                            else
                            {
                                player.equippedWeapon = selected;
                                Console.WriteLine($"'{selected.itemName}' 무기를 장착했습니다!");
                            }
                        }
                        else
                        {
                            // 방어구 장착/해제
                            if (player.equippedArmor == selected)
                            {
                                player.equippedArmor = null;
                                Console.WriteLine($"'{selected.itemName}' 방어구를 해제했습니다.");
                            }
                            else
                            {
                                player.equippedArmor = selected;
                                Console.WriteLine($"'{selected.itemName}' 방어구를 장착했습니다!");
                            }
                        }
                    }
                }
                else
                {
                    PrintDivider();
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }


        static void ShowShop(Player player)
        {
            string input = "";

            while (input != "0")
            {
                PrintDivider();
                Console.WriteLine("<상점>");
                Console.WriteLine($"보유 골드: {player.gold} G\n[아이템 목록]");

                for (int i = 0; i < itemList.Length; i++)
                {
                    Item item = itemList[i];
                    string addPower = item.addAttackPower > 0
                        ? $"공격력 +{item.addAttackPower}"
                        : $"방어력 +{item.addDefensePower}";
                    string status = item.isPurchased ? "구매완료" : $"{item.price} G";
                    Console.WriteLine($"{i + 1}. {status} | {item.itemName} | {addPower} | {item.description}");
                }

                Console.WriteLine("\n1. 아이템 구매\n\n0. 나가기\n>> ");
                input = Console.ReadLine();

                if (input == "1")
                {
                    ShowPurchaseItem(player);
                }
            }
        }

        static void ShowPurchaseItem(Player player)
        {
            string input = "";

            while (input != "0")
            {
                PrintDivider();
                Console.WriteLine("<아이템 구매>");
                Console.WriteLine($"보유 골드: {player.gold} G\n");

                for (int i = 0; i < itemList.Length; i++)
                {
                    var item = itemList[i];
                    string addPower = item.addAttackPower > 0 ? $"공격력 +{item.addAttackPower}" : $"방어력 +{item.addDefensePower}";
                    string status = item.isPurchased ? "구매완료" : $"{item.price} G";
                    Console.WriteLine($"{i + 1}. {status} | {item.itemName} | {addPower} | {item.description}");
                }

                Console.WriteLine("\n0. 나가기");
                Console.Write(">> ");
                input = Console.ReadLine();

                if (int.TryParse(input, out int number))
                {
                    if (number == 0)
                    {
                        break;
                    }
                    else if (number >= 1 && number <= itemList.Length)
                    {
                        Item selectedItem = itemList[number - 1];

                        if (!selectedItem.isPurchased)
                        {
                            if (player.gold >= selectedItem.price)
                            {
                                player.gold -= selectedItem.price;
                                selectedItem.isPurchased = true;
                                PrintDivider();
                                Console.WriteLine($"'{selectedItem.itemName}'을(를) 구매했습니다!");
                            }
                            else
                            {
                                PrintDivider();
                                Console.WriteLine("골드가 부족합니다.");
                            }
                        }
                        else
                        {
                            PrintDivider();
                            Console.WriteLine("이미 구매한 아이템입니다.");
                        }
                    }
                    else
                    {
                        PrintDivider();
                        Console.WriteLine("잘못된 입력입니다.");
                    }
                }
            }
        }

        static void PrintDivider()
        {
            Console.WriteLine(new string('-', 40));
        }
    }
}