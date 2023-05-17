# **VAMPIRE LIKE ARENA**
------------------------
## Полезные ссылки
### [ГДД](https://docs.google.com/document/d/1j1ctWSqk-kUHAkp3YIXL3ebgs01GfNUnDoHt4SzfsZ4/edit)
### [Баланс док](https://docs.google.com/document/d/16uc-Qz0FHBVUnEztY0kLAwtftrwytGjM7lXRgvbQFBc/edit#heading=h.ma9nrfwugno)

-----------------------

## Организация проекта

### Сцены
| Название | Что происходит |
|----------|----------------|
|StartScene|Сцена с которой должна стартовать игра|
|SampleScene|Сцена на которой происходит основной игровой процесс|
-----------------------
### Пространства имён `namespace`
Для того чтоб взаимодействовать с классами игры через код надо подключить нужный вам `namespace`
|Название|За что отвечает|
|-----------------|-----------------|
|`VampireLike`|Просто обозначает прстраство игры|
|`VampireLike.StartScenes`|Содержит логику для стартовой сцены|
|`VampireLike.Core`|Содержит основную логику игры, а также содержит все `interface`'ы|
|`VampireLike.Core.Characters`|Содежит логику связанную с персонажами|
|`VampireLike.Core.Cameras`|Содержит всё что связанно с камерой|
|`VampireLike.Core.Characters.Enemies`|Содежит логику связанную с врагами|
|`VampireLike.Core.General`|Содержит класс который связывает между собой основные игровые компоненты|
|`VampireLike.Core.Input`|Содержит классы которые отвечают за пользовательский ввод|
|`VampireLike.Core.Levels`|Содержит классы которые отвечают за построенние уровня, а так же за чанки|
|`VampireLike.Core.Players`|Содержит логику которая завязана на игроке и его данных|
|`VampireLike.Core.Trees`|Содержит логику отвечающую за построенние графа|
|`VampireLike.Core.Weapons`|Содержит логику отвечающая за оружие|
-----------------------
### Файловая структура
- Arts
    - Materials
- Plugins
- Prefabs
    - Chunks
    - Enemies
    - Level
    - Projectile
    - Weapons
- Resources
- Scenes
- ScriptableObjects
- Scripts
    - Core
        - Camera
        - Character
        - General
        - Input
        - Interfaces
        - Levels
        - Player
        - Tree
        - Weapons
    - General
    - StartScene
-----------------------
### Сторонние плагины
- [DOTween](https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676)
- [Joystick Pack](https://assetstore.unity.com/packages/tools/input-management/joystick-pack-107631)
-----------------------
## Кратко как что работает
Игра запускается со `StartScene`. На `StartScene` запускаеться её собственный инитер - он инициализирует единственный `singelton` - `PlayerController`. После этого запускается следующая сцена `SampleScene`.

На `SampleScene` всё начинается с класса `EntryPoint`. Он запускает инициализацию класса `ControllerManager`. `ControllerManager` - прокидывает связи между всеми остальныими контролерами, а так же их инициализирует и запускает игровой цикл.

За каждой сущностью игры стоит её контроллер. На сцене ни находяться под объектом `Controllers`.

1. `ControllerManager` - отвечает за другие контроллеры
2. `PlayerInput` - отвечает за ввод игрока
3. `EnemiesController` - отвечает за врагов
4. `MainCharacterController` - отвечает за ГГ
5. `LevelControlelr` - отвечает за повидение уровня
6. `WeaponController` - отвечает за оружие

### Персонажи

Для ГГ и врагов есть общий класс `GameCharacterBehaviour`.

За оружие в руках персонажей отвечает класс `CharacterWeapon`(Тут акуратно так как этот класс для ГГ находиться в котролере, а у врагов в классе `EnemyCharacter`).

За данные которые содержит персонаж отвечает класс `CharacterData`. На момент написание *README* для персонажей не был написан конфиг для настройки.

### Оружие

Для оружия есть общий *абстрактный* класс `WeaponBehaviour`. И каждое оружие в игре наследуеться от него. Список всех типов оружия которые пресутствуют в игре находяться в `enum` `WeaponType`, если хотите добавить новое оружие то вносите туда ещё одно перечисление. Сами оружия это префабы в которых храняться тип оружия.

Оружия в игре настраиваються через `WeaponConfig`.

Для каждого оружия есть `Projectile`, они так же представлены в виде префаба и так же настраиваються в `WeaponConfig`. Все типы `Projectile` хранятся в `ProjectileType`.

В игре реализовна три оружия: 
- Ближнего боя
- Оружие дальнего боя
- Оружие каторое касается