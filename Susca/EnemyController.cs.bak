public class EnemyController : CharacterController
{
	public SimpleBot Brain { get; }
	bool IsActive { get; set; } = true;

	public EnemyController(Level level, EnemyController enemy, Player player) : base (level, enemy)
	{
		this.Brain = new BasicBot(enemy, level, player);
	}
}