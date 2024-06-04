using ExpenseWeb.Domain;
using ExpenseWeb.Model;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseWeb.Controllers;

/// <summary>
/// CRUD for expenses
/// </summary>
[ApiController]
public class ExpenseApiController : ControllerBase
{
    #region Fields

    private readonly IExpenseRepository _repo;

    #endregion

    #region Constructors

    public ExpenseApiController(IExpenseRepository repo) { _repo = repo; }

    #endregion

    #region Methods

    [HttpGet]
    [Route("/api/expense")]
    public IActionResult GetExpenses()
    {
        return Ok(_repo.ReadAll());
    }

    [HttpGet]
    [Route("/api/expense/{id}")]
    public IActionResult GetExpense(int id) { return Ok(_repo.ReadById(id)); }

    [HttpPost]
    [Route("/api/expense")]
    public IActionResult CreateExpense(ExpenseModel expense)
    {
        if (!TryValidateModel(expense, out var result))
        {
            return result;
        }

        _repo.Create(expense);
        return Ok();
    }

    [HttpPut]
    [Route("/api/expense/{id}")]
    public IActionResult UpdateExpense(int id, ExpenseModel expense)
    {
        if (!TryValidateModel(expense, out var result))
        {
            return result;
        }

        _repo.Update(expense);
        return Ok();
    }

    [HttpDelete]
    [Route("/api/expense/{id}")]
    public IActionResult DeleteExpense(int id)
    {
        _repo.Delete(id);
        return NoContent();
    }

    private bool TryValidateModel(ExpenseModel model, out IActionResult result)
    {
        // 檢查 CreateDate 不能晚於 1 年前
        if (model.CreateDate < DateTime.Now.AddYears(-1))
        {
            result = BadRequest(new ErrorModel("CreateDate cannot be more than 1 year ago"));
            return false;
        }

        result = null;
        return true;
    }

    #endregion
}