namespace ConsoleProject
{
    internal class Program
    {
        enum Scene { Name, Select, Character, Confirm, Town, Home, Shop, Church, Forest, Canyon, Swarm, River }
        enum Job { Warrior = 1, Mage, Priest, Archer, Rogue }
        enum Monster { Slime, Stump, Croco }
        struct Data
        {
            public bool run;
            public Scene scene;
            public string name;
            public Job job;
            public int currentHP;
            public int currentMP;
            public int maxHP;
            public int maxMP;
            public int STR;
            public int INT;
            public int DEX;
            public int gold;
            public int price;
        }
        static Data data;

        struct Item
        {
            public string itemName;
            public int count_00;
            public int count_01;
            public int count_02;
            public int count_03;
            public int count_04;
            public int count_05;
            public int count_06;
            public int inven;
            
        }
        
        static Item item;

        static void Main(string[] args)
        {
            //게임 구동
            GameStart();

            while (data.run)
            {
                Run();
            }

            GameEnd();
        }
        //게임 시작
        static void GameStart()
        {
            data = new Data();

            int count_00 = 0;
            int count_01 = 0;
            int count_02 = 0;
            int count_03 = 0;
            int count_04 = 0;
            int count_05 = 0;
            int count_06 = 0;

            data.run = true;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("*****************************************************");
            Console.WriteLine("*                                                   *");
            Console.WriteLine("*                  Legend of Text                   *");
            Console.WriteLine("*                                                   *");
            Console.WriteLine("*****************************************************");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("                    Press Any Key                    ");
            Console.ReadKey();
        }

        //게임 종료
        static void GameEnd()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*****************************************************");
            Console.WriteLine("*                                                   *");
            Console.WriteLine("*                     Game Over                     *");
            Console.WriteLine("*                                                   *");
            Console.WriteLine("*****************************************************");
            Console.ResetColor();
        }

        //게임 구동 과정
        static void Run()
        {
            Console.Clear();

            switch (data.scene)
            {
                case Scene.Name:
                    NameScene();
                    break;
                case Scene.Select:
                    SelectScene();
                    break;
                case Scene.Character:
                    CharacterScene();
                    break;
                case Scene.Confirm:
                    ConfirmScene();
                    break;
                case Scene.Town:
                    TownScene();
                    break;
                case Scene.Home:
                    HomeScene();
                    break;
                case Scene.Shop:
                    ShopScene();
                    break;
                // case Scene.Church:
                //     ChurchScene();
                //     break;
                case Scene.Forest:
                    ForestScene();
                    break;
                //  case Scene.Canyon:
                //      CanyonScene();
                //      break;
                case Scene.Swarm:
                    SwarmScene();
                    break;
                    //  case Scene.River:
                    //      RiverScene();
                    //      break;
            }
        }
        
        //아이템 인벤토리
        static void InvenSave()
        {
            string[] inventory = new string[7] {"HP포션", "롱소드", "나무 스태프", "쌍단검",
                                                             "철 화살", "성경책", "이름모를 약초"};
            int countSum = 0;

            if (item.count_00 > 0)
            {
                Console.WriteLine($"{inventory[0]} {item.count_00}개");
            }
            if (item.count_01 > 0)
            {
                Console.WriteLine($"{inventory[1]} {item.count_01}개");
            }
            if (item.count_02 > 0)
            {
                Console.WriteLine($"{inventory[2]} {item.count_02}개");
            }
            if (item.count_03 > 0)
            {
                Console.WriteLine($"{inventory[3]} {item.count_03}개");
            }
            if (item.count_04 > 0)
            {
                Console.WriteLine($"{inventory[4]} {item.count_04}개");
            }
            if (item.count_05 > 0)
            {
                Console.WriteLine($"{inventory[5]} {item.count_05}개");
            }
            if (item.count_06 > 0)
            {
                Console.WriteLine($"{inventory[6]} {item.count_06}개");
            }
        }

        //캐릭터 프로필
        static void CharacterScene()
        {
            Console.WriteLine("*****************************************************");
            Console.WriteLine("                     [프로필]                         ");
            Console.WriteLine($"이름: {data.name,-6} 직업: {data.job,-6}");
            Console.WriteLine($"HP: {data.currentHP,+2} / {data.maxHP}");
            Console.WriteLine($"MP: {data.currentMP,+2} / {data.maxMP}");
            Console.WriteLine($"STR: {data.STR,-2} / INT: {data.INT,-2} / DEX: {data.DEX,-2}");
            Console.WriteLine($"골드: {data.gold,+5}G");
            Console.WriteLine("*****************************************************");
            Console.WriteLine();
            Console.WriteLine("*****************************************************");
            Console.WriteLine("                     [인벤토리]                       ");
            Console.WriteLine();
            InvenSave();
            Console.WriteLine("*****************************************************");
            Console.WriteLine();
        }
        //텍스트 타이밍 및 로딩 설정
        static void Loading(float seconds)
        {
            Thread.Sleep((int)(seconds * 1000));
        }
        //캐릭터 닉네임 설정
        static void NameScene()
        {
            Console.Write("캐릭터에 사용할 이름을 입력해주세요: ");
            data.name = Console.ReadLine();

            if (data.name == "")
            {
                Console.WriteLine("잘못 입력했습니다. 다시 입력해주세요.");
                return;
            }
            data.scene = Scene.Select;
        }
        //직업 선택
        static void SelectScene()
        {
            Console.WriteLine("캐릭터의 직업을 선택해주세요(해당 직업의 번호 입력): ");
            Console.WriteLine("1. 전사(Warrior)");
            Console.WriteLine("2. 마법사(Mage)");
            Console.WriteLine("3. 성직자(Priest)");
            Console.WriteLine("4. 궁수(Archer)");
            Console.WriteLine("5. 도적(Rogue)");

            if (int.TryParse(Console.ReadLine(), out int selectNum) == false)
            {
                Console.WriteLine("잘못 입력했습니다. 해당 직업의 번호를 입력해주세요.");
                return;
            }

            switch ((Job)selectNum)
            {
                case Job.Warrior:
                    data.job = Job.Warrior;
                    data.maxHP = 200;
                    data.currentHP = data.maxHP;
                    data.STR = 20;
                    data.INT = 6;
                    data.DEX = 10;
                    data.gold = 300;
                    break;
                case Job.Mage:
                    data.job = Job.Mage;
                    data.maxHP = 100;
                    data.currentHP = data.maxHP;
                    data.STR = 6;
                    data.INT = 20;
                    data.DEX = 8;
                    data.gold = 300;
                    break;
                case Job.Priest:
                    data.job = Job.Priest;
                    data.maxHP = 100;
                    data.currentHP = data.maxHP;
                    data.STR = 8;
                    data.INT = 18;
                    data.DEX = 8;
                    data.gold = 0;
                    break;
                case Job.Archer:
                    data.job = Job.Archer;
                    data.maxHP = 150;
                    data.currentHP = data.maxHP;
                    data.STR = 10;
                    data.INT = 8;
                    data.DEX = 18;
                    data.gold = 300;
                    break;
                case Job.Rogue:
                    data.job = Job.Rogue;
                    data.maxHP = 120;
                    data.currentHP = data.maxHP;
                    data.STR = 8;
                    data.INT = 10;
                    data.DEX = 20;
                    data.gold = 300;
                    break;
            }
            data.scene = Scene.Confirm;
        }
        //입력 및 선택 내용 확인
        static void ConfirmScene()
        {
            Console.Write($"선택한 직업은 {data.job}가 맞습니까 ?(y/n): ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "y":
                case "Y":
                case "ㅛ":
                    Console.Clear();
                    Console.WriteLine("게임을 시작합니다...");
                    Loading(2);
                    data.scene = Scene.Town;
                    break;
                case "n":
                case "N":
                case "ㅜ":
                    data.scene = Scene.Select;
                    break;
            }
        }
        //캐릭터 사망
        static void ChrDie()
        {
            if (data.currentHP < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("******************You Died******************");
                Console.ResetColor();
                Loading(2);
            }
            Console.Clear();
            Console.WriteLine("마을로 돌아갑니다...");
            Loading(2);
            data.scene = Scene.Town;
        }
        //게임 씬 1. 마을
        static void TownScene()
        {
            CharacterScene();
            Console.WriteLine("[사람들이 붐비는 활기찬 시작의 마을이다. 왠지 모를 정겨운 향기가 난다.]");
            Loading(1);
            Console.WriteLine("[어디로 이동하겠습니까?]");
            Console.WriteLine("1.숙소");
            Console.WriteLine("2.상점");
            Console.WriteLine("3.교회");
            Console.WriteLine("4.초심자의 숲");
            Console.WriteLine("5.위험한 늪지대");
            Console.Write("선택 : ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                case "숙소":
                    Console.Clear();
                    Console.WriteLine("포근한 숙소로 이동합니다...");
                    Loading(2);
                    data.scene = Scene.Home;
                    break;
                case "2":
                case "상점":
                    Console.Clear();
                    Console.WriteLine("단골 상점으로 이동합니다...");
                    Loading(2);
                    data.scene = Scene.Shop;
                    break;
                case "3":
                case "교회":
                    Console.Clear();
                    Console.WriteLine("젠장, 나는 또 숭배를 해야만 해.");
                    Loading(1);
                    Console.WriteLine("성스러운 교회로 이동합니다...");
                    Loading(2);
                    data.scene = Scene.Church;
                    break;
                case "4":
                case "초심자의 숲":
                    Console.Clear();
                    Console.WriteLine("수련을 위해 초심자의 숲으로 이동합니다...");
                    Loading(2);
                    data.scene = Scene.Forest;
                    break;
                case "5":
                case "위험한 늪지대":
                    Console.Clear();
                    Console.WriteLine("위험이 도사리는 늪지대로 이동합니다...");
                    Loading(2);
                    data.scene = Scene.Swarm;
                    break;
            }
        }
        //게임 씬 2. 숙소
        static void HomeScene()
        {
            CharacterScene();
            Console.WriteLine("[포근한 침대가 날 유혹하는 숙소에 도착했다. 이불 밖은 위험해!]");
            Loading(1);
            Console.WriteLine("[어디로 이동하겠습니까?]");
            Console.WriteLine("1.마을");
            Console.WriteLine("2.상점");
            Console.WriteLine("3.교회");
            Console.Write("선택 : ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                case "마을":
                    Console.Clear();
                    Console.WriteLine("마을로 이동합니다...");
                    Loading(2);
                    data.scene = Scene.Town;
                    break;
                case "2":
                case "상점":
                    Console.Clear();
                    Console.WriteLine("단골 상점으로 이동합니다...");
                    Loading(2);
                    data.scene = Scene.Shop;
                    break;
                case "3":
                case "교회":
                    Console.Clear();
                    Console.WriteLine("젠장, 나는 또 숭배를 해야만 해.");
                    Console.WriteLine("성스러운 교회로 이동합니다...");
                    Loading(2);
                    data.scene = Scene.Church;
                    break;
            }
        }
        //게임 씬 3. 상점
        static void ShopScene()
        {
            CharacterScene();
            Console.WriteLine("[주인장이 날 반겨주는 이 곳, 내 단골 상점이다.]");
            Loading(1);
            Console.WriteLine("[필요한 물건을 구매하세요.]");
            Console.WriteLine($"1. HP포션 : {20}G");
            Console.WriteLine($"2. 롱소드 : {200}G");
            Console.WriteLine($"3. 나무 스태프 : {200}G");
            Console.WriteLine($"4. 쌍단검 : {200}G");
            Console.WriteLine($"5. 철 화살 : {200}G");
            Console.WriteLine($"6. 성경책 : {200}G");
            Console.WriteLine($"7. 마을로 돌아가기");
            Console.Write("선택 : ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                case "HP포션":
                    if (data.gold >= 20)
                    {
                        Console.WriteLine($"HP 포션을 구매했습니다. 현재 소지 골드는 {data.gold - 20}골드입니다.");
                        item.count_00++;
                        data.gold -= 20;
                        Loading(2);
                        
                    }
                    else if (data.gold < 20)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("골드가 부족합니다.");
                        Console.WriteLine("상점주인 : 뭐야, 골드가 없잖아? 빨리 가서 벌어오란 말이야!");
                        Console.ResetColor();

                        Loading(2);
                        Console.Clear();
                        Console.WriteLine("상점에서 쫓겨나 마을로 돌아갑니다...");
                        Loading(2);
                        data.scene = Scene.Town;
                    }
                    break;
                case "2":
                case "롱소드":
                    if (data.gold >= 200)
                    {
                        Console.WriteLine($"롱소드를 구매했습니다. 현재 소지 골드는 {data.gold - 200}골드입니다.");
                        item.count_01++;
                        data.gold -= 200;
                        Loading(2);
                        InvenSave();
                    }
                    else if (data.gold < 200)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("골드가 부족합니다.");
                        Console.WriteLine("상점주인 : 뭐야, 골드가 없잖아? 빨리 가서 벌어오란 말이야!");
                        Console.ResetColor();

                        Loading(2);
                        Console.Clear();
                        Console.WriteLine("상점에서 쫓겨나 마을로 돌아갑니다...");
                        Loading(2);
                        data.scene = Scene.Town;
                    }
                    break;
                case "3":
                case "나무 스태프":
                    if (data.gold >= 200)
                    {
                        Console.WriteLine($"나무 스태프를 구매했습니다. 현재 소지 골드는 {data.gold - 200}골드입니다.");
                        item.count_02++;
                        data.gold -= 200;
                        Loading(2);
                        InvenSave();
                    }
                    else if (data.gold < 200)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("골드가 부족합니다.");
                        Console.WriteLine("상점주인 : 뭐야, 골드가 없잖아? 빨리 가서 벌어오란 말이야!");
                        Console.ResetColor();

                        Loading(2);
                        Console.Clear();
                        Console.WriteLine("상점에서 쫓겨나 마을로 돌아갑니다...");
                        Loading(2);
                        data.scene = Scene.Town;
                    }
                    break;
                case "4":
                case "쌍단검":
                    if (data.gold >= 200)
                    {
                        Console.WriteLine($"쌍단검을 구매했습니다. 현재 소지 골드는 {data.gold - 200}골드입니다.");
                        item.count_03++;
                        data.gold -= 200;
                        Loading(2);
                        InvenSave();
                    }
                    else if (data.gold < 200)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("골드가 부족합니다.");
                        Console.WriteLine("상점주인 : 뭐야, 골드가 없잖아? 빨리 가서 벌어오란 말이야!");
                        Console.ResetColor();

                        Loading(2);
                        Console.Clear();
                        Console.WriteLine("상점에서 쫓겨나 마을로 돌아갑니다...");
                        Loading(2);
                        data.scene = Scene.Town;
                    }
                    break;
                case "5":
                case "철 화살":
                    if (data.gold >= 200)
                    {
                        Console.WriteLine($"철 화살을 구매했습니다. 현재 소지 골드는 {data.gold - 200}골드입니다.");
                        item.count_04++;
                        data.gold -= 200;
                        Loading(2);
                        InvenSave();
                    }
                    else if (data.gold < 200)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("골드가 부족합니다.");
                        Console.WriteLine("상점주인 : 뭐야, 골드가 없잖아? 빨리 가서 벌어오란 말이야!");
                        Console.ResetColor();

                        Loading(2);
                        Console.Clear();
                        Console.WriteLine("상점에서 쫓겨나 마을로 돌아갑니다...");
                        Loading(2);
                        data.scene = Scene.Town;
                    }
                    break;
                case "6":
                case "성경책":
                    if (data.gold >= 200)
                    {
                        Console.WriteLine($"성경책을 구매했습니다. 현재 소지 골드는 {data.gold - 200}골드입니다.");
                        item.count_05++;
                        data.gold -= 200;
                        Loading(2);
                        InvenSave();
                    }
                    else if (data.gold < 200)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("골드가 부족합니다.");
                        Console.WriteLine("상점주인 : 뭐야, 골드가 없잖아? 빨리 가서 벌어오란 말이야!");
                        Console.ResetColor();

                        Loading(2);
                        Console.Clear();
                        Console.WriteLine("상점에서 쫓겨나 마을로 돌아갑니다...");
                        Loading(2);
                        data.scene = Scene.Town;
                    }
                    break;
                case "7":
                    Console.Clear();
                    Console.WriteLine("마음에 드는게 없어서 마을로 돌아갑니다...");
                    Loading(2);
                    data.scene = Scene.Town;
                    break;
            }

        }
        //게임 씬 4. 수련의 숲
        static void ForestScene()
        {
            int slime = 80;

            Console.WriteLine("[초심자가 수련하기 좋은 포근한 숲입니다.]");
            Loading(1);
            Console.WriteLine("[갑작스럽게 당신 앞에 슬라임이 나타났습니다.]");
            Loading(1);
            Console.WriteLine();
            Console.WriteLine("[당신의 행동을 선택해주세요]");
            Console.WriteLine("1. 슬라임을 공격한다.");
            Console.WriteLine("2. 슬라임을 주시하며 공격 마법을 시전한다.(Mage)");
            Console.WriteLine("3. 슬라임에게 정화 마법을 시전한다.(Priest)");
            Console.WriteLine("4. 슬라임이 눈치채지 못하게 뒤로 접근하여 공격한다.(Rogue)");
            Console.WriteLine("5. 슬라임을 피해 협곡으로 이동한다.");
            Console.WriteLine("6. 슬라임에게서 도망쳐 마을로 이동한다.");
            Console.Write("선택 : ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine("당신은 슬라임을 공격했습니다.");

                    if (data.job == Job.Warrior)
                    {
                        Console.WriteLine($"{data.name}의 공격에 슬라임은 한 방에 죽었습니다.");
                        Loading(1);
                        Console.WriteLine("50 골드를 획득했다!");
                        data.gold += 50;
                    }

                    Console.WriteLine($"{data.name}의 공격에 슬라임은 30의 데미지를 입었습니다.");
                    Loading(1);
                    Console.WriteLine($"{slime - 30}의 체력은 50 남았습니다.");
                    slime -= 30;
                    if (slime < 0)
                    {
                        Console.WriteLine($"{data.name}은/는 슬라임을 처치했습니다.");
                        Loading(1);
                        Console.WriteLine("50 골드를 획득했다!");
                        data.gold += 50;
                    }
                    break;
                case "2":
                    if (data.job == Job.Mage)
                    {
                        Console.WriteLine($"{data.name}의 공격 마법에 슬라임은 흔적도 없이 사라졌습니다.");
                        Loading(1);
                        Console.WriteLine("50 골드를 획득했다!");
                        data.gold += 50;
                    }
                    else
                    {
                        Console.Write($"{data.name}은/는 공격 마법을 쓸 수 없습니다.");
                        Loading(1);
                        Console.WriteLine($"{data.name}이/가 안절부절하는 사이 슬라임에게 공격을 받았습니다.");
                        Loading(1);
                        Console.WriteLine($"{data.name}은/는 20의 데미지를 받았습니다.");
                        data.currentHP -= 20;
                    }
                    break;
                case "3":
                    if (data.job == Job.Priest)
                    {
                        Console.WriteLine($"{data.name}의 정화 마법은 슬라임에게 효과가 없었습니다.");
                        Loading(1);
                        Console.WriteLine($"{data.name}이/가 안절부절하는 사이 슬라임에게 공격을 받았습니다.");
                        Loading(1);
                        Console.WriteLine($"{data.name}은/는 20의 데미지를 받았습니다.");
                        data.currentHP -= 20;
                    }
                    else
                    {
                        Console.Write($"{data.name}은/는 정화 마법을 쓸 수 없습니다.");
                        Loading(1);
                        Console.WriteLine($"{data.name}이/가 안절부절하는 사이 슬라임에게 공격을 받았습니다.");
                        Loading(1);
                        Console.WriteLine($"{data.name}은/는 20의 데미지를 받았습니다.");
                        data.currentHP -= 20;
                    }
                    break;
                case "4":
                    if (data.job == Job.Rogue)
                    {
                        Console.WriteLine($"{data.name}의 재빠른 암기에 슬라임은 순식간에 숨이 끊겼습니다.");
                        Loading(1);
                        Console.WriteLine("50 골드를 획득했다!");
                        data.gold += 50;
                    }
                    else
                    {
                        Console.Write($"{data.name}은/는 그렇게 빠르지 않습니다...");
                        Loading(1);
                        Console.WriteLine($"{data.name}이/가 누가봐도 느리게 움직이는 사이 슬라임에게 공격을 받았습니다.");
                        Loading(1);
                        Console.WriteLine($"{data.name}은/는 20의 데미지를 받았습니다.");
                        data.currentHP -= 20;
                    }
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine("슬라임을 피해 협곡으로 이동합니다...");
                    Loading(2);
                    data.scene = Scene.Town;
                    break;
                case "6":
                    Console.Clear();
                    Console.WriteLine("슬라임에게서 도망쳐 마을로 이동합니다...");
                    Loading(2);
                    data.scene = Scene.Town;
                    break;
            }
        }
        //게임 씬 5. 위험한 늪지대
        static void SwarmScene()
        {
            int croco = 500;

            Console.WriteLine("[온갖 위험이 도사리는 늪지대에 진입했습니다.]");
            Loading(1);
            Console.WriteLine("[늪에서 거대한 크로코가 나타났습니다.]");
            Loading(1);
            Console.WriteLine();
            Console.WriteLine("[당신의 행동을 선택해주세요]");
            Console.WriteLine("1. 크로코를 공격한다.");
            Console.WriteLine("2. 크로코를 주시하며 공격 마법을 시전한다.(Mage)");
            Console.WriteLine("3. 크로코가 눈치채지 못하게 뒤로 접근하여 공격한다.(Rogue)");
            Console.WriteLine("4. 크로코에게서 도망쳐 마을로 이동한다.");
            Console.Write("선택 : ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine($"{data.name}은/는 크로코 공격했습니다.");
                    Loading(1);
                    Console.WriteLine($"{data.name}의 공격에 크로코 30의 데미지를 입었습니다.");
                    Loading(1);
                    Console.WriteLine($"슬라임의 체력은 {croco - 30} 남았습니다.");
                    croco -= 30;
                    if (croco < 0)
                    {
                        Console.WriteLine($"{data.name}은/는 슬라임을 처치했습니다.");
                        Loading(1);
                        Console.WriteLine("200 골드를 획득했다!");
                        data.gold += 200;
                    }
                    break;
                case "2":
                    if (data.job == Job.Mage)
                    {
                        Console.WriteLine($"{data.name}의 공격 마법에 크로코는 큰 데미지를 받았습니다.");
                        Loading(1);
                        Console.WriteLine($"{data.name}의 공격 마법에 크로코는 100의 데미지를 입었습니다.");
                        Loading(1);
                        Console.WriteLine($"슬라임의 체력은 {croco - 100} 남았습니다.");
                        croco -= 100;
                        if (croco < 0)
                        {
                            Console.WriteLine($"{data.name}은/는 슬라임을 처치했습니다.");
                            Loading(1);
                            Console.WriteLine("200 골드를 획득했다!");
                            data.gold += 200;
                        }
                    }
                    else
                    {
                        Console.Write($"{data.name}은/는 공격 마법을 쓸 수 없습니다.");
                        Loading(1);
                        Console.WriteLine($"{data.name}이/가 안절부절하는 사이 크로코에게 공격을 받았습니다.");
                        Loading(1);
                        Console.WriteLine($"{data.name}은/는 70의 데미지를 받았습니다.");
                        data.currentHP -= 70;
                    }
                    break;
                case "3":
                    if (data.job == Job.Rogue)
                    {
                        Console.WriteLine($"{data.name}은/는 크로코에게 재빠르게 암기로 다가갔습니다.");
                        Loading(1);
                        Console.WriteLine($"하지만 크로코는 이를 알아채고 {data.name}을/를 큰 입으로 물었습니다.");
                        Loading(1);
                        Console.WriteLine($"{data.name}은/는 고통에 몸부림치다 사망했습니다.");
                        data.currentHP -= 130;
                        ChrDie();
                    }
                    else
                    {
                        Console.Write($"{data.name}은/는 그렇게 빠르지 않습니다...");
                        Loading(1);
                        Console.WriteLine($"{data.name}이/가 누가봐도 느리게 움직이는 사이 크로코에게 공격을 받았습니다.");
                        Loading(1);
                        Console.WriteLine($"{data.name}은/는 70의 데미지를 받았습니다.");
                        data.currentHP -= 70;
                    }
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("크로코에게서 도망쳐 마을로 이동합니다...");
                    Loading(2);
                    data.scene = Scene.Town;
                    break;
            }
        }

        //시간 상 구현하지 못한 맵은 주석처리 했습니다.
        //시간 상 MP 기능을 아직 구현하지 못했습니다.
        //시간 상 아이템 획득은 구현하지 못했습니다.
    }
}
