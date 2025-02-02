public interface IAttacker
{
    /// <summary>
    /// Производит атаку по цели.
    /// </summary>
    /// <param name="target">Цель, реализующая IDamageable.</param>
    void Attack(IDamageable target);
}
