using ExpenseWeb.Model;

namespace ExpenseWeb.Domain;

/// <summary>
/// CRUD for Expense
/// </summary>
public interface IExpenseRepository
{
    /// <summary>
    /// Create a new expense
    /// </summary>
    /// <param name="expense">The expense to create</param>
    void Create(ExpenseModel expense);

    /// <summary>
    /// Read all expenses
    /// </summary>
    /// <returns>All expenses</returns>
    IEnumerable<ExpenseModel> ReadAll();

    /// <summary>
    /// Read an expense by id
    /// </summary>
    /// <param name="id">The id of the expense to read</param>
    /// <returns>The expense with the given id</returns>
    ExpenseModel ReadById(int id);

    /// <summary>
    /// Update an expense
    /// </summary>
    /// <param name="expense">The expense to update</param>
    void Update(ExpenseModel expense);

    /// <summary>
    /// Delete an expense
    /// </summary>
    /// <param name="id">The id of the expense to delete</param>
    void Delete(int id);
}

/// <summary>
///  Expense Repository, use Collection to store data
/// </summary>
public class ExpenseRepository : IExpenseRepository
{
    private static int _id = 0;
    private List<ExpenseModel> _expenses = new List<ExpenseModel>();

    public void Create(ExpenseModel expense)
    {
        expense.Id = ++_id;
        _expenses.Add(expense);
    }

    public IEnumerable<ExpenseModel> ReadAll()
    {
        return _expenses;
    }

    public ExpenseModel ReadById(int id)
    {
        return _expenses.FirstOrDefault(e => e.Id == id);
    }

    public void Update(ExpenseModel expense)
    {
        var index = _expenses.FindIndex(e => e.Id == expense.Id);
        if (index >= 0)
        {
            _expenses[index] = expense;
        }
    }

    public void Delete(int id)
    {
        var index = _expenses.FindIndex(e => e.Id == id);
        if (index >= 0)
        {
            _expenses.RemoveAt(index);
        }
    }
}
