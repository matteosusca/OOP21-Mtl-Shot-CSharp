using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using System.IO;

using System.Linq;

using System.Collections;
internal class Stage
{
    public Player Player { get; }
    public Collection<Enemy> Enemies { get; }
    public Collection<Bullet> Bullets { get; }
    public Level Level { get; }
    public StageImpl() throws IOException, InstanceNotFoundException 
	{
        this.Level = new Level(new List<string>()
		{
            "segments/map.txt", 
            "segments/map2.txt", 
            "segments/map3.txt", 
            "segments/map4.txt"
		});
        this.Enemies = new LinkedList<>();
        AddEnemies();
        this.Player = new PlayerBuilder()
                .Hitbox(new Vector2D(1, 1.5))
                .Position(Level.getPlayerSpawn())
                .Weapon(new R99())
                .Health(new SimpleHealth())
                .Lives(3)
                .Build();
        this.Bullets = new LinkedList<>();
    }

    private void AddEnemies()
    {
        for (Vector2D pos : Level.getEnemiesSpawn()) 
		{
            enemies.add(new Enemy(pos, new Vector2D(1, 1.5), new SimpleHealth()));
        }
    }
}