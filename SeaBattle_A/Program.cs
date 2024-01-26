var testCasesCount = Convert.ToInt32(Console.ReadLine());

for (var i = 0; i < testCasesCount; i++)
{
    var testCases = Console.ReadLine();
    var shipsSize = testCases!.Split(' ').ToArray();

    var map = new Map().CreateMapByRule();
    foreach (var shipSize in shipsSize)
    {
        if (!map.TryAddShipFromInput(int.Parse(shipSize)))
        {
            break;
        }
        
    }

    Console.WriteLine(map.Valid() ? "YES" : "NO");
}

#pragma warning disable CA1050
public class Map
#pragma warning restore CA1050
{
    private readonly Dictionary<int, Ship> _shipBySize = new();

    public void Add(Ship ship)
    {
        var shipSize = ship.GetSize();
        _shipBySize.Add(shipSize, ship);
    }

    public bool TryAddShipFromInput(int shipSize)
    {
        if (_shipBySize.TryGetValue(shipSize, out var ship))
        {
            return ship.TryAdd();
        }
        return false;
    }

    public bool Valid()
        => _shipBySize.Values.All(ship => ship.Valid());
}

#pragma warning disable CA1050
public static class MapExtension
#pragma warning restore CA1050
{
    public static Map CreateMapByRule(this Map map)
    {
        map.Add(new Ship(1, 4));
        map.Add(new Ship(2, 3));
        map.Add(new Ship(3, 2));
        map.Add(new Ship(4, 1));

        return map;
    }
}

#pragma warning disable CA1050
public class Ship
#pragma warning restore CA1050
{
    private readonly int _size;
    private readonly int _requiredCountOnMap;
    private int _count;

    public Ship(int size, int requiredCountOnMap)
    {
        _size = size;
        _requiredCountOnMap = requiredCountOnMap;
    }

    public int GetSize() => _size;

    public bool TryAdd()
    {
        if(_count > _requiredCountOnMap)
            return false;

        _count++;
        return true;
    }

    public bool Valid()
        => _count == _requiredCountOnMap;
}
