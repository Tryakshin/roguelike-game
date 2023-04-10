namespace roguelike_game;

public class Character : Entity
{
    protected int Health;
    protected int Damage;

    protected Character(int x, int y, int health, int damage, char symbol = 'M', 
        ConsoleColor color = ConsoleColor.Magenta, bool collision = true)
        : base(x, y, collision, symbol, color)
    {
        Health = health;
        Damage = damage;
        X = x;
        Y = y;
        Collision = true;
        Symbol = symbol;
        Color = color;
    }

    public static Character CreateCharacter(int x, int y, int characterType)
    {
        switch (characterType)
        {
            case 0:
                return new Character(x, y, 50, 5, symbol: 'A');
            case 1:
                return new Character(x, y, 25, 10, symbol: 'B');
            case 2:
                return new Character(x, y, 40, 7, symbol: 'C');
            default:
                throw new ArgumentException($"Invalid character type: {characterType}");
        }
    }

    public bool InVisibleDistance(Entity entity)
    {
        return Math.Sqrt(Math.Pow(X - entity.X, 2) + Math.Pow(Y - entity.Y, 2)) <= 10;
    }
    
    public void MoveToEntity(Map map, Player player)
    {
        var path = FindPath(map, player);
        if (path is not { Count: >= 2 })
        {
            return;
        }
        
        X = path[1].X;
        Y = path[1].Y;
    }


    private List<Entity>? FindPath(Map map, Entity target)
    {
        var closedSet = new HashSet<Node>();
        var openSet = new HashSet<Node>();

        var startNode = new Node(this, GetHeuristicPathLength(target));
        openSet.Add(startNode);
        while (openSet.Count > 0)
        {
            var currentNode = openSet.OrderBy(node => node.EstimateFullPathLength).First();
            if (currentNode.Entity.X == target.X && currentNode.Entity.Y == target.Y)
            {
                return GetPathForNode(currentNode);
            }

            openSet.Remove(currentNode);
            closedSet.Add(currentNode);
            foreach (var neighbourNode in GetNeighbours(currentNode, target, map))
            {
                if (closedSet.Any(node => node.Entity.X == neighbourNode.Entity.X && node.Entity.Y == neighbourNode.Entity.Y)) continue;
                var openNode = openSet.FirstOrDefault(node =>
                    node.Entity.X == neighbourNode.Entity.X && node.Entity.Y == neighbourNode.Entity.Y);
                if (openNode == null) openSet.Add(neighbourNode);
                else if (openNode.PathLengthFromStart > neighbourNode.PathLengthFromStart)
                {
                    openNode.CameFrom = currentNode;
                    openNode.PathLengthFromStart = neighbourNode.PathLengthFromStart;
                }
            }
        }
        return null;
    }
    
    private HashSet<Node> GetNeighbours(Node pathNode, Entity target, Map map)
    {
        var result = new HashSet<Node>();

        var neighbourPoints = new Entity?[4];
        if (pathNode.Entity.Y + 1 <= map.Height - 1) neighbourPoints[0] = map.EntitiesList[pathNode.Entity.Y + 1][pathNode.Entity.X];
        if (pathNode.Entity.Y - 1 >= 0) neighbourPoints[1] = map.EntitiesList[pathNode.Entity.Y - 1][pathNode.Entity.X];
        if (pathNode.Entity.X + 1 <= map.Width - 1) neighbourPoints[2] = map.EntitiesList[pathNode.Entity.Y][pathNode.Entity.X + 1];
        if (pathNode.Entity.X - 1 >= 0) neighbourPoints[3] = map.EntitiesList[pathNode.Entity.Y][pathNode.Entity.X - 1];

        foreach (var point in neighbourPoints)
        {
            if ((point == null || point.Collision) && point is not Player) continue;
            result.Add(new Node(point, GetHeuristicPathLength(target),
                pathNode, pathNode.PathLengthFromStart + 1));
        }
        return result;
    }

    
    
    private int GetHeuristicPathLength(Entity target)
    {
        return Math.Abs(X - target.X) + Math.Abs(Y - target.Y);
    }
    
    private static List<Entity> GetPathForNode(Node pathNode)
    {
        var result = new List<Entity>();
        var currentNode = pathNode;
        while (currentNode != null)
        {
            result.Add(currentNode.Entity);
            currentNode = currentNode.CameFrom;
        }
        result.Reverse();
        return result;
    }
    
    private class Node
    {
        public readonly Entity Entity;
        public int PathLengthFromStart;
        private readonly int _heuristicEstimatePathLength;
        public Node? CameFrom;
        public int EstimateFullPathLength => PathLengthFromStart + _heuristicEstimatePathLength;

        public Node(Entity entity, int heuristicEstimatePathLength, Node? cameFrom = null, int pathLengthFromStart = 0)
        {
            Entity = entity;
            _heuristicEstimatePathLength = heuristicEstimatePathLength;
            CameFrom = cameFrom;
            PathLengthFromStart = pathLengthFromStart;
        }
    }
}
