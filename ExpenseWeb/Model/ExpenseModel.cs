namespace ExpenseWeb.Model;

/// <summary>
/// 支出模型
/// </summary>
/// <remarks>
/// 一筆支出要至少包含：
//
// 1.	標題
// 2.	金額
// 3.	發生日期和時間
// 4.	分類
/// </remarks>
public class ExpenseModel
{
    /// <summary>
    /// 支出編號
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 標題
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// 金額
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// 發生日期和時間
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// 分類
    /// </summary>
    public CategoryEnum Category { get; set; }
}

/// <summary>
/// 分類列舉
/// </summary>
/// <remarks>
/// 分類只能包含 [食、衣、住、行]
/// </remarks>
public enum CategoryEnum
{
    /// <summary>
    /// 食
    /// </summary>
    Food = 0,

    /// <summary>
    /// 衣
    /// </summary>
    Clothing = 1,

    /// <summary>
    /// 住
    /// </summary>
    Housing = 2,

    /// <summary>
    /// 行
    /// </summary>
    Transportation = 3
}