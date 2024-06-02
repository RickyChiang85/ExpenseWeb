using ExpenseWeb.Controllers;
using ExpenseWeb.Domain;
using ExpenseWeb.Model;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace ExpenseWeb.Test;

public class ExpenseWebTest
{
    private IExpenseRepository _repo;

    public ExpenseController GetSystemUnderTest()
    {
        _repo = Substitute.For<IExpenseRepository>();
        return new ExpenseController(_repo);
    }

    [Fact]
    public void GetExpenses_ReturnsAllExpenses()
    {
        // Arrange
        var controller = GetSystemUnderTest();
        var expenses = new List<ExpenseModel>
        {
            new ExpenseModel { Id = 1, Title = "Expense 1", Amount = 100, Category = CategoryEnum.Food},
            new ExpenseModel { Id = 2, Title = "Expense 2", Amount = 200, Category = CategoryEnum.Transportation},
        };
        _repo.ReadAll().Returns(expenses);

        // Act
        var result = controller.GetExpenses();

        // Assert
        Assert.IsType<OkObjectResult>(result);
        var okResult = result as OkObjectResult;
        Assert.Equal(expenses, okResult.Value);
    }

    [Fact]
    public void GetExpense_ReturnsExpense()
    {
        // Arrange
        var controller = GetSystemUnderTest();
        var expense = new ExpenseModel { Id = 1, Title = "Expense 1", Amount = 100, Category = CategoryEnum.Food};
        _repo.ReadById(1).Returns(expense);

        // Act
        var result = controller.GetExpense(1);

        // Assert
        Assert.IsType<OkObjectResult>(result);
        var okResult = result as OkObjectResult;
        Assert.Equal(expense, okResult.Value);
    }

    [Fact]
    public void CreateExpense_CreatesExpense()
    {
        // Arrange
        var controller = GetSystemUnderTest();
        var expense = new ExpenseModel { Id = 1, Title = "Expense 1", Amount = 100, Category = CategoryEnum.Food};

        // Act
        var result = controller.CreateExpense(expense);

        // Assert
        _repo.Received().Create(expense);
        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public void UpdateExpense_UpdatesExpense()
    {
        // Arrange
        var controller = GetSystemUnderTest();
        var expense = new ExpenseModel { Id = 1, Title = "Expense 1", Amount = 100, Category = CategoryEnum.Food};

        // Act
        var result = controller.UpdateExpense(expense);

        // Assert
        _repo.Received().Update(expense);
        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public void DeleteExpense_DeletesExpense()
    {
        // Arrange
        var controller = GetSystemUnderTest();

        // Act
        var result = controller.DeleteExpense(1);

        // Assert
        _repo.Received().Delete(1);
        Assert.IsType<OkResult>(result);
    }
}