public interface IAttacker
{
    /// <summary>
    /// ���������� ����� �� ����.
    /// </summary>
    /// <param name="target">����, ����������� IDamageable.</param>
    void Attack(IDamageable target);
}
