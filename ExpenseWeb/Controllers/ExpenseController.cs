using ExpenseWeb.Domain;
using ExpenseWeb.Model;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseWeb.Controllers;

/// <summary>
/// CRUD for expenses
/// </summary>
public class ExpenseController
{
    #region Fields

    private IExpenseRepository _repo;
    #endregion

    #region Constructors

    public ExpenseController(IExpenseRepository repo) { _repo = repo; }

    #endregion

    #region Methods

    [HttpGet]
    public IActionResult GetExpenses()
    {
        return new OkObjectResult(_repo.ReadAll());
    }

    [HttpGet]
    public IActionResult GetExpense(int id)
    {
        return new OkObjectResult(_repo.ReadById(id));
    }

    [HttpPost]
    public IActionResult CreateExpense(ExpenseModel expense)
    {
        _repo.Create(expense);
        return new OkResult();
    }

    [HttpPut]
    public IActionResult UpdateExpense(ExpenseModel expense)
    {
        _repo.Update(expense);
        return new OkResult();
    }

    [HttpDelete]
    public IActionResult DeleteExpense(int id)
    {
        _repo.Delete(id);
        return new OkResult();
    }

    #endregion
}