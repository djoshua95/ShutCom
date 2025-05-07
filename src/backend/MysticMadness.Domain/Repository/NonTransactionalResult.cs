using MysticMadness.Domain.Enums;

namespace MysticMadness.Domain.Repository;

public class NonTransactionalResult<TEntity>
{
    public TypeOfOperation TypeOfOperation { get; set; }
    public List<TEntity> SuccessfulResultsAfterOperation { get; set; } = [];
    public List<TEntity> FailedResultsAfterOperation { get; set; } = [];
}
